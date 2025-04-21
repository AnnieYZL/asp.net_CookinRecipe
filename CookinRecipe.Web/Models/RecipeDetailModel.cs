using CookinRecipe.DomainModels;

namespace CookinRecipe.Web.Models
{
    public class RecipeDetailModel
    {
        public Recipe Recipe { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public List<Note> Notes { get; set; } 
        public List<Comment> Comments { get; set; }
        public int RowCount = 0;
    }
}
