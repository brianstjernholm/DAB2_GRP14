using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAB2.Data;
using DAB2.Models;

namespace DAB2.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new HelpContext(serviceProvider.GetRequiredService<DbContextOptions<HelpContext>>()))
            {
                // Look for any movies.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                context.Students.AddRange(new StudentModel
                {
                    Name = "Victor"
                },

                new StudentModel
                {
                    Name = "Lasse"
                },

                new StudentModel
                {
                    Name = "Brian"
                }
                
                
                
                );
                context.SaveChanges();
            }
        }
    }
}
