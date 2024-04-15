using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10303017_PROG6221_POE.Classes
{
    public class Ingredient
    {
        public string ingredientName { get; set; }
        public int ingredientQuantity { get; set; }
        public string ingredientMeasurement { get; set; }

        public Ingredient(string ingredientName, int ingredientQuantity, string ingredientMeasurement)
        {
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.ingredientMeasurement = ingredientMeasurement;
        }
    }
}
