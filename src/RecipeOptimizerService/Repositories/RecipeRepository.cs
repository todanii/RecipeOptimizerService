using RecipeOptimizerService.Models;

namespace RecipeOptimizerService.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        public List<Recipe> GetRecipes()
        {
            return new List<Recipe>
            {
                new Recipe("Burger", 1, new List<Ingredient>
                {
                    new Ingredient("Meat", 1 ),
                    new Ingredient("Lettuce", 1 ),
                    new Ingredient("Tomato", 1 ),
                    new Ingredient("Cheese", 1 ),
                    new Ingredient("Dough", 1 )
                }),
                new Recipe("Pie", 1, new List<Ingredient>
                {
                    new Ingredient("Dough", 2 ),
                    new Ingredient("Meat", 2 )
                }),
                new Recipe("Sandwich", 1, new List<Ingredient>
                {
                    new Ingredient("Dough", 1 ),
                    new Ingredient("Cucumber", 1 )
                }),
                new Recipe("Pasta", 2, new List<Ingredient>
                {
                    new Ingredient("Dough", 2 ),
                    new Ingredient("Tomato", 1 ),
                    new Ingredient("Cheese", 2 ),
                    new Ingredient("Meat", 1 )
                }),
                new Recipe("Salad", 3, new List<Ingredient>
                {
                    new Ingredient("Lettuce", 2 ),
                    new Ingredient("Tomato", 2 ),
                    new Ingredient("Cucumber", 1 ),
                    new Ingredient("Cheese", 2 ),
                    new Ingredient("Olives", 1 )
                }),
                new Recipe("Pizza", 4, new List<Ingredient>
                {
                    new Ingredient("Dough", 3 ),
                    new Ingredient("Tomato", 2 ),
                    new Ingredient("Cheese", 3 ),
                    new Ingredient("Olives", 1 )
                })
            };
        }

        public List<Ingredient> GetAvailableIngredients()
        {
            return new List<Ingredient>
            {
                new Ingredient("Cucumber", 2 ),
                new Ingredient("Olives", 2 ),
                new Ingredient("Lettuce", 3 ),
                new Ingredient("Meat", 6 ),
                new Ingredient("Tomato", 6 ),
                new Ingredient("Cheese", 8 ),
                new Ingredient("Dough", 10 )
            };
        }
    }
}