namespace ST10303017_PROG6221_POE.Classes
{
    public class Ingredient
    {
        public string ingredientName { get; set; }
        public double ingredientQuantity { get; set; }
        public string ingredientMeasurement { get; set; }
        public double originalQuantity { get; set; }
        public double ingredientCalories { get; set; }
        public string ingredientFoodGroup { get; set; }

        public Ingredient(string ingredientName, double ingredientQuantity, string ingredientMeasurement, double originalQuantity, double calories, string foodGroup)
        {
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.ingredientMeasurement = ingredientMeasurement;
            this.originalQuantity = originalQuantity;
            ingredientCalories = calories;
            ingredientFoodGroup = foodGroup;
        }
    }
}
