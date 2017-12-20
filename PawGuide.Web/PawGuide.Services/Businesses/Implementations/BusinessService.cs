namespace PawGuide.Services.Businesses.Implementations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Services.Businesses.Models;

    using static ServiceConstants;

    public class BusinessService : IBusinessService
    {
        private readonly PawGuideDbContext db;

        public BusinessService(PawGuideDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BusinessListingServiceModel>> AllAsync(int page = 1)
            => await this.db
                .Businesses
                .OrderByDescending(b => b.PublishDate)
                .Skip((page - 1) * BusinessesPageSize)
                .Take(BusinessesPageSize)
                .ProjectTo<BusinessListingServiceModel>()
                .ToListAsync();

        public async Task<int> TotalAsync()
            => await this.db.Businesses.CountAsync();

        public async Task<BusinessDetailsServiceModel> ById(int id)
            => await this.db
                .Businesses
                .Where(a => a.Id == id)
                .ProjectTo<BusinessDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task CreateAsync(
            string name,
            TypeBusiness type,
            string webPageUrl,
            string address,
            double latLocation,
            double lngLocation,
            PetType petType,
            string city,
            string picUrl,
            bool isApproved,
            string note,
            string authorId)
        {
            var business = new Business()
            {
                Name = name,
                Type = type,
                WebPageUrl = webPageUrl,
                Address = address,
                LatLocation = latLocation,
                LngLocation = lngLocation,
                PetType = petType,
                City = city,
                PicUrl = picUrl,
                IsApproved = isApproved,
                Note = note,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId
            };

            this.db.Add(business);

            await this.db.SaveChangesAsync();
        }
    }
}
