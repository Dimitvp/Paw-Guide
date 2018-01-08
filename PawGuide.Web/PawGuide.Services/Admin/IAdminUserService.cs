namespace PawGuide.Services.Admin
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync();

        Task<UserDetailsServiceModel> UserById(string id);

        Task<IEnumerable<AdminUserListingServiceModel>> FindAsync(string searchText);
    }
}
