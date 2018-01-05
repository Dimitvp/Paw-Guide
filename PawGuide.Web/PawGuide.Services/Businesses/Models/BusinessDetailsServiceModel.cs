namespace PawGuide.Services.Businesses.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using PawGuide.Common.Mapping;

    public class BusinessDetailsServiceModel : IMapFrom<Business>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TypeBusiness Type { get; set; }

        public string City { get; set; }

        [Display(Name = "Latitude")]
        public double LatLocation { get; set; }

        [Display(Name = "Longitude")]
        public double LngLocation { get; set; }

        [Display(Name = "Pet Type")]
        public PetType PetType { get; set; }

        [Display(Name = "URL for Picture")]
        public string PicUrl { get; set; }

        public string Address { get; set; }

        [Display(Name = "Web Page or Facebook")]
        public string WebPageUrl { get; set; }

        public string Note { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsApproved { get; set; }

        public string Author { get; set; }

        public string Image { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Business, BusinessListingServiceModel>()
                .ForMember(b => b.Author, cfg => cfg.MapFrom(b => b.Author.UserName));
    }
}
