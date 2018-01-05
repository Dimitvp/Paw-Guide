namespace PawGuide.Web.Areas.Business.Models.Businesses
{
    using Data.Models;
    using Common.Mapping;
    using Services.Businesses.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    using static Data.DataConstants;

    public class PublishBusinessFormModel : IMapFrom<BusinessDetailsServiceModel>
    {
        [Required]
        [MinLength(UserNameMinLength)]
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public TypeBusiness Type { get; set; }

        [MinLength(5)]
        [MaxLength(2000)]
        public string WebPageUrl { get; set; }

        [Required]
        [MinLength(CityMinLength)]
        [MaxLength(CityMaxLength)]
        public string City { get; set; }

        [Required]
        [MinLength(BusinessAddressMinLength)]
        [MaxLength(BusinessAddressMaxLength)]
        public string Address { get; set; }

        public double LatLocation { get; set; }

        public double LngLocation { get; set; }

        public bool IsApproved { get; set; }

        public IEnumerable<PetType> PetTypes { get; set; }

        public IFormFile Image { get; set; }

        public string Note { get; set; }

        [MinLength(PicUrlMinLength)]
        [MaxLength(PicUrlMaxLength)]
        public string PicUrl { get; set; }
    }
}
