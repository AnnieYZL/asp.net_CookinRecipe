namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin về Nguyên liệu
    /// </summary>
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public float Energy { get; set; }
        public bool IsMain { get; set; }
    }
}
