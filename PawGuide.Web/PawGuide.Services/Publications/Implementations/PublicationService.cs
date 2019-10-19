namespace PawGuide.Services.Publications.Implementations
{
    using AutoMapper;
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

    public class PublicationService : IPublicationService
    {
        private readonly PawGuideDbContext db;
        private MapperConfiguration config;

        public PublicationService(PawGuideDbContext db, MapperConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public async Task<IEnumerable<ArticleListingServiceModel>> AllArticlesAsync(int page = 1)
            => await this.db
                .Articles
                .OrderByDescending(a => a.PublishDate)
                .Skip((page - 1) * PublicationsPageSize)
                .Take(PublicationsPageSize)
                .ProjectTo<ArticleListingServiceModel>(config)
                .ToListAsync();

        public async Task<IEnumerable<AdListingServiceModel>> AllAdsAsync(int page = 1)
            => await this.db
                .Ads
                .OrderByDescending(a => a.PublishDate)
                .Skip((page - 1) * PublicationsPageSize)
                .Take(PublicationsPageSize)
                .ProjectTo<AdListingServiceModel>(config)
                .ToListAsync();

        public async Task<int> TotalAsync()
            => await this.db.Articles.CountAsync();

        public async Task<ArticleDetailsServiceModel> ArticleById(int id)
            => await this.db
                .Articles
                .Where(a => a.Id == id)
                .ProjectTo<ArticleDetailsServiceModel>(config)
                .FirstOrDefaultAsync();

        public async Task<AdDetailsServiceModel> AdById(int id)
            => await this.db
                .Ads
                .Where(a => a.Id == id)
                .ProjectTo<AdDetailsServiceModel>(config)
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

        public async Task CreateAsync(string title, string content, string picUrl, bool isApproved, string authorId)
        {
            var ad = new Ad
            {
                Title = title,
                Content = content,
                PublishDate = DateTime.UtcNow,
                IsApproved = isApproved,
                PicUrl = picUrl,
                AuthorId = authorId
            };

            this.db.Add(ad);

            await this.db.SaveChangesAsync();
        }

        public async Task<bool> EditAsync(
            int id,
            string title,
            string content,
            string picUrl,
            string authorId)
        {
            var article = await this.db.Articles.FirstOrDefaultAsync(b => b.Id == id);

            if (article == null)
            {
                return false;
            }

            article.Title = title;
            article.Content = content;
            article.PicUrl = picUrl;
            this.db.SaveChanges();

            return true;
        }

        public async Task<bool> EditAsync(
            int id, 
            string title,
            string content,
            string picUrl,
            bool isApproved,
            string authorId)
        {
            var ad = await this.db.Ads.FirstOrDefaultAsync(b => b.Id == id);

            if (ad == null)
            {
                return false;
            }

            ad.Title = title;
            ad.Content = content;
            ad.PicUrl = picUrl;
            ad.IsApproved = isApproved;

            this.db.SaveChanges();

            return true;
        }

        public async Task<bool> Exists(int id)
            => await this.db.Articles.AnyAsync(b => b.Id == id);
    }
}
