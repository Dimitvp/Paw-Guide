namespace PawGuide.Web.Areas.Admin.Models.Users
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Admin.Models;

    public class SearchViewModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }
            = new List<AdminUserListingServiceModel>();

        public IEnumerable<SelectListItem> Roles { get; set; }


        public string SearchText { get; set; }
    }
}
