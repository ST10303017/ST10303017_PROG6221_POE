using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10303017_PROG6221_POE.Classes
{
    // Manages a collection of recipes and provides methods to add, display, and select recipes.
    public class RecipeManager
    {
        // List to store all recipes
        private List<Recipe> recipes;

        // Constructor to initialize the RecipeManager class
        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        // Method to add a recipe to the collection
        public void AddRecipe(Recipe recipe)
        {
            // Subscribe to the CaloriesExceeded event
            recipe.CaloriesExceeded += OnCaloriesExceeded;
            recipes.Add(recipe);
        }

        // Method to display all recipes in alphabetical order
        public void DisplayRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            // Sort recipes by name in alphabetical order
            var sortedRecipes = recipes.OrderBy(r => r.RecipeName).ToList();

            Console.WriteLine("Recipes in alphabetical order:");
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.RecipeName);
            }
        }

        // Method to select a recipe by name
        public Recipe SelectRecipe(string name)
        {
            // Find the recipe by name (case-insensitive)
            return recipes.FirstOrDefault(r => r.RecipeName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Method to display the details of a selected recipe
        public void DisplayRecipeDetails()
        {
            Console.Write("Enter the name of the recipe to display: ");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = SelectRecipe(recipeName);
            if (selectedRecipe != null)
            {
                selectedRecipe.DisplayRecipe();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Recipe not found.");
                Console.ResetColor();
            }
        }

        // Event handler for when calories exceed 300
        private void OnCaloriesExceeded(string recipeName, double totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Warning: The total calories for the recipe '{recipeName}' exceed 300. Total Calories: {totalCalories}");
            Console.ResetColor();
        }

        // Method to display the recipe manager menu
        public void RecipeMenu()
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
                        recipe.InputRecipe();
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
