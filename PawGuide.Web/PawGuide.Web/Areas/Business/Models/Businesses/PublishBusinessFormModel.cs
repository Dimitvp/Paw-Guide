namespace PawGuide.Web.Areas.Business.Models.Businesses
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    using static Data.DataConstants;

    public class PublishBusinessFormModel
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

        [Required]
        public PetType PetType { get; set; }

        public string Note { get; set; }

        [MinLength(PicUrlMinLength)]
        [MaxLength(PicUrlMaxLength)]
        public string PicUrl { get; set; }
    }
}
