using Microsoft.AspNetCore.Mvc;
using RecipeOptimizerService.Services;

namespace RecipeOptimizerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("maxPeopleFed")]
        public ActionResult<int> GetMaxPeopleFed()
        {
            var result = _recipeService.CalculateMaxPeopleFed();
            return Ok(result);
        }
    }
}
