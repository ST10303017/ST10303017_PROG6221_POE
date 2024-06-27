/// <summary>
/// Calwyn Govender
/// ST10303017
/// (Troelsen & Japikse, 2022)
/// (Chand, 2018)
/// (W3Schools, 2024)
/// -----------------------------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ST10303017_PROG6221_POE.Classes;

namespace RecipeAppWPF
{
    // The AddRecipeWindow class
    // This class represents the window for adding a new recipe in the Recipe Manager WPF application.
    // It provides methods to handle user inputs for recipe details, ingredients, and steps.
    //-----------------------------------------------------------------------------------------------------------//
    public partial class AddRecipeWindow : Window
    {
        // Properties and fields for the AddRecipeWindow class
        // NewRecipe: The recipe being created
        // ingredients: The list of ingredients for the new recipe
        // steps: The list of step descriptions for the new recipe
        // numIngredients: The total number of ingredients expected
        // numSteps: The total number of steps expected
        // ingredientCount: The current count of added ingredients
        // stepCount: The current count of added steps
        //---------------------------------------------------------------------------------------------------//
        public Recipe NewRecipe { get; private set; }
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();
        private int numIngredients;
        private int numSteps;
        private int ingredientCount = 0;
        private int stepCount = 0;
        //---------------------------------------------------------------------------------------------------//

        // The AddRecipeWindow constructor
        // Initializes a new instance of the AddRecipeWindow class.
        //---------------------------------------------------------------------------------------------------//
        public AddRecipeWindow()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to handle the AddIngredientButton click event
        // Validates and adds the ingredient details to the ingredients list
        // Clears the ingredient input fields after adding
        // Displays a message indicating the ingredient has been added
        //---------------------------------------------------------------------------------------------------//
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateIngredientInput())
            {
                ingredients.Add(new Ingredient(
                    IngredientNameTextBox.Text,
                    double.Parse(QuantityTextBox.Text),
                    UnitTextBox.Text,
                    double.Parse(QuantityTextBox.Text),
                    double.Parse(CaloriesTextBox.Text),
                    (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
                ));

                ingredientCount++;
                ClearIngredientFields();
                MessageBox.Show("Ingredient added.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                if (ingredientCount == numIngredients)
                {
                    MessageBox.Show("All ingredients added.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to handle the AddStepButton click event
        // Validates and adds the step description to the steps list
        // Clears the step description input field after adding
        // Displays a message indicating the step has been added
        //---------------------------------------------------------------------------------------------------//
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StepDescriptionTextBox.Text))
            {
                steps.Add(StepDescriptionTextBox.Text);
                stepCount++;
                StepDescriptionTextBox.Clear();
                MessageBox.Show("Step added.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

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
        //---------------------------------------------------------------------------------------------------//

        // The method to handle the AddRecipeButton click event
        // Validates the recipe details and creates a new Recipe object
        // Sets the DialogResult to true to indicate the recipe has been successfully created
        //---------------------------------------------------------------------------------------------------//
        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateRecipeInput())
            {
                NewRecipe = new Recipe
                {
                    RecipeName = RecipeNameTextBox.Text,
                    Ingredients = new List<Ingredient>(ingredients),
                    StepDescriptions = new List<string>(steps)
                };

                DialogResult = true;
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to validate ingredient input fields
        // Ensures that all ingredient input fields are filled with valid values
        // Displays an error message if any validation fails
        //---------------------------------------------------------------------------------------------------//
        private bool ValidateIngredientInput()
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(QuantityTextBox.Text) ||
                !double.TryParse(QuantityTextBox.Text, out double _) ||
                string.IsNullOrWhiteSpace(UnitTextBox.Text) ||
                string.IsNullOrWhiteSpace(CaloriesTextBox.Text) ||
                !double.TryParse(CaloriesTextBox.Text, out double _) ||
                FoodGroupComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please enter valid ingredient details.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        //---------------------------------------------------------------------------------------------------//

        // The method to validate recipe input fields
        // Ensures that all recipe input fields are filled with valid values
        // Displays an error message if any validation fails
        //---------------------------------------------------------------------------------------------------//
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
        //---------------------------------------------------------------------------------------------------//

        // The method to clear ingredient input fields
        // Clears the input fields for ingredient details
        //---------------------------------------------------------------------------------------------------//
        private void ClearIngredientFields()
        {
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            UnitTextBox.Clear();
            CaloriesTextBox.Clear();
            FoodGroupComboBox.SelectedIndex = -1;
        }
        //---------------------------------------------------------------------------------------------------//
    }
    //---------------------------------------------------------------------------------------------------//
}
//---------------------------------------------------------------------------------------------------//
