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
{
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
            Console.Write("Enter the name of the recipe: ");
            recipeName = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            numIngredients = Convert.ToInt32(Console.ReadLine());
            ingredients = new Ingredient[numIngredients];

            Console.WriteLine("Ingredients: ");

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter the name of the ingredient: ");
                string ingredientName = Console.ReadLine();
                
                Console.Write("Enter the quantity of ingredients: ");
                double ingredientQuantity = Convert.ToInt32(Console.ReadLine());
                originalQuantity = ingredientQuantity;
         

                Console.Write("Enter the ingredient unit of measurement: ");
                string ingredientMeasurement = Console.ReadLine();

                ingredients[i] = new Ingredient(ingredientName, ingredientQuantity, ingredientMeasurement, originalQuantity);
            }
            Console.Write("Enter the number of steps: ");
            numOfSteps = Convert.ToInt32(Console.ReadLine());
            stepDescriptions = new string[numOfSteps];
            for (int j = 0; j < numOfSteps; j++)
            {
                Console.Write("Enter the description of step " + (j + 1) + ": ");
                stepDescriptions[j] = Console.ReadLine();
            }
        }

        public void displayRecipe()
        {
            Recipe recipe = new Recipe();
            Console.WriteLine("Recipe Name: " + recipeName);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Number of Ingredients: " + numIngredients);
            Console.WriteLine("Ingredients: ");
            foreach (Ingredient ingredient in ingredients)
            {
                if (ingredient != null)
                {
                    Console.WriteLine($"Ingredient Name: {ingredient.ingredientName}\nIngredient Quantity: {ingredient.ingredientQuantity}\nUnit of Measurement: {ingredient.ingredientMeasurement}");
                }
            }
            Console.WriteLine("Number of Steps: " + numOfSteps);
            for (int j = 0; j < numOfSteps; j++)
            {
                Console.WriteLine($"Step {j + 1}: {stepDescriptions[j]}");
            }

        }

        public void scaleRecipe()
        {
            Console.Write("Enter the scale factor: ");
            double scale = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].ingredientQuantity *= scale;
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
            
        }   

        public void recipeMenu()
        {
            while (true)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("WELCOME TO THE RECIPE MANAGER");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Create Recipe");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Ingredient Quantities");
                Console.WriteLine("5. Clear Recipe");
                Console.WriteLine("6. Exit Manager");
                Console.Write("Please choose one of the above options: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        inputRecipe();
                        break;
                    case 2:
                        displayRecipe();
                        break;
                    case 3:
                        scaleRecipe();
                        break;
                    case 4:
                        resetIngredientQuantity();
                        break;
                    case 5:
                        clearRecipe();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input, please choose one of the options");
                        break;
                };
            }
        }
    }
}
