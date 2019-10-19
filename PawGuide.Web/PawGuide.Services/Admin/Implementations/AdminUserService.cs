namespace PawGuide.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using AutoMapper;

    public class AdminUserService : IAdminUserService
    {
        private readonly PawGuideDbContext db;
        private MapperConfiguration config;

        public AdminUserService(PawGuideDbContext db, MapperConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
            =>
             await this.db.Users
                .ProjectTo<AdminUserListingServiceModel>(config)
                .ToListAsync();

        public async Task<UserDetailsServiceModel> UserById(string id)
            => await this.db.Users
                .Where(u => u.Id == id)
                .ProjectTo<UserDetailsServiceModel>(config)
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<AdminUserListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Users
                .OrderBy(u => u.UserName)
                .Where(u => u.Name.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<AdminUserListingServiceModel>(config)
                .ToListAsync();
        }
    }
}
