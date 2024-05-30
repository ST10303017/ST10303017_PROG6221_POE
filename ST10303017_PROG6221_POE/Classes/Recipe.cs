using System;
using System.Collections.Generic;

namespace ST10303017_PROG6221_POE.Classes
{
    public class Recipe
    {
        public delegate void CaloriesExceededHandler(string recipeName, double totalCalories);
        public event CaloriesExceededHandler CaloriesExceeded;

        public string RecipeName { get; private set; }
        public int NumIngredients { get; set; }

        private List<Ingredient> ingredients;
        private double originalQuantity;
        private int numOfSteps;
        private List<string> stepDescriptions;

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            stepDescriptions = new List<string>();
        }

        public void InputRecipe()
        {
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
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Invalid input, the recipe name cannot be empty. Please try again.");
                    }
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
                        NumIngredients = checkNumIngredients;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Invalid input, number of ingredients must be a positive integer. Please try again.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Ingredients: ");

            for (int i = 0; i < NumIngredients; i++)
            {
                string ingredientName;
                double ingredientQuantity;
                string ingredientMeasurement;
                double calories;
                string foodGroup;

                while (true)
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the name of the ingredient: ");
                        ingredientName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(ingredientName))
                            break;
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, ingredient name cannot be empty. Please try again.");
                        }
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
                        Console.Write("Enter the quantity of the ingredient: ");
                        string quantityInput = Console.ReadLine();
                        if (double.TryParse(quantityInput, out ingredientQuantity) && ingredientQuantity > 0)
                            break;
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, quantity must be a positive number. Please try again.");
                        }
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
                        Console.Write("Enter the ingredient unit of measurement: ");
                        ingredientMeasurement = Console.ReadLine();
                        if (!string.IsNullOrEmpty(ingredientMeasurement))
                            break;
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, the unit of measurement cannot be empty. Please try again.");
                        }
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
                        Console.Write("Enter the number of calories: ");
                        string caloriesInput = Console.ReadLine();
                        if (double.TryParse(caloriesInput, out calories) && calories >= 0)
                            break;
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, calories must be 0 or greater. Please try again.");
                        }
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
                        Console.Write("Enter the food group: ");
                        foodGroup = Console.ReadLine();
                        if (!string.IsNullOrEmpty(foodGroup))
                            break;
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, the food group cannot be empty. Please try again.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
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
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Invalid input. Please enter a number that is greater than 0");
                    }
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
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("The step description cannot be empty. Please try again.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            if (totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(RecipeName, totalCalories);
            }

            return totalCalories;
        }

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

            foreach (var ingredient in ingredients)
            {
                ingredient.IngredientQuantity *= scaleFactor;
            }
        }

        public void ResetIngredientQuantity()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.IngredientQuantity = ingredient.OriginalQuantity;
            }
        }

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
