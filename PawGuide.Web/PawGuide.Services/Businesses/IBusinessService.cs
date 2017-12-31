namespace PawGuide.Services.Businesses
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Services.Businesses.Models;

    public interface IBusinessService
    {
        Task<IEnumerable<BusinessListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<BusinessDetailsServiceModel> ById(int id);

        Task<IEnumerable<BusinessLocationsServicModel>> AllLocations();

        Task CreateAsync(
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
            string authorId);

        Task<bool> EditAsync(
            int id,
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
            string authorId);

        Task<bool> Exists(int id);
    }
}