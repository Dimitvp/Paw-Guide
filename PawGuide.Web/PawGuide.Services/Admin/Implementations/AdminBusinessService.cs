namespace PawGuide.Services.Admin.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using PawGuide.Data;
    using PawGuide.Services.Businesses.Models;
    using System.Linq;

    using static ServiceConstants;

    public class AdminBusinessService : IAdminBusinessService
    {

        private readonly PawGuideDbContext db;

        public AdminBusinessService(PawGuideDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BusinessListingServiceModel>> AllAsync(int page = 1)
            => await this.db
                .Businesses
                .Where(b => b.IsApproved == false)
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
            .Where(b => b.Id == id)
            .ProjectTo<BusinessDetailsServiceModel>()
            .FirstOrDefaultAsync();

        public async Task<bool> ApproveBusinessAsync(int id, bool isApproved)
        {

            var business = this.db.Businesses.FirstOrDefault(b => b.Id == id);

            if (business == null)
            {
                return false;
            }

            if (isApproved == false)
            {
                this.db.Businesses.Remove(business);
            }
            else
            {
                business.IsApproved = isApproved;
            }

            await this.db.SaveChangesAsync();
            return true;
        }
    }
}
