namespace PawGuide.Services.Businesses.Models
{
    using Microsoft.AspNetCore.Http;
    using PawGuide.Data.Models;

    public class BusinessEditServiceModel
    {
        public string Name { get; set; }

        public TypeBusiness Type { get; set; }

        public string WebPageUrl { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public double LatLocation { get; set; }

        public double LngLocation { get; set; }

        public bool IsApproved { get; set; }

        public PetType PetType { get; set; }

        public string Note { get; set; }

        public string PicUrl { get; set; }
    }
}
