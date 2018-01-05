namespace PawGuide.Web.Areas.Business.Controllers
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PawGuide.Web.Areas.Business.Models.Businesses;
    using Services.Businesses;
    using System.Threading.Tasks;
    using static WebConstants;

    [Area(BusinessArea)]
    [Authorize]
    public class BusinessesController : Controller
    {
        private readonly IBusinessService businesses;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public BusinessesController(IBusinessService businesses, 
            UserManager<User> userManager, 
            IMapper mapper)
        {
            this.businesses = businesses;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
            => View(new BusinessListingViewModel
            {
                Businesses = await this.businesses.AllAsync(page),
                TotalBusinesses = await this.businesses.TotalAsync(),
                CurrentPage = page
            });

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> BusinessByType(int type, int page = 1)
            => View(new BusinessListingViewModel
            {
                Businesses = await this.businesses.BusinessTypeAsync(type, page),
                TotalBusinesses = await this.businesses.TotalAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var currentBusiness = await this.businesses.ById(id);

            if (currentBusiness == null)
            {
                return NotFound();
            }

            return View(currentBusiness);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(PublishBusinessFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = this.userManager.GetUserId(User);

            var isApproved = false;

            var businessId = await this.businesses.CreateAsync(
                model.Name,
                model.Type,
                model.WebPageUrl,
                model.Address,                 
                model.LatLocation,
                model.LngLocation,
                model.PetTypes,
                model.City,
                model.PicUrl,
                isApproved,
                model.Note,
                userId);


            if (model.Image.HasValidImage())
            {
                var imageName = model.Image.SaveImage(businessId, model.Type.ToString(), model.Name, BusinessImagesPath);
                await this.businesses.SetImage(businessId, imageName);
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var businessExists = await this.businesses.Exists(id);

            if (!businessExists)
            {
                return NotFound();
            }

            var businessToEdit = await this.businesses.ById(id);

            var publishFormModel = this.mapper.Map<PublishBusinessFormModel>(businessToEdit);
            
            return this.ViewOrNotFound(publishFormModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PublishBusinessFormModel businessModel)
        {
            var userId = this.userManager.GetUserId(User);

            var update = await this.businesses.EditAsync(
                id,
                businessModel.Name,
                businessModel.Type,
                businessModel.WebPageUrl,
                businessModel.Address,
                businessModel.LatLocation,
                businessModel.LngLocation,
                businessModel.PetTypes,
                businessModel.City,
                businessModel.PicUrl,
                businessModel.IsApproved,
                businessModel.Note,
                userId);

            if (!update == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllLocations()
            => this.Ok(await this.businesses.AllLocations());


        public async Task<IActionResult> ForApproval(int page = 1)
            => View(new BusinessListingViewModel
            {
                Businesses = await this.businesses.AllAsync(page),
                TotalBusinesses = await this.businesses.TotalAsync(),
                CurrentPage = page
            });

        public async Task<IActionResult> Delete(int id)
        {
            var businessExists = await this.businesses.Exists(id);

            if (!businessExists)
            {
                return NotFound();
            }

            var businessToEdit = await this.businesses.ById(id);

            var publishFormModel = this.mapper.Map<PublishBusinessFormModel>(businessToEdit);

            return this.ViewOrNotFound(publishFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string empty)
        {
            var isDeletable = await this.businesses.Exists(id);
            var user = await this.userManager.GetUserAsync(User);

            if (!isDeletable)
            {
                return NotFound();
            }

            await this.businesses.DeleteAsync(id, this.userManager.GetUserId(User), user);

            return RedirectToAction(nameof(Index));
        }
    }
}