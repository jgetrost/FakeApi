using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shuttle.Controllers;
using Shuttle.Models;

namespace Shuttle
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            PeopleController.People = new List<Person>();

            PeopleController.People.Add(new Person {
                Id = 1,
                FirstName = "James",
                LastName = "Getrost",
                DateOfBirth = new DateTime(1995, 10, 10),
                FavoriteNumber = 21,
            });

            PeopleController.People.Add(new Person {
                Id = 2,
                FirstName = "Steven",
                LastName = "Schoonover",
                DateOfBirth = new DateTime(1990, 9, 27),
                FavoriteNumber = 22,
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Docs/Default/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "docs",
                    pattern: "docs/{controller}/{action}/{version?}",
                        defaults: new { controller = "Default", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "api/{area}/{controller}/{action}/{version?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });
        }
    }
}
