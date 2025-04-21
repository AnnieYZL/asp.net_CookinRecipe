namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin Comment
    /// </summary>
    public class Comment
    {
        public long CommentID { get; set; }
        public long UserID { get; set; }
        public long RecipeID {  get; set; }
        public DateTime CreatedAt { get; set; }
        public string CommentContent { get; set; } = string.Empty;
    }
}
