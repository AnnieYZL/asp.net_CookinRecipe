using CookinRecipe.DomainModels;

namespace CookinRecipe.Web.Models
{
	public class RecipeSearchResult : PaginationSearchResult
	{
		public int DishID { get; set; }
		public int CourseID { get; set; }
		public int IngredientID { get; set; }
        public List<Recipe>? Data { get; set; }
    }
}
