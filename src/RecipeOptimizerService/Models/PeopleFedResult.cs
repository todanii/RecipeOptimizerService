namespace RecipeOptimizerService.Models
{
    public class PeopleFedResult
    {
        public int TotalPeopleFed { get; set; }
        public Dictionary<string, int> FoodCombinations { get; set; }

        public PeopleFedResult(int totalPeopleFed, Dictionary<string, int> foodCombinations)
        {
            TotalPeopleFed = totalPeopleFed;
            FoodCombinations = foodCombinations;
        }
    }
}
