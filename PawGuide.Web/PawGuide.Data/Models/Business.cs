namespace PawGuide.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Business
    {
        public int Id { get; set; }

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

        public bool IsApproved { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
