using CookinRecipe.DomainModels;

namespace CookinRecipe.Web.Models
{
	/// <summary>
	/// Tìm kiếm công thức theo thực đơn, món ăn, nguyên liệu
	/// </summary>
	public class RecipeSearchResult : PaginationSearchResult
	{
		public int DishID { get; set; }
		public int CourseID { get; set; }
		public int IngredientID { get; set; }
        public List<Recipe>? Data { get; set; }
    }
}
