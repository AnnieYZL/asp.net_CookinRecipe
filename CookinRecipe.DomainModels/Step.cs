namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin về Bước nấu ăn
    /// </summary>
    public class Step
    {
        public long RecipeID { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
