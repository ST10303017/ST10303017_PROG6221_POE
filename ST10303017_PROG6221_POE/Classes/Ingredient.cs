/// <summary>
/// Calwyn Govender
/// ST10303017
/// (Troelsen & Japikse, 2022)
/// (Chand, 2018)
/// (W3Schools, 2024)
/// -----------------------------------------------------------------------------------------------------------
using System;

namespace ST10303017_PROG6221_POE.Classes
{
    // Represents an ingredient with its details such as name, quantity, measurement, calories, and food group.
    public class Ingredient
    {
        // Name of the ingredient
        public string ingredientName { get; set; }

        // Quantity of the ingredient
        public double ingredientQuantity { get; set; }

        // Unit of measurement for the ingredient
        public string ingredientMeasurement { get; set; }

        // Original quantity of the ingredient before scaling
        public double originalQuantity { get; set; }

        // Calories of the ingredient
        public double ingredientCalories { get; set; }

        // Food group of the ingredient
        public string ingredientFoodGroup { get; set; }

        // Constructor to initialize an ingredient with specified details
        public Ingredient(string ingredientName, double ingredientQuantity, string ingredientMeasurement, double originalQuantity, double calories, string foodGroup)
        {
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.ingredientMeasurement = ingredientMeasurement;
            this.originalQuantity = originalQuantity;
            ingredientCalories = calories;
            ingredientFoodGroup = foodGroup;
        }
    }
}
