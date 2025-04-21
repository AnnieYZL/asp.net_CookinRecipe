namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin bảng Yêu thích
    /// </summary>
    public class Favourite
    {
        public long UserID { get; set; }
        public long RecipeID { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCancel {  get; set; }
    }
}
