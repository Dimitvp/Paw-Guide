namespace PawGuide.Web.Areas.Publications.Models.Articles
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class PublishArticleFormModel
    {
        [Required]
        [MinLength(PublicationTitleMinLength)]
        [MaxLength(PublicationTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string PicUrl { get; set; }
    }
}