using System;
using System.Collections.Generic;
using System.Linq;

// Namespace for the RecipeManager class
//-----------------------------------------------------------------------------------------------------------//
namespace ST10303017_PROG6221_POE.Classes
{
    // RecipeManager class
    // The RecipeManager class manages a collection of recipes.
    // It contains methods to add, display, select, and manage recipes.
    //-----------------------------------------------------------------------------------------------------------//
    public class RecipeManager
    {
        // Attributes for the RecipeManager class
        // The list of recipes managed by the RecipeManager
        private List<Recipe> recipes;

        // Constructor for the RecipeManager class
        // Initializes a new instance of the RecipeManager class with an empty list of recipes
        //-----------------------------------------------------------------------------------------------------------//
        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Method to add a recipe to the list
        // This method adds a recipe to the list and subscribes to the CaloriesExceeded event
        //-----------------------------------------------------------------------------------------------------------//
        public void addRecipe(Recipe recipe)
        {
            // Subscribe to the CaloriesExceeded event
            recipe.CaloriesExceeded += onCaloriesExceeded;
            recipes.Add(recipe);
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Method to display all recipes
        // This method displays the names of all recipes in alphabetical order
        //-----------------------------------------------------------------------------------------------------------//
        public void displayRecipes()
        {
            // Check if there are any recipes
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }
            // Sort the recipes by name
            var sortedRecipes = recipes.OrderBy(r => r.RecipeName).ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("RECIPES IN ALPHABETICAL ORDER");
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();
            // Display the names of the recipes
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.RecipeName);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Method to select a recipe by name
        // This method returns a recipe object if it matches the provided name
        //-----------------------------------------------------------------------------------------------------------//
        public Recipe chooseRecipe(string name)
        {
            // Find the recipe with the specified name
            return recipes.FirstOrDefault(r => r.RecipeName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Method to display the details of a selected recipe
        // This method prompts the user to enter the name of the recipe to display and displays its details
        //-----------------------------------------------------------------------------------------------------------//
        public void displayRecipeDetails()
        {
            Console.Write("Enter the name of the recipe to display: ");
            string recipeName = Console.ReadLine();
            // Select the recipe by name
            Recipe selectedRecipe = chooseRecipe(recipeName);
            // Display the recipe details
            if (selectedRecipe != null)
            {
                selectedRecipe.displayRecipe();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Recipe was not found.");
                Console.ResetColor();
            }
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Event handler for the CaloriesExceeded event
        // This method displays a warning message when the total calories of a recipe exceed 300
        //-----------------------------------------------------------------------------------------------------------//
        private void onCaloriesExceeded(string recipeName, double totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Warning: The total calories for the recipe '{recipeName}' exceed 300. Total Calories: {totalCalories}");
            Console.ResetColor();
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Method to display the recipe manager menu
        // This method displays the recipe manager menu with options to create, display, scale, reset, clear a recipe, and exit the manager
        // The method uses a switch statement to call the corresponding methods
        //-----------------------------------------------------------------------------------------------------------//
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
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Ingredient Quantities");
                Console.WriteLine("6. Clear Recipe");
                Console.WriteLine("7. Exit Manager");
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
                        addRecipe(recipe);
                        break;
                    case "2":
                        displayRecipes();
                        break;
                    case "3":
                        displayRecipeDetails();
                        break;
                    case "4":
                        Console.Write("Enter the name of the recipe to scale: ");
                        string recipeNameToScale = Console.ReadLine();
                        Recipe recipeToScale = chooseRecipe(recipeNameToScale);
                        // Scale the recipe
                        if (recipeToScale != null)
                        {
                            recipeToScale.scaleRecipe();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Recipe not found.");
                            Console.ResetColor();
                        }
                        break;
                    case "5":
                        Console.Write("Enter the name of the recipe to reset quantities: ");
                        string recipeNameToReset = Console.ReadLine();
                        Recipe recipeToReset = chooseRecipe(recipeNameToReset);
                        // Reset the ingredient quantities
                        if (recipeToReset != null)
                        {
                            recipeToReset.resetIngredientQuantity();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Recipe not found.");
                            Console.ResetColor();
                        }
                        break;
                    case "6":
                        Console.Write("Enter the name of the recipe to clear: ");
                        string recipeNameToClear = Console.ReadLine();
                        Recipe recipeToClear = chooseRecipe(recipeNameToClear);
                        if (recipeToClear != null)
                        {
                            recipeToClear.clearRecipe();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Recipe not found.");
                            Console.ResetColor();
                        }
                        break;
                    case "7":
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
        //-----------------------------------------------------------------------------------------------------------//
    }
    //-----------------------------------------------------------------------------------------------------------//
}
//-----------------------------------------------------------------------------------------------------------//
