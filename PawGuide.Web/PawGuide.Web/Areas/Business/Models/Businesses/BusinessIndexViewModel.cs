
namespace PawGuide.Web.Areas.Business.Models.Businesses
{
    using System.Collections.Generic;
    using PawGuide.Services.Businesses.Models;

    public class BusinessIndexViewModel : BusinessSearchFormModel
    {
        public IEnumerable<BusinessListingServiceModel> Business { get; set; }

    }
}
