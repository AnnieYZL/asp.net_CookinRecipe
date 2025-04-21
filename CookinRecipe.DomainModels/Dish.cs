namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin về Kiểu món ăn
    /// </summary>
    public class Dish
    {
        public int DishID { get; set; }
        public string DishName { get; set; } = string.Empty;
        public string DishImage { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
