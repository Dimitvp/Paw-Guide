namespace PawGuide.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    using static DataConstants;

    public class User : IdentityUser
    {
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<Ad> Ads { get; set; } = new List<Ad>();

        public List<Business> Businesses { get; set; } = new List<Business>();
    }
}