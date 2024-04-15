/// <summary>
/// Calwyn Govender
/// ST10303017
/// 
/// This class is used to create a recipe object. The recipe object will have the following attributes:
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10303017_PROG6221_POE.Classes
{
    public class Recipe
    {
        private string recipeName { get; set; }
        private int numIngredients { get; set; }
        private string[] ingredients; // Array of ingredients
        private string ingredientName { get; set; }
        private int ingredientQuantity { get; set; }
        private string ingredientMeasurement { get; set; }
        private int numOfSteps { get; set; }
        private string stepDescription { get; set; }

        public void inputRecipe()
        {
            Console.Write("Enter the name of the recipe: ");
            string recipeName = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            numIngredients = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingredients: ");

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter the name of the ingredient: ");
                ingredientName = Console.ReadLine();

                Console.Write("Enter the quantity of ingredients: ");
                ingredientQuantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the ingredient unit of measurement: ");
                ingredientMeasurement = Console.ReadLine();

                Console.Write("Enter the number of steps: ");
                int numOfSteps = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < numOfSteps; j++)
                {
                    Console.Write("Enter the description of each step: ");
                    stepDescription = Console.ReadLine();
                }
            }
        }

        public void displayRecipe()
        {
            inputRecipe();
            Console.WriteLine("Recipe Name: " + recipeName);
            Console.WriteLine("Number of Ingredients: " + numIngredients);
            Console.WriteLine("Ingredients: ");
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("Ingredient Name: " + ingredientName);
                Console.WriteLine("Ingredient Quantity: " + ingredientQuantity);
                Console.WriteLine("Ingredient Measurement: " + ingredientMeasurement);
            }
            Console.WriteLine("Number of Steps: " + numOfSteps);
            for (int j = 0; j < numOfSteps; j++)
            {
                Console.WriteLine("Step Description: " + stepDescription);
            }

        }

    }
}
