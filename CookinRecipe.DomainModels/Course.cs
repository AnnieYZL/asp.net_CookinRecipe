namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin về Thực đơn
    /// </summary>
    public class Course
    {
        public int CourseID { get; set; } 
        public string CourseName { get; set; } = string.Empty;
        public string CourseImage { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
