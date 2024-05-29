using System;

namespace ST10303017_PROG6221_POE.Classes
{
    public class Ingredient
    {
        // Attributes of the Ingredient class
        public string ingredientName { get; set; }
        public double ingredientQuantity { get; set; }
        public string ingredientMeasurement { get; set; }
        public double originalQuantity { get; set; }
        public double calories { get; set; } // New attribute for calories
        public string foodGroup { get; set; } // New attribute for food group

        // Constructor for the Ingredient class
        public Ingredient(string ingredientName, double ingredientQuantity, string ingredientMeasurement, double originalQuantity, double calories, string foodGroup)
        {
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.ingredientMeasurement = ingredientMeasurement;
            this.originalQuantity = originalQuantity;
            this.calories = calories;
            this.foodGroup = foodGroup;
        }
    }
}
