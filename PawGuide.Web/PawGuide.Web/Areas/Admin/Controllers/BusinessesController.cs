namespace PawGuide.Web.Areas.Admin.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure.Extensions;
    using Services.Admin;
    using Web.Areas.Admin.Models.Businesses;

    using static WebConstants;

    [Area(AdminArea)]
    [Authorize(Roles = "Moderator, Administrator")]
    public class BusinessesController : Controller
    {
        private readonly IAdminBusinessService businesses;

        public BusinessesController(IAdminBusinessService businesses)
        {
            this.businesses = businesses;
        }

        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await this.businesses.ById(id));

        public async Task<IActionResult> Index(int page = 1)
            => View(new BusinessForApproveListingViewModel
            {
                Businesses = await this.businesses.AllAsync(page),
                TotalBusinesses = await this.businesses.TotalAsync(),
                CurrentPage = page
            });

        [HttpPost]
        public async Task<IActionResult> ApproveBusiness(ApproveBusinessFormModel model)
        {
            var update = await this.businesses.ApproveBusinessAsync(model.Id, model.IsApproved);
            if (!update == null)
            {
                return this.NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
