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

        // Constructor for the Ingredient class
        public Ingredient(string ingredientName, double ingredientQuantity, string ingredientMeasurement, double originalQuantity)
        {
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.ingredientMeasurement = ingredientMeasurement;
            this.originalQuantity = originalQuantity;
        }
    }
}
