namespace PawGuide.Services.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class UserListingServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public int Articles { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<User, UserListingServiceModel>()
                .ForMember(u => u.Articles, cfg => cfg.MapFrom(u => u.Articles.Count));
    }
}
