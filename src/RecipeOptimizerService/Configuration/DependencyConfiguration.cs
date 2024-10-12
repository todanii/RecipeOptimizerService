using RecipeOptimizerService.Repositories;
using RecipeOptimizerService.Services;

namespace RecipeOptimizerService.Configuration
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection ConfigureApplicationDependencies(
        this IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeService, RecipeService>();
            return services;
        }
    }
}
