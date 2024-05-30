using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10303017_PROG6221_POE.Classes;
using System.Collections.Generic;

namespace RecipeManager.Tests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void CalculateTotalCalories_WhenCalled_ReturnsCorrectTotal()
        {
            // Arrange
            var recipe = new Recipe();
            recipe.inputRecipe("Test Recipe", new List<Ingredient>
            {
                new Ingredient("Ingredient1", 100, "grams", 100, 50, "Protein"),
                new Ingredient("Ingredient2", 200, "grams", 200, 100, "Carbohydrates"),
                new Ingredient("Ingredient3", 300, "grams", 300, 150, "Fats")
            }, new List<string> { "Step 1", "Step 2" });

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(300, totalCalories);
        }
    }
}
