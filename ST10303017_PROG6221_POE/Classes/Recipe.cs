using System;
using System.Collections.Generic;

// Namespace for the Recipe class
//-----------------------------------------------------------------------------------------------------------//
namespace ST10303017_PROG6221_POE.Classes
{
    // Recipe class
    // The recipe class contains multiple methods that allow the user to create, display, scale, reset, and clear a recipe
    // The class has attributes for the recipe name, number of ingredients, an array of ingredients, the original quantity of the ingredients, the number of steps, and an array of step descriptions
    // This class is called in the Main method in the Program class
    //-----------------------------------------------------------------------------------------------------------//
    public class Recipe
    {
        // Delegate for the CaloriesExceeded event
        public delegate void CaloriesExceededHandler(string recipeName, double totalCalories);
        // Event for when the total calories exceed 300
        public event CaloriesExceededHandler CaloriesExceeded;

        // Attributes for the Recipe class
        // The attributes are private and can only be accessed through the get and set methods
        public string RecipeName { get; private set; }
        public int NumIngredients { get; set; }

        // List of ingredients in the recipe
        private List<Ingredient> ingredients;
        private double originalQuantity { get; set; }
        private int numOfSteps { get; set; }
        // List of step descriptions in the recipe
        private List<string> stepDescriptions;

        // Constructor for the Recipe class
        // The constructor initializes the list of ingredients and the list of step descriptions
        //---------------------------------------------------------------------------------------------------//
        public Recipe()
        {
            ingredients = new List<Ingredient>();
            stepDescriptions = new List<string>();
        }
        //---------------------------------------------------------------------------------------------------//

        // Method to input the recipe details
        // The method prompts the user to enter the recipe name, number of ingredients, ingredient name, quantity, unit of measurement, calories, food group, and the number of steps
        // The method uses try-catch blocks to handle exceptions and validate the input
        // The method creates a list of ingredients and a list of step descriptions
        // The method uses while loops to ensure that the user enters valid input
        //---------------------------------------------------------------------------------------------------//
        public void inputRecipe()
        {
            // Input the recipe name
            while (true) // Loop to get the recipe name
            {
                try
                {
                    Console.ResetColor(); // Reset the console color
                    Console.Write("Enter the name of the recipe: ");
                    RecipeName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(RecipeName)) // Check if the recipe name is not empty
                        break; // Break the loop if the input is valid
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Set the console color to red
                        throw new ArgumentException("Invalid input, the recipe name cannot be empty. Please try again."); // Throw an exception if the input is invalid
                    }
                }
                catch (Exception e) // Catch the exception and print the error message
                {
                    Console.WriteLine(e.Message);
                }
            }

            // Input the number of ingredients
            while (true) // Loop to get the number of ingredients
            {
                try
                {
                    Console.ResetColor();
                    Console.Write("Enter the number of ingredients: ");
                    if (int.TryParse(Console.ReadLine(), out int checkNumIngredients) && checkNumIngredients > 0) // Check if the input is an integer and greater than 0
                    {
                        NumIngredients = checkNumIngredients; // Set the number of ingredients to the input
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Invalid input, number of ingredients must be a positive integer. Please try again.");
                    }
                }
                catch (Exception e) // Catch the exception and print the error message
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Ingredients: ");

            for (int i = 0; i < NumIngredients; i++) // Loop to get the ingredient details
            {
                string ingredientName;
                double ingredientQuantity;
                string ingredientMeasurement;
                double calories;
                string foodGroup;

                // Input the ingredient name
                while (true) // Loop to get the ingredient name
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the name of the ingredient: ");
                        ingredientName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(ingredientName)) // Check if the ingredient name is not empty
                            break; // Valid input, break the loop
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Set the console color to red
                            throw new ArgumentException("Invalid input, ingredient name cannot be empty. Please try again.");
                        }
                    }
                    catch (Exception e) // Catch the exception and print the error message
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                // Input the ingredient quantity
                while (true) // Loop to get the ingredient quantity
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the quantity of the ingredient: "); // Prompt the user to enter the quantity of the ingredient
                        string quantityInput = Console.ReadLine();
                        if (double.TryParse(quantityInput, out ingredientQuantity) && ingredientQuantity > 0) // Check if the input is a double and greater than 0
                            break; // Valid input, break the loop
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, quantity must be a positive number. Please try again.");
                        }
                    }
                    catch (Exception e) // Catch the exception and print the error message
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                // Input the ingredient unit of measurement
                while (true) // Loop to get the unit of measurement
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the ingredient unit of measurement: ");
                        ingredientMeasurement = Console.ReadLine();
                        if (!string.IsNullOrEmpty(ingredientMeasurement)) // Check if the unit of measurement is not empty
                            break; // Valid input, break the loop
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, the unit of measurement cannot be empty. Please try again.");
                        }
                    }
                    catch (Exception e) // Catch the exception and print the error message
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                // Input the number of calories
                while (true) // Loop to get the number of calories
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the number of calories: ");
                        string caloriesInput = Console.ReadLine();
                        if (double.TryParse(caloriesInput, out calories) && calories >= 0) // Check if the input is a double and greater than or equal to 0
                            break; // Valid input, break the loop
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, calories must be 0 or greater. Please try again.");
                        }
                    }
                    catch (Exception e) // Catch the exception and print the error message
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                // Input the food group
                while (true) // Loop to get the food group
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the food group: ");
                        foodGroup = Console.ReadLine();
                        if (!string.IsNullOrEmpty(foodGroup)) // Check if the food group is not empty
                            break; // Valid input, break the loop
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, the food group cannot be empty. Please try again.");
                        }
                    }
                    catch (Exception e) // Catch the exception and print the error message
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                double originalQuantity = ingredientQuantity; // Set the original quantity
                ingredients.Add(new Ingredient(ingredientName, ingredientQuantity, ingredientMeasurement, originalQuantity, calories, foodGroup)); // Add the ingredient to the list
            }

            // Input the number of steps
            while (true) // Loop to get the number of steps
            {
                try
                {
                    Console.ResetColor();
                    Console.Write("Enter the number of steps: ");
                    if (int.TryParse(Console.ReadLine(), out int checkNumOfSteps) && checkNumOfSteps > 0) // Check if the input is an integer and greater than 0
                    {
                        numOfSteps = checkNumOfSteps; // Set the number of steps
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Invalid input. Please enter a number that is greater than 0");
                    }
                }
                catch (Exception e) // Catch the exception and print the error message
                {
                    Console.WriteLine(e.Message);
                }
            }

            // Input the step descriptions
            for (int j = 0; j < numOfSteps; j++) // Loop to get the step descriptions
            {
                while (true)
                {
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the description of step " + (j + 1) + ": ");
                        string stepDescription = Console.ReadLine();
                        if (!string.IsNullOrEmpty(stepDescription)) // Check if the step description is not empty
                        {
                            stepDescriptions.Add(stepDescription); // Add the step description to the list
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("The step description cannot be empty. Please try again.");
                        }
                    }
                    catch (Exception e) // Catch the exception and print the error message
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
        //---------------------------------------------------------------------------------------------------//

        // Overload Method for testing purposes
        //---------------------------------------------------------------------------------------------------//
        public void inputRecipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            this.RecipeName = name;
            this.ingredients = ingredients;
            this.stepDescriptions = steps;
            this.NumIngredients = ingredients.Count;
            this.numOfSteps = steps.Count;
        }
        //---------------------------------------------------------------------------------------------------//

        // Method to calculate the total calories of the recipe
        // The method iterates through the list of ingredients and sums up the calories
        //---------------------------------------------------------------------------------------------------//
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients) // Iterate through the list of ingredients
            {
                totalCalories += ingredient.ingredientCalories; // Add the calories of each ingredient
            }

            if (totalCalories > 300) // Check if the total calories exceed 300
            {
                CaloriesExceeded?.Invoke(RecipeName, totalCalories); // Invoke the CaloriesExceeded event
            }

            return totalCalories;
        }
        //---------------------------------------------------------------------------------------------------//

        // Method to display the recipe details
        // The method displays the recipe name, number of ingredients, ingredients, total calories, number of steps, and step descriptions
        // The method uses a foreach loop to iterate through the ingredients list and display the ingredient details
        // The method uses a for loop to iterate through the step descriptions list and display the step descriptions
        //---------------------------------------------------------------------------------------------------//
        public void displayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Set the console color to yellow
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("RECIPE NAME: " + RecipeName); // Display the recipe name
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Number of Ingredients: " + NumIngredients + "\n");
            Console.WriteLine("Ingredients: ");
            foreach (Ingredient ingredient in ingredients) // Foreach loop to display the ingredients
            {
                if (ingredient != null) // Check if the ingredient is not null
                {
                    Console.WriteLine("Ingredient Name: " + ingredient.ingredientName);
                    Console.WriteLine("Ingredient Quantity: " + ingredient.ingredientQuantity);
                    Console.WriteLine("Unit of Measurement: " + ingredient.ingredientMeasurement);
                    Console.WriteLine("Calories: " + ingredient.ingredientCalories);
                    Console.WriteLine("Food Group: " + ingredient.ingredientFoodGroup + "\n");
                }
            }
            double totalCalories = CalculateTotalCalories(); // Calculate the total calories
            Console.WriteLine("Total Calories: " + totalCalories);
            Console.WriteLine("Number of Steps: " + numOfSteps);
            for (int j = 0; j < numOfSteps; j++) // For loop to display the step descriptions
            {
                Console.WriteLine($"Step {j + 1}: {stepDescriptions[j]}");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();
        }
        //---------------------------------------------------------------------------------------------------//

        // Method to scale the recipe ingredients
        // The method prompts the user to enter a scale factor of 0.5, 2, or 3
        // The method uses a while loop to ensure that the user enters a valid scale factor
        // The method scales the ingredient quantity by the scale factor
        //---------------------------------------------------------------------------------------------------//
        public void scaleRecipe()
        {
            double scaleFactor = 0; // Initialize the scale factor to 0
            bool validScaleFactor = false;
            while (!validScaleFactor) // Loop to get the scale factor
            {
                Console.Write("Enter the scale factor (0.5, 2, or 3): "); // Prompt the user to enter the scale factor
                string scaleInput = Console.ReadLine();

                if (double.TryParse(scaleInput, out scaleFactor) && (scaleFactor == 0.5 || scaleFactor == 2 || scaleFactor == 3)) // Check if the input is a double and is equal to 0.5, 2, or 3
                {
                    validScaleFactor = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3 for the factor"); // Print an error message if the input is invalid
                }
            }

            foreach (var ingredient in ingredients) // Loop to scale the ingredient quantity
            {
                ingredient.ingredientQuantity *= scaleFactor; // Scale the ingredient quantity by the scale factor
                ingredient.ingredientMeasurement = ScaleMeasurement(ingredient.ingredientMeasurement, scaleFactor); // Scale the ingredient measurement by the scale factor
            }

            displayRecipe(); // Display the updated recipe
        }
        //---------------------------------------------------------------------------------------------------//

        // Helper method to scale the measurement units
        // The method adjusts the measurement units based on the scale factor
        //---------------------------------------------------------------------------------------------------//
        private string ScaleMeasurement(string measurement, double scaleFactor)
        {
            // This is a simple example, you might want to handle different measurement units differently
            // For instance, if you are using metric and imperial units, you may need more complex logic
            return measurement; // Placeholder to show where the scaling logic would be applied
        }
        //---------------------------------------------------------------------------------------------------//

        // Method to reset the ingredient quantity
        // The method resets the ingredient quantity to the original quantity
        // The method uses a foreach loop to iterate through the ingredients list and set the ingredient quantity to the original quantity
        //---------------------------------------------------------------------------------------------------//
        public void resetIngredientQuantity()
        {
            foreach (var ingredient in ingredients) // Loop to reset the ingredient quantity
            {
                ingredient.ingredientQuantity = ingredient.originalQuantity; // Set the ingredient quantity to the original quantity
            }

            displayRecipe(); // Display the updated recipe
        }
        //---------------------------------------------------------------------------------------------------//

        // Method to clear the recipe
        // The method resets the recipe name, number of ingredients, number of steps, ingredients list, and step descriptions list
        // The method asks the user for confirmation before clearing the recipe data
        //---------------------------------------------------------------------------------------------------//
        public void clearRecipe()
        {
            Console.Write("Are you sure you want to clear the recipe? (yes/no): ");
            string confirmation = Console.ReadLine();
            if (confirmation.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                RecipeName = "";
                NumIngredients = 0;
                numOfSteps = 0;
                ingredients.Clear(); // Clear the list of ingredients
                stepDescriptions.Clear(); // Clear the list of step descriptions

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("RECIPE CLEARED");
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Clear recipe action cancelled.");
            }
        }
        //---------------------------------------------------------------------------------------------------//
    }
    //---------------------------------------------------------------------------------------------------//
}
//---------------------------------------------------------------------------------------------------//
