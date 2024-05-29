using System;
using System.Collections.Generic;

namespace ST10303017_PROG6221_POE.Classes
{
    public class Recipe
    {
        // Attributes for the Recipe class
        public string recipeName { get; private set; }
        public int numIngredients { get; set; }

        private List<Ingredient> ingredients; // List of Ingredient objects
        private double originalQuantity { get; set; }
        private int numOfSteps { get; set; }
        private List<string> stepDescriptions; // List for the step descriptions

        // Constructor for the Recipe class
        public Recipe()
        {
            ingredients = new List<Ingredient>();
            stepDescriptions = new List<string>();
        }

        // Method to input a recipe
        public void inputRecipe()
        {
            while (true)
            {
                try
                {
                    Console.ResetColor();
                    Console.Write("Enter the name of the recipe: ");
                    recipeName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(recipeName))
                        break;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    throw new ArgumentException("Invalid input, the recipe name cannot be empty. Please try again.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.ResetColor();
                    Console.Write("Enter the number of ingredients: ");
                    if (int.TryParse(Console.ReadLine(), out int checkNumIngredients) && checkNumIngredients > 0)
                    {
                        numIngredients = checkNumIngredients;
                        break;
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    throw new ArgumentException("Invalid input, number of ingredients must be greater than 0. Please try again");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Ingredients: ");

            for (int i = 0; i < numIngredients; i++)
            {
                string ingredientName;
                double ingredientQuantity;
                string ingredientMeasurement;

                while (true)
                {
                    Console.ResetColor();
                    Console.Write("Enter the name of the ingredient: ");
                    ingredientName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(ingredientName))
                        break;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input, ingredient name cannot be empty. Please try again.");
                }

                while (true)
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the quantity of the ingredient: ");
                        string quantityInput = Console.ReadLine();
                        if (double.TryParse(quantityInput, out ingredientQuantity) && ingredientQuantity > 0)
                            break;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Invalid input, quantity must be greater than 0. Please try again");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                while (true)
                {
                    Console.ResetColor();
                    Console.Write("Enter the ingredient unit of measurement: ");
                    ingredientMeasurement = Console.ReadLine();
                    if (!string.IsNullOrEmpty(ingredientMeasurement))
                        break;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input, the unit of measurement cannot be empty. Please try again.");
                }

                double originalQuantity = ingredientQuantity;
                ingredients.Add(new Ingredient(ingredientName, ingredientQuantity, ingredientMeasurement, originalQuantity));
            }

            while (true)
            {
                try
                {
                    Console.ResetColor();
                    Console.Write("Enter the number of steps: ");
                    if (int.TryParse(Console.ReadLine(), out int checkNumOfSteps) && checkNumOfSteps > 0)
                    {
                        numOfSteps = checkNumOfSteps;
                        break;
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    throw new ArgumentException("Invalid input. Please enter a number that is greater than 0");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            for (int j = 0; j < numOfSteps; j++)
            {
                while (true)
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the description of step " + (j + 1) + ": ");
                        string stepDescription = Console.ReadLine();
                        if (!string.IsNullOrEmpty(stepDescription))
                        {
                            stepDescriptions.Add(stepDescription);
                            break;
                        }
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("The step description cannot be empty. Please try again.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        // Method to display a recipe
        public void displayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("RECIPE NAME: " + recipeName);
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Number of Ingredients: " + numIngredients);
            Console.WriteLine("Ingredients: ");
            foreach (Ingredient ingredient in ingredients)
            {
                if (ingredient != null)
                {
                    Console.WriteLine($"Ingredient Name: {ingredient.ingredientName}\nIngredient Quantity: {ingredient.ingredientQuantity}\nUnit of Measurement: {ingredient.ingredientMeasurement}\n");
                }
            }
            Console.WriteLine("Number of Steps: " + numOfSteps);
            for (int j = 0; j < numOfSteps; j++)
            {
                Console.WriteLine($"Step {j + 1}: {stepDescriptions[j]}");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();
        }

        // Method to scale a recipe
        public void scaleRecipe()
        {
            double scaleFactor = 0;
            bool validScaleFactor = false;
            while (!validScaleFactor)
            {
                Console.Write("Enter the scale factor (0.5, 2, or 3): ");
                string scaleInput = Console.ReadLine();

                if (double.TryParse(scaleInput, out scaleFactor) && (scaleFactor == 0.5 || scaleFactor == 2 || scaleFactor == 3))
                {
                    validScaleFactor = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3 for the factor");
                }
            }

            foreach (var ingredient in ingredients)
            {
                ingredient.ingredientQuantity *= scaleFactor;
            }
        }

        // Method to reset the ingredient quantity
        public void resetIngredientQuantity()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.ingredientQuantity = ingredient.originalQuantity;
            }
        }

        // Method to clear the recipe
        public void clearRecipe()
        {
            recipeName = "";
            numIngredients = 0;
            numOfSteps = 0;
            ingredients.Clear();
            stepDescriptions.Clear();
        }

        // Method to display the recipe menu
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
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Ingredient Quantities");
                Console.WriteLine("5. Clear Recipe");
                Console.WriteLine("6. Exit Manager");
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
                        inputRecipe();
                        break;
                    case "2":
                        displayRecipe();
                        break;
                    case "3":
                        scaleRecipe();
                        break;
                    case "4":
                        resetIngredientQuantity();
                        break;
                    case "5":
                        clearRecipe();
                        break;
                    case "6":
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
