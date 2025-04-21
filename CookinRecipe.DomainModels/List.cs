namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin về Danh sách lưu
    /// </summary>
    public class List
    {
        public long ListID { get; set; }
        public long UserID { get; set; }
        public string ListName { get; set; } = string.Empty;
        public string ListImage { get; set; } = string.Empty;
    }
}
