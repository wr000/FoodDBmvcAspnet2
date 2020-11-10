using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodDatabase.Models;

namespace FoodDatabase.Models
{
    public class FoodDatabaseContext : DbContext
    {
        public FoodDatabaseContext(DbContextOptions<FoodDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<FoodDatabase.Models.FoodItem> FoodItem { get; set; }
    }
}
