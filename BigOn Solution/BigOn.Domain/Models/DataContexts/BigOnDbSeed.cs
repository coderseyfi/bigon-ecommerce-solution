using BigOn.Domain.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BigOn.Domain.Models.DataContexts
{
    public static class BigOnDbSeed
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope()) // using de yaziriq ki oz ishini gorenden sonra memoryde yer tutmamaq uchun silinsin

            {
                var db = scope.ServiceProvider.GetRequiredService<BigOnDbContext>();

                db.Database.Migrate(); // update-database

                InitBrands(db);

            }

            return app;
        }

        private static void InitBrands(BigOnDbContext db)
        {
            if (!db.Brands.Any())
            {
                db.Brands.Add(new Brand
                {
                    Name = "Nike"
                });
                db.Brands.Add(new Brand
                {
                    Name = "Adidas"
                });

                db.SaveChanges();
            }
        }
    }
}
