using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOneCatBa.Models;
using TheOneCatBa.Services;

namespace TheOneCatBa
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(cfg =>
            {
                cfg.Cookie.Name = "CB";
                cfg.IdleTimeout = new TimeSpan(1, 60, 0);
            });
            services.AddRazorPages();
            services.AddCors(options =>
            {
                options.AddPolicy("AnyCorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = long.MaxValue;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = long.MaxValue;
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = long.MaxValue;
            });
            services.AddControllersWithViews();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            EnviConfig.Config(this.Configuration);

            services.AddSingleton<TourService>();
            services.AddScoped<CloudbedsService>();
            services.AddSingleton<BlogService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Blog",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Rooms",
                    pattern: "{controller=Rooms}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Tour",
                    pattern: "{controller=Tour}/{action=Index}/{id?}");
            });
        }
    }
}
