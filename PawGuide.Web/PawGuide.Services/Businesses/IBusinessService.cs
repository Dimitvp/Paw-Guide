namespace PawGuide.Services.Businesses
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Services.Businesses.Models;

    public interface IBusinessService
    {
        Task<IEnumerable<BusinessListingServiceModel>> AllAsync(int page = 1);

        Task<IEnumerable<BusinessListingServiceModel>> BusinessTypeAsync(int type, int page = 1);

        Task<IEnumerable<BusinessListingServiceModel>> FindAsync(string searchText);

        Task<int> TotalAsync();

        Task<BusinessDetailsServiceModel> ById(int id);

        Task<BusinessEditServiceModel> EditById(int id);

        Task<IEnumerable<BusinessLocationsServicModel>> AllLocations();

        Task SetImage(int id, string image);

        Task<int> CreateAsync(
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
            string authorId);

        Task<bool> EditAsync(
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
            string authorId);

        Task<bool> Exists(int id);

        Task DeleteAsync(int id, string userId, User user);
    }
}