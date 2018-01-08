namespace PawGuide.Services.Admin.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using AutoMapper;
    using PawGuide.Common.Mapping;
    using PawGuide.Data.Models;

    public class UserDetailsServiceModel : AdminUserListingServiceModel, IHaveCustomMapping
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public int BusinessesCount { get; set; }

        public int ArticlesCount { get; set; }

        public int AdsCount { get; set; }

        public IEnumerable<string> Roles { get; set; }


        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsServiceModel>()
                .ForMember(udm => udm.BusinessesCount, cfg => cfg.MapFrom(u => u.Businesses.Count));

            profile.CreateMap<User, UserDetailsServiceModel>()
                .ForMember(udm => udm.ArticlesCount, cfg => cfg.MapFrom(u => u.Ads.Count));

            profile.CreateMap<User, UserDetailsServiceModel>()
                .ForMember(udm => udm.AdsCount, cfg => cfg.MapFrom(u => u.Articles.Count));
        }
    }
}
