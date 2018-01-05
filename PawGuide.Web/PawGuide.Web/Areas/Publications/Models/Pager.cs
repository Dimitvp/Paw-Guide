namespace PawGuide.Web.Areas.Publications.Models
{
    using System;
    using PawGuide.Services;

    public class Pager
    {
        public int TotalPublications { get; set; }

        public int TotalPages =>
            (int)Math.Ceiling((double)this.TotalPublications / ServiceConstants.PublicationsPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}
