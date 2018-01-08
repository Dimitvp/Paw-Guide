namespace PawGuide.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    public class AdminUserService : IAdminUserService
    {
        private readonly PawGuideDbContext db;

        public AdminUserService(PawGuideDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
            =>
             await this.db.Users
                .ProjectTo<AdminUserListingServiceModel>()
                .ToListAsync();

        public async Task<UserDetailsServiceModel> UserById(string id)
            => await this.db.Users
                .Where(u => u.Id == id)
                .ProjectTo<UserDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<AdminUserListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Users
                .OrderBy(u => u.UserName)
                .Where(u => u.Name.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<AdminUserListingServiceModel>()
                .ToListAsync();
        }
    }
}
