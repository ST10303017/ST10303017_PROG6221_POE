# Recipe Manager Application

This README provides instructions on how to compile, run, and test the Recipe Manager application, which is a simple console application written in C# using .NET Framework 4.8. The application has been updated with a graphical user interface (GUI) using Windows Presentation Foundation (WPF).

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
- Filter recipes by ingredient, food group, or maximum number of calories
- Exit the application

## Updates

The following updates were implemented to enhance the functionality of the Recipe Manager application:

1. **Graphical User Interface (GUI):** Converted the console application to a WPF application for a more user-friendly interface.
2. **Food Group Selection:** Users can now select the food group from a predefined list of options in a dropdown menu.
3. **Calorie Explanation:** The application provides explanations of what calories are and the significance of different calorie ranges.
4. **Calorie Alerts:** The application displays detailed calorie alerts based on specific ranges when a recipe is added.
5. **Filtering Recipes:** Users can filter recipes by entering the name of an ingredient, choosing a food group, or selecting a maximum number of calories.

### Lecturer Feedback Implementation

The recent feedback from the lecturer was thoroughly implemented to enhance user experience and provide better usability. One of the major enhancements was providing explanations to the user regarding calories and food groups. This was achieved by adding text blocks in the GUI that describe what calories are, the significance of different calorie ranges, and how food groups classify foods according to their nutritional value. This information helps users make more informed choices when creating their recipes.

Additionally, I updated the application to include detailed calorie alerts based on specific ranges. When a recipe is added, the application now displays a message that informs users whether the recipe is low, moderate, or high in calories. For example, if the total calories are less than 200, a message will inform the user that the recipe is suitable for a snack. If the calories are between 200 and 500, the message indicates that the recipe is suitable for a balanced meal. For recipes with more than 500 calories, the message advises that the recipe should be consumed sparingly. These detailed alerts provide users with better insights into the nutritional value of their recipes, ensuring they are well-informed about their dietary choices.

## References

- Troelsen, A., & Japikse, P. (2022). Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming. New York: Apress Media LLC.
- W3Schools. (2024). C# Exceptions - Try..Catch. Retrieved from [W3Schools](https://www.w3schools.com/cs/cs_exceptions.php)
- Chand, M. (2018, October 4). Change Console Foreground And Background Color In C#. Retrieved from [C# Corner](https://www.c-sharpcorner.com/article/change-console-foreground-and-background-color-in-c-sharp/)
