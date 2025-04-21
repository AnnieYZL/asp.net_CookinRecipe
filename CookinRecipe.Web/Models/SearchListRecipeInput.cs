namespace CookinRecipe.Web.Models
{
    /// <summary>
    /// Đầu vào tìm kiếm dữ liệu dưới dạng phân trang
    /// </summary>
    public class SearchListRecipeInput
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string searchValue { get; set; } = string.Empty;

    }
}
