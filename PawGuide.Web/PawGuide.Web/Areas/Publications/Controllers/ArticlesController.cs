namespace PawGuide.Web.Areas.Publications.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Articles;
    using Services.Publications;
    using Services.Html;
    using System.Threading.Tasks;
    using PawGuide.Services.Publications.Models;
    using static WebConstants;

    [Area(PublicationsArea)]
    [Authorize(Roles = "Administrator, Moderator")]
    public class ArticlesController : Controller
    {
        private readonly IArticleService articles;
        private readonly UserManager<User> userManager;
        private readonly IHtmlService html;

        public ArticlesController(
            IArticleService articles,
            UserManager<User> userManager,
            IHtmlService html)
        {
            this.articles = articles;
            this.userManager = userManager;
            this.html = html;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
            => View(new ArticleListingViewModel
            {
                Articles = await this.articles.AllAsync(page),
                TotalArticles = await this.articles.TotalAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await this.articles.ById(id));

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create(PublishArticleFormModel model)
        {
            model.Content = this.html.Sanitize(model.Content);

            var userId = this.userManager.GetUserId(User);

            await this.articles.CreateAsync(model.Title, model.Content, userId);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var articleExists = await this.articles.Exists(id);

            if (!articleExists)
            {
                return NotFound();
            }

            return this.ViewOrNotFound(await this.articles.ById(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ArticleDetailsServiceModel articleModel)
        {
            var userId = this.userManager.GetUserId(User);

            var update = await this.articles.EditAsync(
                id,
                articleModel.Title,
                articleModel.Content,
                userId);

            if (!update == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
