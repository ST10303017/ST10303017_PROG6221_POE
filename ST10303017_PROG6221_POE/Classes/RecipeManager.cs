/// <summary>
/// Calwyn Govender
/// ST10303017
/// (Troelsen & Japikse, 2022)
/// (Chand, 2018)
/// (W3Schools, 2024)
/// -----------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

// The namespace for the RecipeManager class
namespace ST10303017_PROG6221_POE.Classes
{
    // The RecipeManager class
    // This class manages a collection of recipes and provides methods to manipulate and filter them.
    //-----------------------------------------------------------------------------------------------------------//
    public class RecipeManager
    {
        // The list of recipes
        private List<Recipe> recipes;

        // The RecipeManager constructor
        // Initializes a new instance of the RecipeManager class.
        //---------------------------------------------------------------------------------------------------//
        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to add a recipe
        // Takes a Recipe object as a parameter
        // Adds the recipe to the list of recipes
        // Subscribes to the CaloriesExceeded event of the recipe
        // Calls the DisplayCalorieAlert method
        //---------------------------------------------------------------------------------------------------//
        public void addRecipe(Recipe recipe)
        {
            recipe.CaloriesExceeded += onCaloriesExceeded;
            recipes.Add(recipe);
            DisplayCalorieAlert(recipe.CalculateTotalCalories());
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to get all recipes
        // Returns a list of all recipes
        //---------------------------------------------------------------------------------------------------//
        public List<Recipe> GetRecipes()
        {
            return recipes;
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to filter recipes
        // Takes ingredient, foodGroup, and maxCalories as parameters
        // Returns a filtered list of recipes based on the parameters
        //---------------------------------------------------------------------------------------------------//
        public List<Recipe> FilterRecipes(string ingredient, string foodGroup, double maxCalories)
        {
            var filteredRecipes = recipes.AsQueryable();

            if (!string.IsNullOrEmpty(ingredient))
            {
                filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Any(i => i.ingredientName.IndexOf(ingredient, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            if (foodGroup != "All")
            {
                filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Any(i => i.ingredientFoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase)));
            }

            filteredRecipes = filteredRecipes.Where(r => r.CalculateTotalCalories() <= maxCalories);

            return filteredRecipes.ToList();
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to clear a recipe
        // Takes the recipe name as a parameter
        // Clears the specified recipe
        //---------------------------------------------------------------------------------------------------//
        public void ClearRecipe(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.clearRecipe();
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to reset ingredient quantities
        // Takes the recipe name as a parameter
        // Resets the quantities of ingredients in the specified recipe
        //---------------------------------------------------------------------------------------------------//
        public void ResetQuantities(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.resetIngredientQuantity();
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to scale ingredient quantities
        // Takes the recipe name and scale factor as parameters
        // Scales the quantities of ingredients in the specified recipe by the scale factor
        //---------------------------------------------------------------------------------------------------//
        public void ScaleQuantities(string recipeName, double scaleFactor)
        {
            var recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.scaleRecipe(scaleFactor);
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The event handler for calories exceeded
        // Takes the recipe name and total calories as parameters
        // Displays a message when the total calories exceed 300
        //---------------------------------------------------------------------------------------------------//
        private void onCaloriesExceeded(string recipeName, double totalCalories)
        {
            string message = $"The total calories for the recipe '{recipeName}' exceed 300. Total Calories: {totalCalories}";

            if (totalCalories < 200)
            {
                message += "\nThis recipe is low in calories, suitable for a snack.";
            }
            else if (totalCalories >= 200 && totalCalories <= 500)
            {
                message += "\nThis recipe has moderate calories, suitable for a balanced meal.";
            }
            else if (totalCalories > 500)
            {
                message += "\nThis recipe is high in calories and should be consumed sparingly.";
            }

            MessageBox.Show(message, "Calorie Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to display calorie alert
        // Takes the total calories as a parameter
        // Displays a message with the total calories and its significance
        //---------------------------------------------------------------------------------------------------//
        private void DisplayCalorieAlert(double totalCalories)
        {
            string message = $"Total Calories: {totalCalories}";

            if (totalCalories < 200)
            {
                message += "\nThis recipe is low in calories, suitable for a snack.";
            }
            else if (totalCalories >= 200 && totalCalories <= 500)
            {
                message += "\nThis recipe has moderate calories, suitable for a balanced meal.";
            }
            else if (totalCalories > 500)
            {
                message += "\nThis recipe is high in calories and should be consumed sparingly.";
            }

            MessageBox.Show(message, "Calorie Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //---------------------------------------------------------------------------------------------------//
    }
    //---------------------------------------------------------------------------------------------------//
}
//---------------------------------------------------------------------------------------------------//
