using System;
using System.ComponentModel.DataAnnotations;

namespace FoodDatabase.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        public double Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Lipids { get; set; }
    }
}
