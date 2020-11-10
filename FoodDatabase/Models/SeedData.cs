using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoodDatabase.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FoodDatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FoodDatabaseContext>>()))
            {
                // Look for any Books.
                if (context.FoodItem.Any())
                {
                    return;   // DB has been seeded
                }

                context.FoodItem.AddRange(
                    new FoodItem
                    {
                        Title = "Banana",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Calories = 456.5,
                        Protein = 10,
                        Lipids = 4,
                        Carbs = 5
                    },

                    new FoodItem
                    {
                        Title = "Salmon",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Calories = 496.5,
                        Protein = 10,
                        Lipids = 4,
                        Carbs = 5
                    },

                    new FoodItem
                    {
                        Title = "Apple",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Calories = 458.5,
                        Protein = 10,
                        Lipids = 4,
                        Carbs = 5
                    },

                    new FoodItem
                    {
                        Title = "Bread1",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Calories = 457.5,
                        Protein = 10,
                        Lipids = 4,
                        Carbs = 5
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
