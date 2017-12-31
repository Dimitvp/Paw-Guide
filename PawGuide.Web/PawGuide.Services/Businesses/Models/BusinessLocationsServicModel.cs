namespace PawGuide.Services.Businesses.Models
{
    using PawGuide.Data.Models;

    public class BusinessLocationsServicModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TypeBusiness Type { get; set; }

        public string City { get; set; }

        public double LatLocation { get; set; }

        public double LngLocation { get; set; }

        public PetType PetType { get; set; }

        public string PicUrl { get; set; }
    }
}
