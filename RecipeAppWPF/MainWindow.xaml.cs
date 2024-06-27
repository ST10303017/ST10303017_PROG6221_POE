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
            var recipe = new Recipe();
            recipe.inputRecipe();
            recipeManager.addRecipe(recipe);
            DisplayRecipes();
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
    }
}
