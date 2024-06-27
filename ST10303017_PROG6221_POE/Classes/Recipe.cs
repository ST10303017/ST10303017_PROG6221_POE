/// <summary>
/// Calwyn Govender
/// ST10303017
/// (Troelsen & Japikse, 2022)
/// (Chand, 2018)
/// (W3Schools, 2024)
/// -----------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace ST10303017_PROG6221_POE.Classes
{
    // The Recipe class
    // This class represents a recipe with its name, ingredients, and step descriptions.
    // It provides methods to calculate total calories, clear the recipe, reset ingredient quantities, and scale the recipe.
    //-----------------------------------------------------------------------------------------------------------//
    public class Recipe
    {
        // Delegate for the CaloriesExceeded event
        public delegate void CaloriesExceededHandler(string recipeName, double totalCalories);

        // Event for when the total calories exceed 300
        public event CaloriesExceededHandler CaloriesExceeded;

        // Properties for the Recipe class
        // RecipeName: The name of the recipe
        // Ingredients: The list of ingredients in the recipe
        // StepDescriptions: The list of step descriptions in the recipe
        //---------------------------------------------------------------------------------------------------//
        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> StepDescriptions { get; set; }
        //---------------------------------------------------------------------------------------------------//

        // The Recipe constructor
        // Initializes a new instance of the Recipe class
        //---------------------------------------------------------------------------------------------------//
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            StepDescriptions = new List<string>();
        }
        //---------------------------------------------------------------------------------------------------//

        // The TotalCalories property
        // Calculates and returns the total calories of the recipe
        //---------------------------------------------------------------------------------------------------//
        public double TotalCalories
        {
            get
            {
                return CalculateTotalCalories();
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to calculate total calories
        // Iterates through the list of ingredients and sums up the calories
        // If the total calories exceed 300, the CaloriesExceeded event is triggered
        // Returns the total calories
        //---------------------------------------------------------------------------------------------------//
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.ingredientCalories;
            }

            if (totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(RecipeName, totalCalories);
            }

            return totalCalories;
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to clear the recipe
        // Clears the recipe name, ingredients, and step descriptions
        //---------------------------------------------------------------------------------------------------//
        public void clearRecipe()
        {
            RecipeName = string.Empty;
            Ingredients.Clear();
            StepDescriptions.Clear();
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to reset ingredient quantities
        // Resets the quantity of each ingredient to its original quantity
        //---------------------------------------------------------------------------------------------------//
        public void resetIngredientQuantity()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ingredientQuantity = ingredient.originalQuantity;
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to scale the recipe
        // Takes a scale factor as a parameter
        // Scales the quantity of each ingredient by the scale factor
        //---------------------------------------------------------------------------------------------------//
        public void scaleRecipe(double scaleFactor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ingredientQuantity *= scaleFactor;
            }
        }
        //---------------------------------------------------------------------------------------------------//
    }
    //---------------------------------------------------------------------------------------------------//
}
//---------------------------------------------------------------------------------------------------//
