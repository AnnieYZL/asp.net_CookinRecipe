namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin về Lượt xem công thức
    /// </summary>
    public class View
    {
        public long RecipeID { get; set; }
        public long UserID { get; set; }
        public string IPAddress { get; set; } = string.Empty;
        public DateTime LastView { get; set; }
        public long ViewCount { get; set; }
    }
}
