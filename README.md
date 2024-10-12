# RecipeOptimizerService

## Overview

RecipeOptimizerService is a microservice that takes a list of available ingredients and a set of recipes, and calculates the maximum number of people that can be fed. The API includes functionality to generate all permutations of recipes and determine the best combination based on available ingredients.

## Features
- Calculate the optimal combination of recipes to feed the maximum number of people.
- Retrieve the number of people fed and the list of recipes used.
- In-memory repository for ingredients and recipes.
- Unit tests to verify service functionality, including mocks using Moq.

## Project Structure

- `Controllers/RecipeController.cs`: Exposes the API endpoint to calculate the maximum number of people fed.
- `Services/RecipeService.cs`: Core business logic that handles the calculation of people fed.
- `Repositories/IRecipeRepository.cs`: Interface for the repository that provides access to recipe and ingredient data.
- `Repositories/InMemoryRecipeRepository.cs`: In-memory implementation of the repository.
- `Models`: Contains data models for Recipe and Ingredient.
- `Tests/RecipeServiceTests.cs`: Unit tests using Moq to mock the repository and verify service behavior.

## Dependencies

Before running the application, you need to install the following dependencies:

1. **.NET Core SDK** (6.0 or later) - Install from [here](https://dotnet.microsoft.com/download).
2. **Moq** - For mocking repository behavior in unit tests.
