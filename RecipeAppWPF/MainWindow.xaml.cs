/// <summary>
/// Calwyn Govender
/// ST10303017
/// (Troelsen & Japikse, 2022)
/// (Chand, 2018)
/// (W3Schools, 2024)
/// -----------------------------------------------------------------------------------------------------------
using System.Windows;
using System.Windows.Controls;
using ST10303017_PROG6221_POE.Classes;

namespace RecipeAppWPF
{
    // The MainWindow class
    // This class represents the main window of the Recipe Manager WPF application.
    // It provides methods to handle user interactions and manage recipes.
    //-----------------------------------------------------------------------------------------------------------//
    public partial class MainWindow : Window
    {
        // The RecipeManager instance
        private RecipeManager recipeManager;

        // The MainWindow constructor
        // Initializes a new instance of the MainWindow class.
        //---------------------------------------------------------------------------------------------------//
        public MainWindow()
        {
            InitializeComponent();
            recipeManager = new RecipeManager();
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to handle the AddRecipeButton click event
        // Opens the AddRecipeWindow and adds the new recipe to the RecipeManager
        //---------------------------------------------------------------------------------------------------//
        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow();
            if (addRecipeWindow.ShowDialog() == true)
            {
                recipeManager.addRecipe(addRecipeWindow.NewRecipe);
                DisplayRecipes();
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to handle the DisplayRecipesButton click event
        // Displays all recipes in the RecipeManager
        //---------------------------------------------------------------------------------------------------//
        private void DisplayRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayRecipes();
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to handle the ApplyFilterButton click event
        // Filters recipes based on the specified criteria and displays the filtered recipes
        //---------------------------------------------------------------------------------------------------//
        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = FilterIngredientTextBox.Text;
            string foodGroup = ((ComboBoxItem)FilterFoodGroupComboBox.SelectedItem).Content.ToString();
            double maxCalories = MaxCaloriesSlider.Value;

            RecipesListView.ItemsSource = recipeManager.FilterRecipes(ingredient, foodGroup, maxCalories);
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to handle the ClearRecipeButton click event
        // Clears the selected recipe from the RecipeManager and updates the display
        //---------------------------------------------------------------------------------------------------//
        private void ClearRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = GetSelectedRecipeName();
            if (!string.IsNullOrEmpty(recipeName))
            {
                recipeManager.ClearRecipe(recipeName);
                DisplayRecipes();
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to handle the ResetQuantitiesButton click event
        // Resets the ingredient quantities of the selected recipe and updates the display
        //---------------------------------------------------------------------------------------------------//
        private void ResetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = GetSelectedRecipeName();
            if (!string.IsNullOrEmpty(recipeName))
            {
                recipeManager.ResetQuantities(recipeName);
                DisplayRecipes();
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to handle the ScaleQuantitiesButton click event
        // Scales the ingredient quantities of the selected recipe and updates the display
        //---------------------------------------------------------------------------------------------------//
        private void ScaleQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = GetSelectedRecipeName();
            if (!string.IsNullOrEmpty(recipeName))
            {
                double scaleFactor = GetScaleFactor();
                recipeManager.ScaleQuantities(recipeName, scaleFactor);
                DisplayRecipes();
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to display all recipes
        // Iterates through the recipes and displays their details in message boxes
        //---------------------------------------------------------------------------------------------------//
        private void DisplayRecipes()
        {
            var recipes = recipeManager.GetRecipes();
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                RecipesListView.ItemsSource = null;
                return;
            }

            RecipesListView.ItemsSource = recipes;

            foreach (var recipe in recipes)
            {
                string recipeDetails = $"Recipe Name: {recipe.RecipeName}\nTotal Calories: {recipe.CalculateTotalCalories()}\n\nIngredients:\n";
                foreach (var ingredient in recipe.Ingredients)
                {
                    recipeDetails += $"- {ingredient.ingredientName}, {ingredient.ingredientQuantity} {ingredient.ingredientMeasurement}, {ingredient.ingredientCalories} calories, {ingredient.ingredientFoodGroup}\n";
                }

                recipeDetails += "\nSteps:\n";
                for (int i = 0; i < recipe.StepDescriptions.Count; i++)
                {
                    recipeDetails += $"{i + 1}. {recipe.StepDescriptions[i]}\n";
                }

                MessageBox.Show(recipeDetails, "Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to get the name of the selected recipe
        // Returns the name of the selected recipe, or shows an error message if no recipe is selected
        //---------------------------------------------------------------------------------------------------//
        private string GetSelectedRecipeName()
        {
            if (RecipesListView.SelectedItem is Recipe selectedRecipe)
            {
                return selectedRecipe.RecipeName;
            }
            MessageBox.Show("Please select a recipe from the list.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to get the scale factor from the user
        // Prompts the user to enter a scale factor and returns it
        //---------------------------------------------------------------------------------------------------//
        private double GetScaleFactor()
        {
            // Prompt user for scale factor
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter scale factor (0.5, 2, or 3):", "Scale Recipe", "1");
            if (double.TryParse(input, out double scaleFactor) && (scaleFactor == 0.5 || scaleFactor == 2 || scaleFactor == 3))
            {
                return scaleFactor;
            }
            MessageBox.Show("Invalid scale factor. Please enter 0.5, 2, or 3.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return 1;
        }
        //---------------------------------------------------------------------------------------------------//
    }
    //---------------------------------------------------------------------------------------------------//
}
//---------------------------------------------------------------------------------------------------//
