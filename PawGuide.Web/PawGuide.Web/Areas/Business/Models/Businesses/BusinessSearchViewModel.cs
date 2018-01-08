namespace PawGuide.Web.Areas.Business.Models.Businesses
{
    using System.Collections.Generic;
    using PawGuide.Data.Models;
    using PawGuide.Services.Businesses.Models;

    public class BusinessSearchViewModel
    {
        public IEnumerable<BusinessListingServiceModel> Businesses { get; set; }
            = new List<BusinessListingServiceModel>();

        public TypeBusiness Type(int index)
        {
            var type = (TypeBusiness)index;

            return type;
        }

        public PetType PetType(int index)
        {
            var type = (PetType)index;

            return type;
        }

        public string SearchText { get; set; }
    }
}
