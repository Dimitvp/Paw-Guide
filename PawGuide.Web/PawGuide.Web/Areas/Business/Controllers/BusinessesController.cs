namespace PawGuide.Web.Areas.Business.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Data.Models;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using PawGuide.Web.Areas.Business.Models.Businesses;
    using Services.Businesses;

    using static WebConstants;

    [Area(BusinessArea)]
    [Authorize]
    public class BusinessesController : Controller
    {
        private readonly IBusinessService businesses;
        private readonly UserManager<User> userManager;

        public BusinessesController(IBusinessService businesses, UserManager<User> userManager)
        {
            this.businesses = businesses;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
            => View(new BusinessListingViewModel
            {
                Businesses = await this.businesses.AllAsync(page),
                TotalBusinesses = await this.businesses.TotalAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await this.businesses.ById(id));

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(PublishBusinessFormModel model)
        {
            var userId = this.userManager.GetUserId(User);

            var isApproved = false;

            await this.businesses.CreateAsync(
                model.Name,
                model.Type,
                model.WebPageUrl,
                model.Address,                 
                model.LatLocation,
                model.LngLocation,
                model.PetType,
                model.City,
                model.PicUrl,
                isApproved,
                model.Note,
                userId);

            return RedirectToAction(nameof(Index));
        }
    }
}