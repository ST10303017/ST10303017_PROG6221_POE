﻿/// <summary>
/// Calwyn Govender
/// ST10303017
/// 
/// This class is used to create a recipe object. The recipe object will have the following attributes:
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//-----------------------------------------------------------------------------------------------------------//
namespace ST10303017_PROG6221_POE.Classes

    //-----------------------------------------------------------------------------------------------------------//
    public class Recipe
    {
        public string recipeName { get; private set; }
        public int numIngredients { get; set; }

        private Ingredient[] ingredients; 
        private double originalQuantity { get; set; }
        private int numOfSteps { get; set; }
        private string[] stepDescriptions { get; set; }

        //-----------------------------------------------------------------------------------------------------------//
        public Recipe()
        {
            ingredients = new Ingredient[numIngredients];
            stepDescriptions = new string[numOfSteps];
        }

        //-----------------------------------------------------------------------------------------------------------//
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
                        ingredients = new Ingredient[numIngredients];
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
                // Input for ingredient name
                string ingredientName;
                double ingredientQuantity;
                string ingredientMeasurement;

                // Input for ingredient name
                while (true)
                {
                    Console.ResetColor();
                    Console.Write("Enter the name of the ingredient: ");
                    ingredientName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(ingredientName))
                        break; // Valid input, break the loop
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input, ingredient name cannot be empty. Please try again.");
                }

                // Input for ingredient quantity
                while (true)
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the quantity of the ingredient: ");
                        string quantityInput = Console.ReadLine();
                        if (double.TryParse(quantityInput, out ingredientQuantity) && ingredientQuantity > 0)
                            break; // Valid input, break the loop
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, quantity must be greater than 0. Please try again");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message); // Prints error message if input is invalid
                    }
                }

                // Input for ingredient unit of measurement
                while (true)
                {
                    Console.ResetColor();
                    Console.Write("Enter the ingredient unit of measurement: ");
                    ingredientMeasurement = Console.ReadLine();
                    if (!string.IsNullOrEmpty(ingredientMeasurement))
                        break; // Valid input, break the loop
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input, the unit of measurement cannot be empty. Please try again.");
                }

                // Create the ingredient object with the originalQuantity set to the ingredientQuantity
                double originalQuantity = ingredientQuantity; // This should ideally be handled inside the Ingredient class
                ingredients[i] = new Ingredient(ingredientName, ingredientQuantity, ingredientMeasurement, originalQuantity);

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
                        stepDescriptions = new string[numOfSteps];
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
                while(true)
                {   
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the description of step " + (j + 1) + ": ");
                        stepDescriptions[j] = Console.ReadLine();
                        if (!string.IsNullOrEmpty(stepDescriptions[j]))
                            break;
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

        public void displayRecipe()
        {
            Recipe recipe = new Recipe();
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

        public void scaleRecipe()
        {
            double scaleFactor = 0;
            bool validScale = false;
            while (!validScale)
            {
                Console.Write("Enter the scale factor (0.5, 2, or 3): ");
                string scaleInput = Console.ReadLine();

                if (double.TryParse(scaleInput, out scaleFactor) && (scaleFactor == 0.5 || scaleFactor == 2 || scaleFactor == 3))
                {
                    validScale = true; 
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3 for the factor");
                }
            }

            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].ingredientQuantity = ingredients[i].ingredientQuantity*scaleFactor;
            }
        }


        public void resetIngredientQuantity()
        {
            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].ingredientQuantity = ingredients[i].originalQuantity;
            }
        }

        public void clearRecipe()
        {
            recipeName = "";
            numIngredients = 0;
            numOfSteps = 0;
            ingredients = new Ingredient[0]; 
            stepDescriptions = new string[0]; 
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
                };
            }
        }
    }
}
