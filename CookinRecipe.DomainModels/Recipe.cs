namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin về Công thức 
    /// </summary>
    public class Recipe
    {
        public long RecipeID { get; set; }
        public string RecipeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int PrepTime { get; set; }
        public string Serving { get; set; } = string.Empty;
        /// <summary>
        /// 0: Dễ ; 1: Trung bình; 2: Khó
        /// </summary>
        public int Difficulty { get; set; }
        public string RecipeImage { get; set; } = string.Empty;
        public string RecipeVideo {  get; set; } = string.Empty;
        public float Energy { get; set; }
        public long AuthorID { get; set; }
        public bool IsVerify {  get; set; }
        public bool IsRemove { get; set; }

    }
}
