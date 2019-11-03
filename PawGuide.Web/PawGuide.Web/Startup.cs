namespace PawGuide.Web
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure.Extensions;

    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Http;
    using JavaScriptEngineSwitcher.ChakraCore;
    using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
    using React.AspNet;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PawGuideDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<PawGuideDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.

            services.AddAutoMapper(typeof(Startup));

            services.AddDomainServices();

            services.AddRouting(routing => routing.LowercaseUrls = true);

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                .AddChakraCore();


            services.AddAuthentication().AddFacebook(fo =>
            {
                fo.AppId = Configuration["Authentication:Facebook:AppId"];
                fo.AppSecret =
                    Configuration["Authentication:Facebook:AppSecret"];
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Initialise ReactJS.NET. Must be before static files.
            app.UseReact(config =>
            {
                // If you want to use server-side rendering of React components,
                // add all the necessary JavaScript files here. This includes
                // your components as well as all of their dependencies.
                // See http://reactjs.net/ for more information. Example:
                //config
                //    .AddScript("~/js/First.jsx")
                //    .AddScript("~/js/Second.jsx");

                // If you use an external build too (for example, Babel, Webpack,
                // Browserify or Gulp), you can improve performance by disabling
                // ReactJS.NET's version of Babel and loading the pre-transpiled
                // scripts. Example:
                //config
                //    .SetLoadBabel(false)
                //    .AddScriptWithoutTransform("~/Scripts/bundle.server.js");
            });


            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "business",
                //    template: "business/{id}/{name}",
                //    defaults: new { area = "Business", controller = "Businesses", action = "Details" });

                //routes.MapRoute(
                //    name: "publications",
                //    template: "publications/articles/{id}/{title}",
                //    defaults: new { area = "Publications", controller = "Articles", action = "Details" });

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
