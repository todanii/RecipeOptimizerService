using RecipeOptimizerService.Models;

namespace RecipeOptimizerService.Services
{
    public interface IRecipeService
    {
        PeopleFedResult CalculateMaxPeopleFed();
    }
}
