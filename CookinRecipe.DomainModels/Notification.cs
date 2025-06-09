namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin về Thông báo
    /// </summary>
    public class Notification
    {
        public long NotificationID { get; set; }
        public long UserID { get; set; }
        public long? RecipeID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public long? AdminID { get; set; }
    }
    public class NotificationIdModel
    {
        public long Id { get; set; }
    }

}
