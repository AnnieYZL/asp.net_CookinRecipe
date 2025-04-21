namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin bảng phụ Công thức - Nguyên liệu
    /// </summary>
    public class RecipeIngredient
    {
        public long RecipeID { get; set; }
        public int IngredientID { get; set; }
        public float Quantity { get; set; }
    }
}
