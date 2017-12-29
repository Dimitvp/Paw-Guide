namespace PawGuide.Services.Publications
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPublicationService
    {
        Task<IEnumerable<ArticleListingServiceModel>> AllArticlesAsync(int page = 1);

        Task<IEnumerable<AdListingServiceModel>> AllAdsAsync(int page = 1);

        Task<int> TotalAsync();

        Task<ArticleDetailsServiceModel> ArticleById(int id);

        Task<AdDetailsServiceModel> AdById(int id);

        Task CreateAsync(string title, string content, string authorId);

        Task CreateAsync(string title, string content, string picUrl, bool isApproved, string authorId);

        Task<bool> EditAsync(
            int id,
            string title,
            string content,
            string authorId);

        Task<bool> EditAsync(
            int id,
            string title,
            string content,
            string picUrl,
            bool isApproved,
            string authorId);

        Task<bool> Exists(int id);
    }
}
