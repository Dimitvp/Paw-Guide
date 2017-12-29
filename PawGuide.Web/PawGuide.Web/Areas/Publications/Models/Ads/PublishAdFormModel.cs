namespace PawGuide.Web.Areas.Publications.Models.Ads
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class PublishAdFormModel
    {
        [Required]
        [MinLength(PublicationTitleMinLength)]
        [MaxLength(PublicationTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [MinLength(PicUrlMinLength)]
        [MaxLength(PicUrlMaxLength)]
        public string PicUrl { get; set; }
    }
}
