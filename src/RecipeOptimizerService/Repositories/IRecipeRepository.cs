using RecipeOptimizerService.Models;

namespace RecipeOptimizerService.Repositories
{
    public interface IRecipeRepository
    {
        List<Recipe> GetRecipes();
        List<Ingredient> GetAvailableIngredients();
    }
}
