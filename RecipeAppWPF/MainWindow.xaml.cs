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
            if (ValidateRecipeInput())
            {
                var recipe = new Recipe();
                recipe.inputRecipe();
                recipeManager.addRecipe(recipe);
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

        private void DisplayRecipes()
        {
            RecipesListView.ItemsSource = recipeManager.GetRecipes();
        }

        private bool ValidateRecipeInput()
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Recipe name cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(NumIngredientsTextBox.Text) || !int.TryParse(NumIngredientsTextBox.Text, out int numIngredients) || numIngredients <= 0)
            {
                MessageBox.Show("Please enter a valid number of ingredients.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(NumStepsTextBox.Text) || !int.TryParse(NumStepsTextBox.Text, out int numSteps) || numSteps <= 0)
            {
                MessageBox.Show("Please enter a valid number of steps.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
