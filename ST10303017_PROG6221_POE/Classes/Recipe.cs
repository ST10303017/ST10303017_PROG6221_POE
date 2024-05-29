using System;
using System.Collections.Generic;

namespace ST10303017_PROG6221_POE.Classes
{
    public class Recipe
    {
        // Delegate for notifying when total calories exceed 300
        public delegate void CaloriesExceededHandler(string recipeName, double totalCalories);
        public event CaloriesExceededHandler CaloriesExceeded;

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
                double calories;
                string foodGroup;

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

                double originalQuantity = ingredientQuantity;
                ingredients.Add(new Ingredient(ingredientName, ingredientQuantity, ingredientMeasurement, originalQuantity, calories, foodGroup));
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

        // Method to calculate total calories of the recipe
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.calories;
            }

            // Trigger the CaloriesExceeded event if the total calories exceed 300
            if (totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(recipeName, totalCalories);
            }

            return totalCalories;
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
                    Console.WriteLine($"Ingredient Name: {ingredient.ingredientName}");
                    Console.WriteLine($"Ingredient Quantity: {ingredient.ingredientQuantity}");
                    Console.WriteLine($"Unit of Measurement: {ingredient.ingredientMeasurement}");
                    Console.WriteLine($"Calories: {ingredient.calories}");
                    Console.WriteLine($"Food Group: {ingredient.foodGroup}\n");
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
    }
}
