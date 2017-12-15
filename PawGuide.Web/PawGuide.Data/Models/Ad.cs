namespace PawGuide.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Ad : BasePublications
    {
        [MinLength(PicUrlMinLength)]
        [MaxLength(PicUrlMaxLength)]
        public string PicUrl { get; set; }

        public bool IsApproved { get; set; }
    }
}
