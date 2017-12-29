﻿namespace PawGuide.Services.Publications.Models
{
    using Common.Mapping;
    using Data.Models;
    using System;
    using AutoMapper;

    public class AdListingServiceModel : IMapFrom<Ad>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PicUrl { get; set; }

        public bool IsApproved { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Ad, AdListingServiceModel>()
                .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
