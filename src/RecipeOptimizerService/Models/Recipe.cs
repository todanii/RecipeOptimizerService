namespace RecipeOptimizerService.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public int Feeds { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Recipe(string name, int feeds, List<Ingredient> ingredients)
        {
            Name = name;
            Feeds = feeds;
            Ingredients = ingredients;
        }
    }
}
