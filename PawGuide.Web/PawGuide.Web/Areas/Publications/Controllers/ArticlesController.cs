namespace PawGuide.Web.Areas.Publications.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Articles;
    using Services.Publications;
    using Services.Html;
    using System.Threading.Tasks;
    using Services.Publications.Models;

    using static WebConstants;

    [Area(PublicationsArea)]
    [Authorize(Roles = "Administrator, Moderator")]
    public class ArticlesController : Controller
    {
        private readonly IPublicationService publications;
        private readonly UserManager<User> userManager;
        private readonly IHtmlService html;

        public ArticlesController(
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
            => View(new ArticleListingViewModel
            {
                Articles = await this.publications.AllArticlesAsync(page),
                TotalPublications = await this.publications.TotalAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await this.publications.ArticleById(id));

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(PublicationsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);

            await this.publications.CreateAsync(model.Title, model.Content, userId);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var articleExists = await this.publications.Exists(id);

            if (!articleExists)
            {
                return NotFound();
            }

            return this.ViewOrNotFound(await this.publications.ArticleById(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ArticleDetailsServiceModel articleModel)
        {
            if (!ModelState.IsValid)
            {
                return View(articleModel);
            }

            var userId = this.userManager.GetUserId(User);

            var update = await this.publications.EditAsync(
                id,
                articleModel.Title,
                articleModel.Content,
                articleModel.PicUrl,
                userId);

            if (!update == null)
            {
                return NotFound();
            }

            this.TempData.AddWarningMessage(string.Format(SuccessfullEdit, articleModel.Title));


            return RedirectToAction(nameof(Index));
        }
    }
}
