namespace PawGuide.Web.Areas.Business.Models.Businesses
{
    using System;
    using PawGuide.Services;

    public class Pager
    {
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
