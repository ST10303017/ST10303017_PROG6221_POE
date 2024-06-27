using System;
using System.Collections.Generic;

namespace ST10303017_PROG6221_POE.Classes
{
    public class Recipe
    {
        public delegate void CaloriesExceededHandler(string recipeName, double totalCalories);
        public event CaloriesExceededHandler CaloriesExceeded;

        public string RecipeName { get; set; } // Changed from private set to public set
        public int NumIngredients { get; set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<string> StepDescriptions { get; private set; } // Changed from private to public

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            StepDescriptions = new List<string>();
        }

        public void inputRecipe()
        {
            Console.Write("Enter the name of the recipe: ");
            RecipeName = Console.ReadLine();

            Console.Write("Enter the number of ingredients: ");
            NumIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < NumIngredients; i++)
            {
                Console.Write("Enter the name of the ingredient: ");
                string ingredientName = Console.ReadLine();

                Console.Write("Enter the quantity of the ingredient: ");
                double ingredientQuantity = double.Parse(Console.ReadLine());

                Console.Write("Enter the unit of measurement: ");
                string ingredientMeasurement = Console.ReadLine();

                Console.Write("Enter the calories: ");
                double ingredientCalories = double.Parse(Console.ReadLine());

                Console.Write("Enter the food group: ");
                string ingredientFoodGroup = Console.ReadLine();

                Ingredients.Add(new Ingredient(ingredientName, ingredientQuantity, ingredientMeasurement, ingredientQuantity, ingredientCalories, ingredientFoodGroup));
            }

            Console.Write("Enter the number of steps: ");
            int numOfSteps = int.Parse(Console.ReadLine());

            for (int j = 0; j < numOfSteps; j++)
            {
                Console.Write($"Enter the description of step {j + 1}: ");
                string stepDescription = Console.ReadLine();
                StepDescriptions.Add(stepDescription); // Use the public StepDescriptions property
            }
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.ingredientCalories;
            }

            if (totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(RecipeName, totalCalories);
            }

            return totalCalories;
        }

        public void displayRecipe()
        {
            Console.WriteLine($"Recipe Name: {RecipeName}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.ingredientName} - {ingredient.ingredientQuantity} {ingredient.ingredientMeasurement} - {ingredient.ingredientCalories} calories");
            }
            Console.WriteLine($"Total Calories: {CalculateTotalCalories()}");
            Console.WriteLine("Steps:");
            for (int i = 0; i < StepDescriptions.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}: {StepDescriptions[i]}");
            }
        }

        public void scaleRecipe()
        {
            Console.Write("Enter the scale factor (0.5, 2, or 3): ");
            double scaleFactor = double.Parse(Console.ReadLine());

            foreach (var ingredient in Ingredients)
            {
                ingredient.ingredientQuantity *= scaleFactor;
            }
        }

        public void resetIngredientQuantity()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ingredientQuantity = ingredient.originalQuantity;
            }
        }

        public void clearRecipe()
        {
            RecipeName = string.Empty;
            NumIngredients = 0;
            Ingredients.Clear();
            StepDescriptions.Clear(); // Use the public StepDescriptions property
        }
    }
}
