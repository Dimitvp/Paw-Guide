namespace PawGuide.Test
{
    using AutoMapper;
    using System;
    using Microsoft.EntityFrameworkCore;
    using PawGuide.Data;
    using PawGuide.Web.Infrastructure.Mapping;

    public class Tests
    {
        private static bool testInitialized = false;

        public static void Initialize()
        {
            if (!testInitialized)
            {
                //Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

                //var config = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<Source, Dest>();
                //});

                //IMapper mapper = config.CreateMapper();
                //var source = new Source();
                //var dest = mapper.Map<Source, Dest>(source);
                testInitialized = true;
            }
        }

        public static PawGuideDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<PawGuideDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new PawGuideDbContext(dbOptions);
        }
    }
}

