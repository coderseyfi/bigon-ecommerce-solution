using BigOn.Domain.Models.DataContexts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BigOn.WebApi
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<BigOnDbContext>(cfg=>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });

            var relatedAssembly = Assembly.LoadFrom("bin/Debug/net5.0/BigOn.Domain.dll");

         var asemblies = AppDomain.CurrentDomain.GetAssemblies().AsEnumerable().Where(a => a.FullName.StartsWith("BigOn."));

            services.AddMediatR(asemblies.ToArray());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//dev muhitinde probler varsa onlari gostersin
            }

            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }
    }
}
