# Recipe Manager Application

This README provides instructions on how to compile and run the Recipe Manager application, which is a simple console application written in C# using .NET Framework 4.8.

## Prerequisites

- Microsoft .NET Framework 4.8
- A compatible IDE for .NET development (e.g., Visual Studio 2022)

## Setup Environment

1. Ensure you have the .NET Framework 4.8 installed on your system. You can check your installed versions from the Control Panel under Programs and Features, or by checking the registry.
2. If you do not have the .NET Framework installed, you can download it from [Microsoft .NET Framework 4.8 Download](https://dotnet.microsoft.com/download/dotnet-framework/net48).

## Cloning the Repository

Clone the repository to your local machine using the following command:

```bash
git clone https://github.com/ST10303017/ST10303017_PROG6221_POE.git
```

## Compiling the Application

1. Open the solution file `.sln` in Visual Studio.
2. Once open, you can build the project by navigating to:

```
Build -> Build Solution
```

This will compile the application and check for any compile-time errors.

## Running the Application

After successfully compiling the application, you can run it directly from Visual Studio by pressing `F5` or by navigating to:

```
Debug -> Start Debugging
```

This will start the application and you will see the Recipe Manager's menu prompt in the console.

## Usage

Follow the on-screen prompts to interact with the Recipe Manager. The application allows you to:

- Create a new recipe
- Display all recipes
- Display a recipe
- Scale a recipe
- Reset ingredient quantities
- Clear all recipe data
- Exit the application

## Updates

### Initial Updates

The following updates were implemented to enhance the functionality of the Recipe Manager application:

1. **Use of Generic Collections:** Replaced arrays with generic collections for managing recipes, ingredients, and steps.
2. **Delegates:** Implemented delegates to notify users when the total calories of a recipe exceed 300.
3. **Alphabetical Order:** Recipes are displayed in alphabetical order by name.
4. **Calories and Food Group:** For each ingredient, users can now enter the number of calories and the food group it belongs to.
5. **Total Calories Calculation:** The software calculates and displays the total calories of all ingredients in a recipe.
6. **Calories Notification:** The software notifies users when the total calories of a recipe exceed 300.

### Lecturer Feedback

Based on the feedback from the lecturer, the following additional updates were made:

1. **Unit of Measurement Scaling:** Ensured that the units of measurement are changed correctly when scaling recipe ingredients.
2. **Confirmation Before Clearing Data:** Added a confirmation prompt to ensure the user wants to clear all recipe data before performing the clear action.

## References

- Troelsen, A., & Japikse, P. (2022). Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. New York: Apress Media LLC.
- W3Schools. (2024). C# Exceptions - Try..Catch. Retrieved from [W3Schools](https://www.w3schools.com/cs/cs_exceptions.php)
- Chand, M. (2018, October 4). Change Console Foreground And Background Color In C#. Retrieved from [C# Corner](https://www.c-sharpcorner.com/article/change-console-foreground-and-background-color-in-c-sharp/)
