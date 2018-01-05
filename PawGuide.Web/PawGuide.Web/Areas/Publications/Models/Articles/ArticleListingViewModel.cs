namespace PawGuide.Web.Areas.Publications.Models.Articles
{
    using Services.Publications.Models;
    using System.Collections.Generic;

    public class ArticleListingViewModel : Pager
    {
        public IEnumerable<ArticleListingServiceModel> Articles { get; set; }
    }
}