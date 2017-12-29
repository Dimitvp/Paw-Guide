namespace PawGuide.Web.Areas.Business.Models.Businesses
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using Services;
    using Services.Businesses.Models;

    public class BusinessListingViewModel
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

        public int TotalBusinesses { get; set; }

        public int TotalPages =>
            (int)Math.Ceiling((double)this.TotalBusinesses / ServiceConstants.BusinessesPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
