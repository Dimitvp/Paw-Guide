namespace PawGuide.Services.Businesses.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Services.Businesses.Models;

    public class BusinessService : IBusinessService
    {
        private readonly PawGuideDbContext db;

        public BusinessService(PawGuideDbContext db)
        {
            this.db = db;
        }

        public Task<IEnumerable<BusinessListingServiceModel>> AllAsync(int page = 1)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> TotalAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<BusinessDetailsServiceModel> ById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(
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
            throw new System.NotImplementedException();
        }
    }
}
