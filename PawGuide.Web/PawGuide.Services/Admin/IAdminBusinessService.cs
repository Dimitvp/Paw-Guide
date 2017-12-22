namespace PawGuide.Services.Admin
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Businesses.Models;

    public interface IAdminBusinessService
    {
        Task<IEnumerable<BusinessListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<BusinessDetailsServiceModel> ById(int id);

        Task<bool> ApproveBusinessAsync(int BusinessId, bool IsApproved);

    }
}
