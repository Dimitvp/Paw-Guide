﻿namespace PawGuide.Web.Areas.Admin.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Admin.Models;
    using System.Collections.Generic;

    public class UserListingsViewModel : SearchFormModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
