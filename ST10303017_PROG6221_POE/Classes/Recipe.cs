using System;
using System.Collections.Generic;

namespace ST10303017_PROG6221_POE.Classes
{
    // Represents a recipe with its name, ingredients, steps, and methods to manage the recipe.
    public class Recipe
    {
        // Delegate for notifying when total calories exceed 300
        public delegate void CaloriesExceededHandler(string recipeName, double totalCalories);

        // Event triggered when total calories exceed 300
        public event CaloriesExceededHandler CaloriesExceeded;

        // Name of the recipe
        public string RecipeName { get; private set; }

        // Number of ingredients in the recipe
        public int NumIngredients { get; set; }

        // List of ingredients in the recipe
        private List<Ingredient> ingredients;

        // Original quantity of ingredients
        private double originalQuantity;

        // Number of steps in the recipe
        private int numOfSteps;

        // List of step descriptions
        private List<string> stepDescriptions;

        // Constructor to initialize the Recipe class
        public Recipe()
        {
            ingredients = new List<Ingredient>();
            stepDescriptions = new List<string>();
        }

        // Method to input a recipe
        public void InputRecipe()
        {
            // Loop to get the recipe name
            while (true)
            {
                try
                {
                    Console.ResetColor();
                    Console.Write("Enter the name of the recipe: ");
                    RecipeName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(RecipeName))
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

            // Loop to get the number of ingredients
            while (true)
            {
                try
                {
                    Console.ResetColor();
                    Console.Write("Enter the number of ingredients: ");
                    if (int.TryParse(Console.ReadLine(), out int checkNumIngredients) && checkNumIngredients > 0)
                    {
                        NumIngredients = checkNumIngredients;
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

            // Loop to get the details of each ingredient
            for (int i = 0; i < NumIngredients; i++)
            {
                string ingredientName;
                double ingredientQuantity;
                string ingredientMeasurement;
                double calories;
                string foodGroup;

                // Loop to get the ingredient name
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

                // Loop to get the ingredient quantity
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

                // Loop to get the ingredient unit of measurement
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

                // Loop to get the calories for the ingredient
                while (true)
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the number of calories: ");
                        string caloriesInput = Console.ReadLine();
                        if (double.TryParse(caloriesInput, out calories) && calories >= 0)
                            break;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Invalid input, calories must be 0 or greater. Please try again");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                // Loop to get the food group for the ingredient
                while (true)
                {
                    Console.ResetColor();
                    Console.Write("Enter the food group: ");
                    foodGroup = Console.ReadLine();
                    if (!string.IsNullOrEmpty(foodGroup))
                        break;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input, the food group cannot be empty. Please try again.");
                }

                // Add the ingredient to the list
                double originalQuantity = ingredientQuantity;
                ingredients.Add(new Ingredient(ingredientName, ingredientQuantity, ingredientMeasurement, originalQuantity, calories, foodGroup));
            }

            // Loop to get the number of steps
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

            // Loop to get the description of each step
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

        // Method to calculate total calories of the recipe
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            // Trigger the CaloriesExceeded event if the total calories exceed 300
            if (totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(RecipeName, totalCalories);
            }

            return totalCalories;
        }

        // Method to display a recipe
        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("RECIPE NAME: " + RecipeName);
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Number of Ingredients: " + NumIngredients);
            Console.WriteLine("Ingredients: ");
            foreach (Ingredient ingredient in ingredients)
            {
                if (ingredient != null)
                {
                    Console.WriteLine($"Ingredient Name: {ingredient.IngredientName}");
                    Console.WriteLine($"Ingredient Quantity: {ingredient.IngredientQuantity}");
                    Console.WriteLine($"Unit of Measurement: {ingredient.IngredientMeasurement}");
                    Console.WriteLine($"Calories: {ingredient.Calories}");
                    Console.WriteLine($"Food Group: {ingredient.FoodGroup}\n");
                }
            }
            double totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");
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
        public void ScaleRecipe()
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

            // Scale the quantity of each ingredient
            foreach (var ingredient in ingredients)
            {
                ingredient.IngredientQuantity *= scaleFactor;
            }
        }

        // Method to reset the ingredient quantity
        public void ResetIngredientQuantity()
        {
            // Reset the quantity of each ingredient to its original quantity
            foreach (var ingredient in ingredients)
            {
                ingredient.IngredientQuantity = ingredient.OriginalQuantity;
            }
        }

        // Method to clear the recipe
        public void ClearRecipe()
        {
            RecipeName = "";
            NumIngredients = 0;
            numOfSteps = 0;
            ingredients.Clear();
            stepDescriptions.Clear();
        }
    }
}
