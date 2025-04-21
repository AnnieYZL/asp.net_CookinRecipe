namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin Đánh giá sao
    /// </summary>
    public class Rating
    {
        public long UserID { get; set; }
        public long RecipeID {  get; set; }
        public int Point {  get; set; }
        public bool IsCancel { get; set; }
    }
}
