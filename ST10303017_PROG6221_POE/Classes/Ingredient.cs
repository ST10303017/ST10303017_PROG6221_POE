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

namespace ST10303017_PROG6221_POE.Classes
{
    // Class to store the ingredients of a recipe
    // Contains the name of the ingredient, the quantity, the measurement and the original quantity
    //---------------------------------------------------------------------------------------------------//
    public class Ingredient
    {
        // Attributes of the ingredeint class
        public string ingredientName { get; set; }
        public double ingredientQuantity { get; set; }
        public string ingredientMeasurement { get; set; }
        public double originalQuantity { get; set; }

        // Constructor for the ingredient class
        // Takes in the name of the ingredient, the quantity, the measurement and the original quantity
        //---------------------------------------------------------------------------------------------------//
        public Ingredient(string ingredientName, double ingredientQuantity, string ingredientMeasurement, double originalQuantity)
        {
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.ingredientMeasurement = ingredientMeasurement;
            this.originalQuantity = originalQuantity;
        }
        //---------------------------------------------------------------------------------------------------//
    }
    //---------------------------------------------------------------------------------------------------//
}
//---------------------------------------------------------------------------------------------------//
