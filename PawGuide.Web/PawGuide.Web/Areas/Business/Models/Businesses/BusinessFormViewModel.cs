namespace PawGuide.Web.Areas.Business.Models.Businesses
{
    using Data.Models;
    using Common.Mapping;
    using Services.Businesses.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    using static Data.DataConstants;

    public class BusinessFormViewModel : IMapFrom<BusinessEditServiceModel>
    {
        [Required]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public TypeBusiness Type { get; set; }

        [MinLength(5)]
        [MaxLength(2000)]
        [Display(Name = "Web Page")]
        public string WebPageUrl { get; set; }

        [Required]
        [MinLength(CityMinLength)]
        [MaxLength(CityMaxLength)]
        public string City { get; set; }

        [Required]
        [MinLength(BusinessAddressMinLength)]
        [MaxLength(BusinessAddressMaxLength)]
        public string Address { get; set; }

        [Display(Name = "Lalatitude")]
        public double LatLocation { get; set; }

        [Display(Name = "Longitude")]
        public double LngLocation { get; set; }

        public bool IsApproved { get; set; }

        [Required]
        [Display(Name = "Pet Types")]
        public IEnumerable<PetType> PetTypes { get; set; }

        public IFormFile Image { get; set; }

        public string Note { get; set; }

        [MinLength(PicUrlMinLength)]
        [MaxLength(PicUrlMaxLength)]
        [Display(Name = "Picture URL")]
        public string PicUrl { get; set; }
    }
}
