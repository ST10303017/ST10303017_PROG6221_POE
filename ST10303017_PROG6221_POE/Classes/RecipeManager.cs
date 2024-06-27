using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ST10303017_PROG6221_POE.Classes
{
    public class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void addRecipe(Recipe recipe)
        {
            recipe.CaloriesExceeded += onCaloriesExceeded;
            recipes.Add(recipe);
            DisplayCalorieAlert(recipe.CalculateTotalCalories());
        }

        public List<Recipe> GetRecipes()
        {
            return recipes;
        }

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

        public void ClearRecipe(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.clearRecipe();
            }
        }

        public void ResetQuantities(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.resetIngredientQuantity();
            }
        }

        public void ScaleQuantities(string recipeName, double scaleFactor)
        {
            var recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.scaleRecipe(scaleFactor);
            }
        }

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
    }
}
