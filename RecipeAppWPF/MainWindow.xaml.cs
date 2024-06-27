using System.Windows;
using System.Windows.Controls;
using ST10303017_PROG6221_POE.Classes;

namespace RecipeAppWPF
{
    public partial class MainWindow : Window
    {
        private RecipeManager recipeManager;

        public MainWindow()
        {
            InitializeComponent();
            recipeManager = new RecipeManager();
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow();
            if (addRecipeWindow.ShowDialog() == true)
            {
                recipeManager.addRecipe(addRecipeWindow.NewRecipe);
                DisplayRecipes();
            }
        }

        private void DisplayRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayRecipes();
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = FilterIngredientTextBox.Text;
            string foodGroup = ((ComboBoxItem)FilterFoodGroupComboBox.SelectedItem).Content.ToString();
            double maxCalories = MaxCaloriesSlider.Value;

            RecipesListView.ItemsSource = recipeManager.FilterRecipes(ingredient, foodGroup, maxCalories);
        }

        private void ClearRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = GetSelectedRecipeName();
            if (!string.IsNullOrEmpty(recipeName))
            {
                recipeManager.ClearRecipe(recipeName);
                DisplayRecipes();
            }
        }

        private void ResetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = GetSelectedRecipeName();
            if (!string.IsNullOrEmpty(recipeName))
            {
                recipeManager.ResetQuantities(recipeName);
                DisplayRecipes();
            }
        }

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

        private string GetSelectedRecipeName()
        {
            if (RecipesListView.SelectedItem is Recipe selectedRecipe)
            {
                return selectedRecipe.RecipeName;
            }
            MessageBox.Show("Please select a recipe from the list.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }

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
    }
}
