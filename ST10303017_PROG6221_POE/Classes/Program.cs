/// <summary>
/// Calwyn Govender
/// ST10303017
/// 
/// -----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10303017_PROG6221_POE
{
    // Main class to run the program
    //---------------------------------------------------------------------------------------------------//
    internal class Program
    {
        // Main method to run the program
        static void Main(string[] args)
        {
            Classes.Recipe recipeManager = new Classes.Recipe(); // Create a new recipe object
            recipeManager.recipeMenu(); // Call the recipe menu method
        }
        //---------------------------------------------------------------------------------------------------//
    }
    //---------------------------------------------------------------------------------------------------//
}
//---------------------------------------------------------------------------------------------------//
