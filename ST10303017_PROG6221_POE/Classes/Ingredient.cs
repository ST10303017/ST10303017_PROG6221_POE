using System;

namespace ST10303017_PROG6221_POE.Classes
{
    // Represents an ingredient with its details such as name, quantity, measurement, calories, and food group.
    public class Ingredient
    {
        // Name of the ingredient
        public string IngredientName { get; set; }

        // Quantity of the ingredient
        public double IngredientQuantity { get; set; }

        // Unit of measurement for the ingredient
        public string IngredientMeasurement { get; set; }

        // Original quantity of the ingredient before scaling
        public double OriginalQuantity { get; set; }

        // Calories of the ingredient
        public double Calories { get; set; }

        // Food group of the ingredient
        public string FoodGroup { get; set; }

        // Constructor to initialize an ingredient with specified details
        public Ingredient(string ingredientName, double ingredientQuantity, string ingredientMeasurement, double originalQuantity, double calories, string foodGroup)
        {
            IngredientName = ingredientName;
            IngredientQuantity = ingredientQuantity;
            IngredientMeasurement = ingredientMeasurement;
            OriginalQuantity = originalQuantity;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}
