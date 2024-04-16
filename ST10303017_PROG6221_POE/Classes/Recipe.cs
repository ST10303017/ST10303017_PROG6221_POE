/// <summary>
/// Calwyn Govender
/// ST10303017
/// 
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        // Attributes for the Recipe class
        // The attributes are private and can only be accessed through the get and set methods
        public string recipeName { get; private set; }
        public int numIngredients { get; set; }

        private Ingredient[] ingredients; // Array object of the Ingredient class
        private double originalQuantity { get; set; }
        private int numOfSteps { get; set; }
        private string[] stepDescriptions { get; set; } // Array for the step descriptions

        // Constructor for the Recipe class
        // The constructor initializes the array of ingredients and the array of step descriptions
        //-----------------------------------------------------------------------------------------------------------//
        public Recipe()
        {
            ingredients = new Ingredient[numIngredients];
            stepDescriptions = new string[numOfSteps];
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Method to input a recipe
        // The method prompts the user to enter the recipe name, number of ingredients, ingredient name, quantity, and unit of measurement, and the number of steps
        // The method uses try-catch blocks to handle exceptions and validate the input
        // The method creates an array of ingredients and an array of step descriptions
        // The method uses while loops to ensure that the user enters valid input
        //-----------------------------------------------------------------------------------------------------------//
        public void inputRecipe()
        {
            while (true) // Loop to get the recipe name
            {
                try
                {
                    Console.ResetColor(); // Reset the console color
                    Console.Write("Enter the name of the recipe: ");
                    recipeName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(recipeName)) // Check if the recipe name is not empty
                        break; // Break the loop if the input is valid
                    else
                        Console.ForegroundColor = ConsoleColor.Red; // Set the console color to red
                        throw new ArgumentException("Invalid input, the recipe name cannot be empty. Please try again."); // Throw an exception if the input is invalid
                }
                catch (Exception e) // Catch the exception and print the error message
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true) // Loop to get the number of ingredients
            {
                try
                {
                    Console.ResetColor();
                    Console.Write("Enter the number of ingredients: ");
                    if (int.TryParse(Console.ReadLine(), out int checkNumIngredients) && checkNumIngredients > 0) // Check if the input is an integer and greater than 0
                    {
                        numIngredients = checkNumIngredients; // Set the number of ingredients to the input
                        ingredients = new Ingredient[numIngredients];// Create an array of ingredients with the number of ingredients
                        break; 
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Invalid input, number of ingredients must be greater than 0. Please try again"); // Throw an exception if the input is invalid
                }
                catch (Exception e) // Catch the exception and print the error message
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Ingredients: ");

            for (int i = 0; i < numIngredients; i++) // Loop to get the ingredient name, quantity, and unit of measurement
            {
                string ingredientName;
                double ingredientQuantity;
                string ingredientMeasurement;

                while (true) // Loop to get the ingredient name
                {
                    Console.ResetColor();
                    Console.Write("Enter the name of the ingredient: ");
                    ingredientName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(ingredientName)) // Check if the ingredient name is not empty
                        break; // Valid input, break the loop
                    else
                        Console.ForegroundColor = ConsoleColor.Red; // Set the console color to red
                        Console.WriteLine("Invalid input, ingredient name cannot be empty. Please try again."); // Print an error message if the input is invalid
                }

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
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid input, quantity must be greater than 0. Please try again"); // Throw an exception if the input is invalid
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message); // Prints error message if input is invalid
                    }
                }

                while (true) // Loop to get the unit of measurement
                {
                    Console.ResetColor(); // Reset the console color
                    Console.Write("Enter the ingredient unit of measurement: "); // Prompt the user to enter the unit of measurement
                    ingredientMeasurement = Console.ReadLine(); // Get the input from the user
                    if (!string.IsNullOrEmpty(ingredientMeasurement)) // Check if the unit of measurement is not empty
                        break; // Valid input, break the loop
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input, the unit of measurement cannot be empty. Please try again."); // Print an error message if the input is invalid
                }

                double originalQuantity = ingredientQuantity; // This should ideally be handled inside the Ingredient class
                ingredients[i] = new Ingredient(ingredientName, ingredientQuantity, ingredientMeasurement, originalQuantity); // Create a new ingredient object array with the input values

            }
            while (true) // Loop to get the number of steps
            {
                try // Try block to handle exceptions
                {
                    Console.ResetColor();
                    Console.Write("Enter the number of steps: "); // Prompt the user to enter the number of steps
                    if (int.TryParse(Console.ReadLine(), out int checkNumOfSteps) && checkNumOfSteps > 0) // Check if the input is an integer and greater than 0
                    {
                        numOfSteps = checkNumOfSteps; // Set the number of steps to the input
                        stepDescriptions = new string[numOfSteps]; // Create an array of step descriptions with the number of steps
                        break; // Break the loop if the input is valid
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("Invalid input. Please enter a number that is greater than 0"); // Throw an exception if the input is invalid
                }
                catch (Exception e) // Catch the exception and print the error message
                {
                    Console.WriteLine(e.Message);
                }
            }   

            for (int j = 0; j < numOfSteps; j++) // Loop to get the step descriptions
            {
                while(true) 
                {   
                    try
                    {
                        Console.ResetColor();
                        Console.Write("Enter the description of step " + (j + 1) + ": "); // Prompt the user to enter the step description with the step number
                        stepDescriptions[j] = Console.ReadLine();
                        if (!string.IsNullOrEmpty(stepDescriptions[j])) // Check if the step description is not empty
                            break;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("The step description cannot be empty. Please try again."); // Throw an exception if the input is invalid
                            
                    }
                    catch (Exception e) // Catch the exception and print the error message
                    {
                        Console.WriteLine(e.Message);
                    }
                }   
            }
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Method to display a recipe
        // The method displays the recipe name, number of ingredients, ingredients, number of steps, and step descriptions
        // The method uses a foreach loop to iterate through the ingredients array and display the ingredient name, quantity, and unit of measurement
        // The method uses a for loop to iterate through the step descriptions array and display the step descriptions
        //-----------------------------------------------------------------------------------------------------------//
        public void displayRecipe()
        {
            Recipe recipe = new Recipe(); // Create a new recipe object
            Console.ForegroundColor = ConsoleColor.Yellow; // Set the console color to yellow
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("RECIPE NAME: " + recipeName); // Display the recipe name
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("Number of Ingredients: " + numIngredients); // Display the number of ingredients
            Console.WriteLine("Ingredients: "); 
            foreach (Ingredient ingredient in ingredients) // Foreach Loop to display the ingredients
            {
                if (ingredient != null) // Check if the ingredient is not null
                {
                    Console.WriteLine($"Ingredient Name: {ingredient.ingredientName}\nIngredient Quantity: {ingredient.ingredientQuantity}\nUnit of Measurement: {ingredient.ingredientMeasurement}\n"); // Display the ingredient name, quantity, and unit of measurement
                }
            }
            Console.WriteLine("Number of Steps: " + numOfSteps); // Display the number of steps
            for (int j = 0; j < numOfSteps; j++) // For loop to display the step descriptions
            {
                Console.WriteLine($"Step {j + 1}: {stepDescriptions[j]}"); // Display the step number and step description
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------"); // Display a line to separate the recipe
            Console.ResetColor();
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Method to scale a recipe
        // The method prompts the user to enter a scale factor of 0.5, 2, or 3
        // The method uses a while loop to ensure that the user enters a valid scale factor
        // The method scales the ingredient quantity by the scale factor
        //-----------------------------------------------------------------------------------------------------------//
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

            for (int i = 0; i < numIngredients; i++) // Loop to scale the ingredient quantity
            {
                ingredients[i].ingredientQuantity = ingredients[i].ingredientQuantity*scaleFactor; // Scale the ingredient quantity by the scale factor
            }
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Method to reset the ingredient quantity
        // The method resets the ingredient quantity to the original quantity
        // The method uses a for loop to iterate through the ingredients array and set the ingredient quantity to the original quantity
        //-----------------------------------------------------------------------------------------------------------//
        public void resetIngredientQuantity()
        {
            for (int i = 0; i < numIngredients; i++) // Loop to reset the ingredient quantity
            {
                ingredients[i].ingredientQuantity = ingredients[i].originalQuantity; // Set the ingredient quantity to the original quantity
            }
        }
        //-----------------------------------------------------------------------------------------------------------//

        // Method to clear the recipe
        // The method resets the recipe name, number of ingredients, number of steps, ingredients array, and step descriptions array
        //-----------------------------------------------------------------------------------------------------------//
        public void clearRecipe()
        {
            recipeName = "";
            numIngredients = 0;
            numOfSteps = 0;
            ingredients = new Ingredient[0]; // Create a new array of ingredients
            stepDescriptions = new string[0]; // Create a new array of step descriptions
        }

        // Method to display the recipe menu
        // The method displays the recipe manager menu with options to create, display, scale, reset, clear a recipe, and exit the manager
        // The method uses a switch statement to call the inputRecipe, displayRecipe, scaleRecipe, resetIngredientQuantity, clearRecipe, and exit the manager
        //-----------------------------------------------------------------------------------------------------------//
        public void recipeMenu()
        {
            while (true) // Loop to display the recipe manager menu
            {
                Console.ForegroundColor = ConsoleColor.Cyan; // Set the console color to cyan
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("WELCOME TO THE RECIPE MANAGER"); // Display the recipe manager title
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
                Console.WriteLine("1. Create Recipe"); // Display the menu options
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Ingredient Quantities");
                Console.WriteLine("5. Clear Recipe");
                Console.WriteLine("6. Exit Manager");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
                Console.Write("Please choose one of the above options: "); // Prompt the user to choose an option
                string choice = Console.ReadLine(); // Get the input from the user
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
                switch (choice) // Switch statement to call the inputRecipe, displayRecipe, scaleRecipe, resetIngredientQuantity, clearRecipe, and exit the manager
                {
                    case "1":
                        inputRecipe();
                        break;
                    case "2":
                        displayRecipe();
                        break;
                    case "3":
                        scaleRecipe();
                        break;
                    case "4":
                        resetIngredientQuantity();
                        break;
                    case "5":
                        clearRecipe();
                        break;
                    case "6": // Exit the recipe manager
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Exiting Recipe Manager..."); // Display a message to indicate that the manager is exiting
                        Console.ResetColor();
                        Environment.Exit(0); // Exit the manager
                        break;
                    default: // Default case to handle invalid input
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input, please choose one of the options"); // Display an error message for invalid input
                        Console.ResetColor();
                        break;
                };
            }
        }
        //-----------------------------------------------------------------------------------------------------------//
    }
    //-----------------------------------------------------------------------------------------------------------//
}
//-----------------------------------------------END OF FILE------------------------------------------------------------//