using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using MvcMovie.Data;
using ProjEventWeb;
using System;
using System.Linq;

namespace ProjEventWeb.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjEventDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProjEventDbContext>>()))
            {
                // Look for any movies.
                if (context.Events.Any())
                {
                    return;   // DB has been seeded
                }

                context.Events.AddRange(
                    new Event
                    {
                        Description = "TDC Porto Alegre",
                        Date = DateTime.Parse("2019-10-12"),
                        Details = "Technology Event",
                        Price = 7.99M
                    },
                    new Event {
                        Description = "TDC Florianópolis",
                        Date = DateTime.Parse("2019-10-13"),
                        Details = "Technology Event",
                        Price = 10.99M
                    }                     
                );
                context.SaveChanges();
            }
        }
    }
}