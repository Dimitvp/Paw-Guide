namespace PawGuide.Web.Areas.Admin.Models.Businesses
{
    using System;
    using System.Collections.Generic;
    using PawGuide.Services;
    using PawGuide.Services.Businesses.Models;

    public class BusinessForApproveListingViewModel
    {
        public IEnumerable<BusinessListingServiceModel> Businesses { get; set; }

        public int TotalBusinesses { get; set; }

        public int TotalPages =>
            (int)Math.Ceiling((double)this.TotalBusinesses / ServiceConstants.ArticlesPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
