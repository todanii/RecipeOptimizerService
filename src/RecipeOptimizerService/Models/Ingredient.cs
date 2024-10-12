namespace RecipeOptimizerService.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Ingredient(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
