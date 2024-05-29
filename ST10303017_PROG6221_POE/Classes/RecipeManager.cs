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

        public void AddRecipe(Recipe recipe)
        {
            recipe.CaloriesExceeded += OnCaloriesExceeded;
            recipes.Add(recipe);
        }

        public void DisplayRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.recipeName).ToList();

            Console.WriteLine("Recipes in alphabetical order:");
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.recipeName);
            }
        }

        public Recipe SelectRecipe(string name)
        {
            return recipes.FirstOrDefault(r => r.recipeName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void DisplayRecipeDetails()
        {
            Console.Write("Enter the name of the recipe to display: ");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = SelectRecipe(recipeName);
            if (selectedRecipe != null)
            {
                selectedRecipe.displayRecipe();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Recipe not found.");
                Console.ResetColor();
            }
        }

        private void OnCaloriesExceeded(string recipeName, double totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Warning: The total calories for the recipe '{recipeName}' exceed 300. Total Calories: {totalCalories}");
            Console.ResetColor();
        }

        public void recipeMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("WELCOME TO THE RECIPE MANAGER");
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
                Console.WriteLine("1. Create Recipe");
                Console.WriteLine("2. Display All Recipes");
                Console.WriteLine("3. Display Recipe");
                Console.WriteLine("4. Exit Manager");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
                Console.Write("Please choose one of the above options: ");
                string choice = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
                switch (choice)
                {
                    case "1":
                        Recipe recipe = new Recipe();
                        recipe.inputRecipe();
                        AddRecipe(recipe);
                        break;
                    case "2":
                        DisplayRecipes();
                        break;
                    case "3":
                        DisplayRecipeDetails();
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Exiting Recipe Manager...");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input, please choose one of the options");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
