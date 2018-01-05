namespace PawGuide.Web.Areas.Publications.Models.Ads
{
    using System;
    using System.Collections.Generic;
    using PawGuide.Services;
    using PawGuide.Services.Publications.Models;

    public class AdListingViewModel : Pager
    {
        public IEnumerable<AdListingServiceModel> Ads { get; set; }

    }
}
