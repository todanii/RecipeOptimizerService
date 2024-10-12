namespace RecipeOptimizerService.Services
{
    using RecipeOptimizerService.Models;
    using RecipeOptimizerService.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;

        public RecipeService(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public PeopleFedResult CalculateMaxPeopleFed()
        {
            var availableIngredients = _repository.GetAvailableIngredients();
            var recipes = _repository.GetRecipes();

            return GetMaxPeopleFed(availableIngredients, recipes);
        }

        private PeopleFedResult GetMaxPeopleFed(List<Ingredient> availableIngredients, List<Recipe> recipes)
        {
            var permutations = GetPermutations(recipes, recipes.Count);

            PeopleFedResult bestResult = new PeopleFedResult(0, new Dictionary<string, int>());

            foreach (var perm in permutations)
            {
                List<Recipe> recipeOrder = perm.ToList();

                var result = CalculatePeopleFed(availableIngredients, recipeOrder);

                if (result.TotalPeopleFed > bestResult.TotalPeopleFed)
                {
                    bestResult = result;
                }
            }

            return bestResult;
        }

        // Function to generate all permutations of the recipe list
        private IEnumerable<IEnumerable<T>> GetPermutations<T>(List<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                            (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        private PeopleFedResult CalculatePeopleFed(List<Ingredient> availableIngredients, List<Recipe> recipes)
        {
            Dictionary<string, int> ingredientsDict = availableIngredients.ToDictionary(i => i.Name, i => i.Quantity);
            int totalPeopleFed = 0;
            Dictionary<string, int> foodCombination = new Dictionary<string, int>();

            // Attempt to make each recipe as many times as possible
            foreach (var recipe in recipes)
            {
                int servings = int.MaxValue;

                // Calculate how many times we can make this recipe
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (ingredientsDict.ContainsKey(ingredient.Name))
                    {
                        servings = Math.Min(servings, ingredientsDict[ingredient.Name] / ingredient.Quantity);
                    }
                    else
                    {
                        servings = 0;
                        break;
                    }
                }

                // Update available ingredients and total people fed
                if (servings > 0)
                {
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        ingredientsDict[ingredient.Name] -= ingredient.Quantity * servings;
                    }

                    totalPeopleFed += servings * recipe.Feeds;
                    foodCombination.Add(recipe.Name, servings);
                }
            }

            PeopleFedResult result = new PeopleFedResult(totalPeopleFed, foodCombination);
            return result;
        }
    }
}


