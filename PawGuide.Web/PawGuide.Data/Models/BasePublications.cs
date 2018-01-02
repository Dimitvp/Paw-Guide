namespace PawGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public abstract class BasePublications
    {
        public int Id { get; set; }

        [Required]
        [MinLength(PublicationTitleMinLength)]
        [MaxLength(PublicationTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [MinLength(PicUrlMinLength)]
        [MaxLength(PicUrlMaxLength)]
        public string PicUrl { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
