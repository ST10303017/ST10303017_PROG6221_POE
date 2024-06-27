using System;
using System.Collections.Generic;

namespace ST10303017_PROG6221_POE.Classes
{
    public class Recipe
    {
        public delegate void CaloriesExceededHandler(string recipeName, double totalCalories);
        public event CaloriesExceededHandler CaloriesExceeded;

        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> StepDescriptions { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            StepDescriptions = new List<string>();
        }

        public double TotalCalories
        {
            get
            {
                return CalculateTotalCalories();
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

        public void clearRecipe()
        {
            RecipeName = string.Empty;
            Ingredients.Clear();
            StepDescriptions.Clear();
        }

        public void resetIngredientQuantity()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ingredientQuantity = ingredient.originalQuantity;
            }
        }

        public void scaleRecipe(double scaleFactor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ingredientQuantity *= scaleFactor;
            }
        }
    }
}
