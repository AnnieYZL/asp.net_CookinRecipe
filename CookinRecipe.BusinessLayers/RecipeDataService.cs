using CookinRecipe.DataLayers;
using CookinRecipe.DataLayers.SQLServer;
using CookinRecipe.DomainModels;

namespace CookinRecipe.BusinessLayers
{
    public static class RecipeDataService
    {
        private static readonly IRecipeDAL recipeDB;
        static RecipeDataService()
        {
            recipeDB = new RecipeDAL(Configuration.ConnectionString);
        }
        /// <summary>
        /// Bổ sung công thức mới, trả về mã của công thức được bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static long Add(Recipe data)
        {
            return recipeDB.Add(data);
        }
        /// <summary>
        /// Xóa công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static bool Delete(long RecipeID)
        {
            return recipeDB.Delete(RecipeID);
        }
        /// <summary>
        /// Lấy công thức dựa vào mã
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static Recipe? Get(long RecipeID)
        {
            return recipeDB.Get(RecipeID);
        }
        /// <summary>
        /// Tìm kiếm và lấy danh sách công thức dưới dạng phân trang
        /// </summary>
        /// <param name="count"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Recipe> List(out int count, int page = 1, int pageSize = 0, string searchValue = "")
        {
            count = recipeDB.Count(searchValue);
            return recipeDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Cập nhật công thức
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Update(Recipe data)
        {
            return recipeDB.Update(data);
        }
        /// <summary>
        /// Thêm ds nguyên liệu cho công thức
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddIngredients(List<RecipeIngredient> data)
        {
            return recipeDB.AddIngredients(data);
        }
        /// <summary>
        /// Xóa ds nguyên liệu của công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static bool DeleteIngredients(long RecipeID)
        {
            return recipeDB.DeleteIngredients(RecipeID);
        }
        /// <summary>
        /// Lấy ds nguyên liệu của ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static List<RecipeIngredient> ListIngredients(long RecipeID)
        {
            return recipeDB.ListIngredients(RecipeID).ToList();
        }
        /// <summary>
        /// Thêm ds ghi chú cho ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddNotes(Note data)
        {
            return recipeDB.AddNotes(data);
        }
        /// <summary>
        /// Xóa ds ghi chú của công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static bool DeleteNotes(long RecipeID)
        {
            return recipeDB.DeleteNotes(RecipeID);
        }
        /// <summary>
        /// Lấy ds ghi chú của ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static List<Note> ListNotes(long RecipeID)
        {
            return recipeDB.ListNotes(RecipeID).ToList();
        }
        /// <summary>
        /// Thêm ds bước làm cho ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSteps(Step data)
        {
            return recipeDB.AddSteps(data);
        }
        /// <summary>
        /// Xóa ds bước làm của công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static bool DeleteSteps(long RecipeID)
        {
            return recipeDB.DeleteSteps(RecipeID);
        }
        /// <summary>
        /// Lấy ds bước làm của ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static List<Step> ListSteps(long RecipeID)
        {
            return recipeDB.ListSteps(RecipeID).ToList();
        }
        /// <summary>
        /// Thêm ct vào danh sách lưu
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public static int AddToList(long RecipeID, long ListID)
        {
            return recipeDB.AddToList(RecipeID, ListID);
        }
        /// <summary>
        /// Xóa ct khỏi ds lưu
        /// </summary>
        /// <param name="ListID"></param>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static bool DeleteFromList(long ListID, long RecipeID)
        {
            return recipeDB.DeleteFromList(ListID, RecipeID);
        }
        /// <summary>
        /// Đếm số cmt của 1 ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static int CountCmt(long RecipeID)
        {
            return recipeDB.CountCmt(RecipeID);
        }
        /// <summary>
        /// Đếm số lượt thích của 1 ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static int CountFav(long RecipeID)
        {
            return recipeDB.CountFav(RecipeID);
        }
        /// <summary>
        /// Đếm số lượt đánh giá của 1 ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static int CountRate(long RecipeID)
        {
            return recipeDB.CountRate(RecipeID);
        }
        /// <summary>
        /// Lấy điểm đánh giá của 1 ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static float GetRate(long RecipeID)
        {
            return recipeDB.GetRate(RecipeID);
        }
        /// <summary>
        /// Lấy danh sách công thức trong thực đơn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Recipe> GetRecipeListByCourse(int id)
        {
            return recipeDB.GetRecipeListByCourse(id).ToList();
        }
        /// <summary>
        /// Lấy danh sách công thức trong kiểu món ăn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Recipe> GetRecipeListByDish(int id)
        {
            return recipeDB.GetRecipeListByCourse(id).ToList();
        }
        /// <summary>
        /// Lấy 8 công thức mới nhất
        /// </summary>
        /// <returns></returns>
        public static List<Recipe> GetNewestRecipe()
        {
            return recipeDB.GetNewestRecipe().ToList();
        }
		/// <summary>
		/// Lấy 3 nguyên liệu chính của ct
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static List<Ingredient> GetMainIngredient(long id)
		{
			return recipeDB.ListMainIngredients(id).ToList();
		}
        /// <summary>
        /// Lấy list công thức dựa trên list nguyên liệu
        /// </summary>
        /// <returns></returns>
        public static List<Recipe> GetListRecipeByIngre(List<int> listIng)
        {
            return recipeDB.GetListRecipe(listIng).ToList();
        }
        /// <summary>
        /// Lấy ds công thức của 1 người dùng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
		public static IList<Recipe> ListRecipeOfUser(long id)
        {
            return recipeDB.ListRecipeOfUser(id).ToList();
        }
        /// <summary>
        /// Lấy taglist nguyên liệu
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static IList<Ingredient> ListTagIngredients(long RecipeID)
        {
            return recipeDB.ListTagIngredients(RecipeID).ToList();
        }
        /// <summary>
        /// Lấy ds thực đơn có chứa ct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<Course> GetCoursesOf(long id)
        {
            return recipeDB.GetCoursesOf(id).ToList();
        }
        /// <summary>
        /// Xóa ds thực đơn có chứa ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static bool DeleteRecipeInCourse(long RecipeID)
        {
            return recipeDB.DeleteRecipeInCourse(RecipeID);
        }
        /// <summary>
        /// Thêm ct vào ds thực đơn
        /// </summary>
        /// <param name="CourseList"></param>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        public static int AddRecipeInCourse(int CourseId, long RecipeID)
        {
            return recipeDB.AddRecipeInCourse(CourseId, RecipeID);
        }
        /// <summary>
        /// Set chỉ số năng lượng cho công thức
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public static bool SetEnergy(long recipeId)
        {
            return recipeDB.SetEnergy(recipeId);
        }
    }
}
