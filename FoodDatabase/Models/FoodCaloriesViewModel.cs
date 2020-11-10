using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodDatabase.Models
{
    public class FoodCaloriesViewModel
    {
        public List<FoodItem> FoodItems;
        public SelectList Calories;
        public string FoodItemCalories { get; set; }
        public string FoodItemCarbs { get; set; }
        public string FoodItemLipids { get; set; }
        public string SearchString { get; set; }
    }
}
