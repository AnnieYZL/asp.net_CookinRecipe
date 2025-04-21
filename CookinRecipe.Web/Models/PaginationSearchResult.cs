using CookinRecipe.DomainModels;

namespace CookinRecipe.Web.Models
{
	/// <summary>
	/// Lớp cơ sở cho các kết quả tìm kiếm, hiển thị dưới dạng phân trang
	/// </summary>
	public class PaginationSearchResult
	{
		public int Page { get; set; } = 1;
		public int PageSize { get; set; }
		public string SearchValue { get; set; } = "";
		public int RowCount { get; set; } = 0;

		public int PageCount
		{
			get
			{
				if (PageSize == 0) return 1;
				int n = RowCount / PageSize;
				if (RowCount % PageSize > 0) n += 1;
				return n;
			}
		}
	}

	public class CourseSearchResult : PaginationSearchResult
	{
		public List<Course>? Data { get; set; }
	}
	public class RecipeByCourse : PaginationSearchResult
	{
		public Course? Course { get; set; }
		public List<Recipe>? Data { get; set; }
	}
    public class RecipeByIngredient : PaginationSearchResult
    {
        public List<Ingredient>? ListIngre { get; set; }
        public List<Recipe>? Data { get; set; }
    }

    public class DishSearchResult : PaginationSearchResult
	{
		public List<Dish>? Data { get; set; }
	}
}
