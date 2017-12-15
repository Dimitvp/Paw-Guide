namespace PawGuide.Services.Publications.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ServiceConstants;

    public class ArticleService : IArticleService
    {
        private readonly PawGuideDbContext db;

        public ArticleService(PawGuideDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> AllAsync(int page = 1)
            => await this.db
                .Articles
                .OrderByDescending(a => a.PublishDate)
                .Skip((page - 1) * ArticlesPageSize)
                .Take(ArticlesPageSize)
                .ProjectTo<ArticleListingServiceModel>()
                .ToListAsync();

        public async Task<int> TotalAsync()
            => await this.db.Articles.CountAsync();

        public async Task<ArticleDetailsServiceModel> ById(int id)
            => await this.db
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<ArticleDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task CreateAsync(string title, string content, string authorId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId
            };

            this.db.Add(article);

            await this.db.SaveChangesAsync();
        }
    }
}
