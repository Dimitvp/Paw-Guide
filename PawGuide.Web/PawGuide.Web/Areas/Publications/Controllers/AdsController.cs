namespace PawGuide.Web.Areas.Publications.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Data.Models;
    using Services.Html;
    using Services.Publications;
    using Services.Publications.Models;
    using Models.Ads;
    using Infrastructure.Filters;
    using Infrastructure.Extensions;

    using static WebConstants;

    [Area(PublicationsArea)]
    [Authorize]
    public class AdsController : Controller
    {
        private readonly IPublicationService publications;
        private readonly UserManager<User> userManager;
        private readonly IHtmlService html;

        public AdsController(
            IPublicationService publications,
            UserManager<User> userManager,
            IHtmlService html)
        {
            this.publications = publications;
            this.userManager = userManager;
            this.html = html;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
            => View(new AdListingViewModel
            {
                Ads = await this.publications.AllAdsAsync(page),
                TotalAds = await this.publications.TotalAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await this.publications.AdById(id));

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(PublishAdFormModel model)
        {
            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);

            var isApproved = false;

            await this.publications.CreateAsync(
                model.Title,
                model.Content,
                model.PicUrl,
                isApproved,
                userId);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var adExists = await this.publications.Exists(id);

            if (!adExists)
            {
                return NotFound();
            }

            return this.ViewOrNotFound(await this.publications.AdById(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdDetailsServiceModel adModel)
        {
            var userId = this.userManager.GetUserId(User);

            var update = await this.publications.EditAsync(
                id,
                adModel.Title,
                adModel.Content,
                adModel.PicUrl,
                adModel.IsApproved,
                userId);

            if (!update == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ForApproval(int page = 1)
            => View(new AdListingViewModel
            {
                Ads = await this.publications.AllAdsAsync(page),
                TotalAds = await this.publications.TotalAsync(),
                CurrentPage = page
            });
    }
}
