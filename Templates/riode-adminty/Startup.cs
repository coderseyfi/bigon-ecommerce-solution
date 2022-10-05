using BigOn.WebUI.Models.DataContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BigOn.WebUI
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;   // json file larini oxuya bilmek uchun
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BigOnDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration["ConnectionStrings:cString"]);
            });

            services.AddRouting(cfg =>    // url lerin kichik herfle gorunmesi uchun
            {
                cfg.LowercaseUrls = true;   
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.SeedData();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapAreaControllerRoute("defaultAdmin", "admin", "admin/{controller=dashboard}/{action=index}/{id?}");  // for admin panel

                cfg.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

            });
        }
    }
}
