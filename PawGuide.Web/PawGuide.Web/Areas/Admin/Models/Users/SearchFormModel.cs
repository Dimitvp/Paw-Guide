namespace PawGuide.Web.Areas.Admin.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class SearchFormModel
    {
        public string SearchText { get; set; }

        [Display(Name = "Search In Users")]
        public bool SearchInUsers { get; set; } = true;

    }
}
