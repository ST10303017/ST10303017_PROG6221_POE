using System.Collections.Generic;
using System.Windows;
using ST10303017_PROG6221_POE.Classes;

namespace RecipeAppWPF
{
    public partial class AddRecipeWindow : Window
    {
        public Recipe NewRecipe { get; private set; }
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();
        private int numIngredients;
        private int numSteps;
        private int ingredientCount = 0;
        private int stepCount = 0;

        public AddRecipeWindow()
        {
            InitializeComponent();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ingredientCount < numIngredients && ValidateIngredientInput())
            {
                ingredients.Add(new Ingredient(
                    IngredientNameTextBox.Text,
                    double.Parse(QuantityTextBox.Text),
                    UnitTextBox.Text,
                    double.Parse(QuantityTextBox.Text),
                    double.Parse(CaloriesTextBox.Text),
                    FoodGroupTextBox.Text
                ));

                ingredientCount++;
                ClearIngredientFields();

                if (ingredientCount == numIngredients)
                {
                    MessageBox.Show("All ingredients added.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (stepCount < numSteps && !string.IsNullOrWhiteSpace(StepDescriptionTextBox.Text))
            {
                steps.Add(StepDescriptionTextBox.Text);
                stepCount++;
                StepDescriptionTextBox.Clear();

                if (stepCount == numSteps)
                {
                    MessageBox.Show("All steps added.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Step description cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateRecipeInput())
            {
                NewRecipe = new Recipe
                {
                    RecipeName = RecipeNameTextBox.Text
                };

                NewRecipe.Ingredients.AddRange(ingredients);
                NewRecipe.StepDescriptions.AddRange(steps);

                DialogResult = true;
            }
        }

        private bool ValidateIngredientInput()
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(QuantityTextBox.Text) ||
                !double.TryParse(QuantityTextBox.Text, out double _) ||
                string.IsNullOrWhiteSpace(UnitTextBox.Text) ||
                string.IsNullOrWhiteSpace(CaloriesTextBox.Text) ||
                !double.TryParse(CaloriesTextBox.Text, out double _) ||
                string.IsNullOrWhiteSpace(FoodGroupTextBox.Text))
            {
                MessageBox.Show("Please enter valid ingredient details.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool ValidateRecipeInput()
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Recipe name cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(NumIngredientsTextBox.Text, out numIngredients) || numIngredients <= 0)
            {
                MessageBox.Show("Please enter a valid number of ingredients.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (ingredients.Count != numIngredients)
            {
                MessageBox.Show($"Please add {numIngredients} ingredients.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(NumStepsTextBox.Text, out numSteps) || numSteps <= 0)
            {
                MessageBox.Show("Please enter a valid number of steps.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (steps.Count != numSteps)
            {
                MessageBox.Show($"Please add {numSteps} steps.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void ClearIngredientFields()
        {
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitTextBox.Clear();
            CaloriesTextBox.Clear();
            FoodGroupTextBox.Clear();
        }
    }
}
