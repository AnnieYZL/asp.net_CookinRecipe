namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin Ghi chú của công thức
    /// </summary>
    public class Note
    {
        public long RecipeID { get; set; }
        public int NoteNumber { get; set; }
        public string NoteContent { get; set; } = string.Empty;

    }
}
