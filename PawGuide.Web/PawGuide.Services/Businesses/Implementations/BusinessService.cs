namespace PawGuide.Services.Businesses.Implementations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Services.Businesses.Models;

    using static ServiceConstants;

    public class BusinessService : IBusinessService
    {
        private readonly PawGuideDbContext db;
        private readonly UserManager<User> userManager;

        public BusinessService(PawGuideDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<BusinessListingServiceModel>> AllAsync(int page = 1)
            => await this.db
                .Businesses
                .OrderByDescending(b => b.PublishDate)
                .Skip((page - 1) * BusinessesPageSize)
                .Take(BusinessesPageSize)
                .ProjectTo<BusinessListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<BusinessListingServiceModel>> BusinessTypeAsync(int type, int page = 1)
            => await this.db
                .Businesses
                .Where(b => b.Type.GetHashCode() == type)
                .OrderByDescending(b => b.PublishDate)
                .Skip((page - 1) * BusinessesPageSize)
                .Take(BusinessesPageSize)
                .ProjectTo<BusinessListingServiceModel>()
                .ToListAsync();

        public async Task<int> TotalAsync()
            => await this.db.Businesses.CountAsync();

        public async  Task<IEnumerable<BusinessLocationsServicModel>> AllLocations()
            => await this.db
                .Businesses
                .Where(b => b.IsApproved == true)
                .ProjectTo<BusinessLocationsServicModel>()
                .ToListAsync();

        public async Task<IEnumerable<BusinessListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Businesses
                .OrderByDescending(c => c.Id)
                .Where(c => c.Name.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<BusinessListingServiceModel>()
                .ToListAsync();
        }

        public async Task<BusinessDetailsServiceModel> ById(int id)
            => await this.db
                .Businesses
                .Where(a => a.Id == id)
                .ProjectTo<BusinessDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<BusinessEditServiceModel> EditById(int id)
            => await this.db
                .Businesses
                .Where(a => a.Id == id)
                .ProjectTo<BusinessEditServiceModel>()
                .FirstOrDefaultAsync();

        public async Task SetImage(int id, string image)
        {
            var business = await this.db.Businesses.FindAsync(id);
            business.Image = image;

            this.db.SaveChanges();
        }

        public async Task<int> CreateAsync(
            string name,
            TypeBusiness type,
            string webPageUrl,
            string address,
            double latLocation,
            double lngLocation,
            IEnumerable<PetType> petTypes,
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
                PetType = (PetType)petTypes.Cast<int>().Sum(),
                City = city,
                PicUrl = picUrl,
                IsApproved = isApproved,
                Note = note,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId
            };

            this.db.Add(business);

            await this.db.SaveChangesAsync();

            return business.Id;
        }

        public async Task<bool> EditAsync(
            int id, 
            string name, 
            TypeBusiness type, 
            string webPageUrl, 
            string address, 
            double latLocation,
            double lngLocation,
            IEnumerable<PetType> petTypes, 
            string city, 
            string picUrl,
            bool isApproved,
            string note, 
            string authorId)
        {
            var business = await this.db.Businesses.FirstOrDefaultAsync(b => b.Id == id);

            if (business == null)
            {
                return false;
            }

            business.Name = name;
            business.Type = type;
            business.WebPageUrl = webPageUrl;
            business.Address = address;
            business.LatLocation = latLocation;
            business.LngLocation = lngLocation;
            business.PetType = (PetType)petTypes.Cast<int>().Sum();
            business.City = city;
            business.PicUrl = picUrl;
            business.IsApproved = isApproved;
            business.Note = note;

            this.db.SaveChanges();

            return true;
        }

        public async Task<bool> Exists(int id)
            => await this.db.Businesses.AnyAsync(b => b.Id == id);

        public async Task DeleteAsync(int id, string userId, User user)
        {
            var business = await this.db.Businesses
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            var userRole = await this.userManager.IsInRoleAsync(user, "Administrator");

            if (business.AuthorId != userId && !userRole)
            {
                return;
            }

            if (business == null)
            {
                return;
            }

            this.db.Businesses.Remove(business);
            this.db.SaveChanges();
        }
    }
}
