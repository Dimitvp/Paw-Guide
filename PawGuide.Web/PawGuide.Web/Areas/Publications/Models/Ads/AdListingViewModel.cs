namespace PawGuide.Web.Areas.Publications.Models.Ads
{
    using System;
    using System.Collections.Generic;
    using PawGuide.Services;
    using PawGuide.Services.Publications.Models;

    public class AdListingViewModel
    {
        public IEnumerable<AdListingServiceModel> Ads { get; set; }

        public int TotalAds { get; set; }

        public int TotalPages =>
            (int)Math.Ceiling((double)this.TotalAds / ServiceConstants.PublicationsPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
