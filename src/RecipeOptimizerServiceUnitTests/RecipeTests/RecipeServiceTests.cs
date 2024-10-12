using Moq;
using RecipeOptimizerService.Models;
using RecipeOptimizerService.Repositories;
using RecipeOptimizerService.Services;

namespace RecipeOptimizerServiceUnitTests.RecipeTests
{
    public class RecipeServiceTests
    {
        private readonly Mock<IRecipeRepository> _repositoryMock;
        private readonly RecipeService _service;

        public RecipeServiceTests()
        {
            _repositoryMock = new Mock<IRecipeRepository>();
            _service = new RecipeService(_repositoryMock.Object);
        }

        [Fact]
        public void CalculateMaxPeopleFed_ShouldReturnCorrectResult_WhenRepositoryReturnsData()
        {
            var recipes = new List<Recipe>
            {
                new Recipe("Burger", 1, new List<Ingredient>
                {
                    new Ingredient("Meat", 1 ),
                    new Ingredient("Lettuce", 1 ),
                    new Ingredient("Tomato", 1 ),
                    new Ingredient("Cheese", 1 ),
                    new Ingredient("Dough", 1 )
                }),
                new Recipe("Salad", 3, new List<Ingredient>
                {
                    new Ingredient("Lettuce", 2 ),
                    new Ingredient("Tomato", 1 ),
                    new Ingredient("Cucumber", 1 ),
                    new Ingredient("Cheese", 2 ),
                    new Ingredient("Olives", 1 )
                })
            };
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Meat", 5),
                new Ingredient("Lettuce", 5),
                new Ingredient("Tomato", 5),
                new Ingredient("Cheese", 5),
                new Ingredient("Dough", 5),
                new Ingredient("Cucumber", 5),
                new Ingredient("Olives", 5)
            };

            _repositoryMock.Setup(r => r.GetRecipes()).Returns(recipes);
            _repositoryMock.Setup(r => r.GetAvailableIngredients()).Returns(ingredients);

            var result = _service.CalculateMaxPeopleFed();

            Assert.Equal(7, result.TotalPeopleFed);  
            Assert.Contains("Burger", result.FoodCombinations);
            Assert.Contains("Salad", result.FoodCombinations);

            _repositoryMock.Verify(r => r.GetRecipes(), Times.Once);
            _repositoryMock.Verify(r => r.GetAvailableIngredients(), Times.Once);
        }

        [Fact]
        public void CalculateMaxPeopleFed_ShouldReturnZero_WhenNoValidCombinations()
        {
            var recipes = new List<Recipe>
            {
                new Recipe("Pizza", 4, new List<Ingredient>
                {
                    new Ingredient("Dough", 3 ),
                    new Ingredient("Tomato", 2 ),
                    new Ingredient("Cheese", 3 ),
                    new Ingredient("Olives", 1 )
                })
            };
            var ingredients = new List<Ingredient>();  

            _repositoryMock.Setup(r => r.GetRecipes()).Returns(recipes);
            _repositoryMock.Setup(r => r.GetAvailableIngredients()).Returns(ingredients);

            var result = _service.CalculateMaxPeopleFed();

            Assert.Equal(0, result.TotalPeopleFed);
            Assert.Empty(result.FoodCombinations);

            _repositoryMock.Verify(r => r.GetRecipes(), Times.Once);
            _repositoryMock.Verify(r => r.GetAvailableIngredients(), Times.Once);
        }

        [Fact]
        public void CalculateMaxPeopleFed_ShouldReturnCorrectResult_WhenRepositoryReturnsData2()
        {
            var recipes = new List<Recipe>
            {
                new Recipe("Pie", 2, new List<Ingredient>
                {
                    new Ingredient("Dough", 2 ),
                    new Ingredient("Meat", 2 )
                })
            };
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Dough", 2),
                new Ingredient("Meat", 2)
            };

            _repositoryMock.Setup(r => r.GetRecipes()).Returns(recipes);
            _repositoryMock.Setup(r => r.GetAvailableIngredients()).Returns(ingredients);

            // Act
            var result = _service.CalculateMaxPeopleFed();

            // Assert
            Assert.Equal(2, result.TotalPeopleFed);
        }
    }
}
