using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10303017_PROG6221_POE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Classes.Recipe recipeManager = new Classes.Recipe();
            recipeManager.displayRecipe();
        }
    }
}
