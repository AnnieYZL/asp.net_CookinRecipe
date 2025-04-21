using CookinRecipe.DomainModels;

namespace CookinRecipe.Web.Models
{
	public class PaginationSearchInput
	{
		public int Page { get; set; } = 1;
		public int Size { get; set; } = 0;
		public string SearchValue { get; set; } = string.Empty;
	}
    public class RecipeByIngredientInput : PaginationSearchResult
    {
        public List<int>? ListIngre { get; set; }
    }
}
