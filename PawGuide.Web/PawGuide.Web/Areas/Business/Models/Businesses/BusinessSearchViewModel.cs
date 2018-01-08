namespace PawGuide.Web.Areas.Business.Models.Businesses
{
    using System.Collections.Generic;
    using PawGuide.Services.Businesses.Models;

    public class BusinessSearchViewModel
    {
        public IEnumerable<BusinessListingServiceModel> Businesses { get; set; }
            = new List<BusinessListingServiceModel>();

        public string SearchText { get; set; }
    }
}
