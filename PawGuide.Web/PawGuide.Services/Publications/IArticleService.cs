namespace PawGuide.Services.Publications
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        Task<IEnumerable<ArticleListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<ArticleDetailsServiceModel> ById(int id);

        Task CreateAsync(string title, string content, string authorId);

        Task<bool> EditAsync(
            int id,
            string title,
            string content,
            string authorId);

        Task<bool> Exists(int id);
    }
}
