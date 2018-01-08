namespace PawGuide.Web.Areas.Business.Models.Businesses
{
    using System.ComponentModel.DataAnnotations;

    public class BusinessSearchFormModel
    {
        public string SearchText { get; set; }

        [Display(Name = "Search In Businesses")]
        public bool SearchInBusinesses { get; set; } = true;
    }
}
