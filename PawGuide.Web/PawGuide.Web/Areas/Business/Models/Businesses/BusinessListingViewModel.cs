namespace PawGuide.Web.Areas.Business.Models.Businesses
{
    using Data.Models;
    using Services.Businesses.Models;
    using System.Collections.Generic;

    public class BusinessListingViewModel : Pager
    {
        public IEnumerable<BusinessListingServiceModel> Businesses { get; set; }

        public TypeBusiness Type (int index)
        {
            var type = (TypeBusiness)index;

            return type;
        }

        public PetType PetType(int index)
        {
            var type = (PetType)index;

            return type;
        }
    }
}
