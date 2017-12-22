namespace PawGuide.Web.Areas.Admin.Models.Businesses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using PawGuide.Data.Models;

    public class ApproveBusinessFormModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TypeBusiness Type { get; set; }

        public string City { get; set; }

        public double LatLocation { get; set; }

        public double LngLocation { get; set; }

        public PetType PetType { get; set; }

        public string PicUrl { get; set; }

        public string WebPageUrl { get; set; }

        public string Note { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsApproved { get; set; }

        public string Author { get; set; }

    }
}
