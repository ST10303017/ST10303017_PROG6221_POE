using System;
using System.Collections.Generic;
using System.Linq;

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

        private void onCaloriesExceeded(string recipeName, double totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Warning: The total calories for the recipe '{recipeName}' exceed 300. Total Calories: {totalCalories}");
            Console.ResetColor();
        }
    }
}
