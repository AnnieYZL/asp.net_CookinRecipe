using CookinRecipe.DomainModels;

namespace CookinRecipe.Web.Models
{
	/// <summary>
	/// Đầu vào tìm kiếm để nhận dữ liệu dưới dạng phân trang
	/// </summary>
	public class RecipeSearchInput
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
		public string SearchValue { get; set; } = string.Empty;
		public int DishID { get; set; } = 0;
		public int CourseID { get; set; } = 0;
		public int IngredientID { get; set; } = 0;
		public List<Recipe>? ListRecipe { get; set; }
	}
}
