/// <summary>
/// Calwyn Govender
/// ST10303017
/// 
/// This class is used to create a recipe object. The recipe object will have the following attributes:
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
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
        private int numIngredients { get; set; }

        private Ingredient[] ingredients; 
        private int numOfSteps { get; set; }
        private string[] stepDescriptions { get; set; }

        //-----------------------------------------------------------------------------------------------------------//
        public Recipe(int numIngredients, int numOfSteps)
        {
            this.numIngredients = numIngredients;
            this.numOfSteps = numOfSteps;
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

            Console.Write("Ingredients: ");

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter the name of the ingredient: ");
                string ingredientName = Console.ReadLine();

                Console.Write("Enter the quantity of ingredients: ");
                int ingredientQuantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the ingredient unit of measurement: ");
                string ingredientMeasurement = Console.ReadLine();

                ingredients[i] = new Ingredient(ingredientName, ingredientQuantity, ingredientMeasurement);
                Console.Write("Enter the number of steps: ");
                int numOfSteps = Convert.ToInt32(Console.ReadLine());

            }
            for (int j = 0; j < numOfSteps; j++)
            {
                Console.Write("Enter the description of step " + (j + 1) + ": ");
                stepDescriptions[j] = Console.ReadLine();
            }
        }

        public void displayRecipe()
        {
            inputRecipe();
            Console.WriteLine("Recipe Name: " + recipeName);
            Console.WriteLine("Number of Ingredients: " + numIngredients);
            Console.WriteLine("Ingredients: ");
            foreach (var ingredient in ingredients)
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
            int scale = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].ingredientQuantity *= scale;
            }
        }

        public void clearRecipe()
        {
            recipeName = "";
            numIngredients = 0;
            numOfSteps = 0;
            ingredients = null;
            stepDescriptions = null;
        }   

    }
}
