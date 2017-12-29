namespace PawGuide.Services.Businesses.Models
{
    using System;
    using AutoMapper;
    using Data.Models;

    public class BusinessDetailsServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TypeBusiness Type { get; set; }

        public string City { get; set; }

        public double LatLocation { get; set; }

        public double LngLocation { get; set; }

        public PetType PetType { get; set; }

        public string PicUrl { get; set; }

        public string Address { get; set; }

        public string WebPageUrl { get; set; }

        public string Note { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsApproved { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Business, BusinessListingServiceModel>()
                .ForMember(b => b.Author, cfg => cfg.MapFrom(b => b.Author.UserName));
    }
}
