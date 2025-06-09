using CookinRecipe.DomainModels;

namespace CookinRecipe.DataLayers
{
    public interface IRecipeDAL
    {
        /// <summary>
        /// Lấy toàn bộ ds (đã duyệt)
        /// </summary>
        /// <returns></returns>
        IList<Recipe> GetAllRecipes();
        /// <summary>
        /// Lấy toàn bộ ds (chưa duyệt)
        /// </summary>
        /// <returns></returns>
        IList<Recipe> GetAllVerifies();

        /// <summary>
        /// Tìm kiếm và lấy danh sách công thức dưới dạng phân trang
        /// </summary>
        /// <param name="page">Trang cần hiển thị</param>
        /// <param name="pageSize">Số công thức trên mỗi trang (0 nếu không phân trang)</param>
        /// <param name="searchValue">Tên công thức cần tìm (Chuỗi rỗng nếu không tìm kiếm)</param>
        /// <returns></returns>
        IList<Recipe> List(int page = 1, int pageSize = 0, string searchValue = "");

        /// <summary>
        /// Đếm số lượng công thức tìm kiếm được
        /// </summary>
        /// <param name="searchValue">Tên công thức cần tìm (chuỗi rỗng đều không tìm kiếm)</param>
        /// <returns></returns>
        int Count(string searchValue = "");

        /// <summary>
        /// Lấy thông tin công thức theo mã công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        Recipe? Get(long RecipeID);

        /// <summary>
        /// Bổ sung công thức mới (hàm trả về mã của công thức được bổ sung)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        long Add(Recipe data);

        /// <summary>
        /// Cập nhật công thức
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Recipe data);

        /// <summary>
        /// Xóa công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        bool Delete(long RecipeID);

        /// <summary>
        /// Thêm 1 Step của 1 công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        int AddSteps(Step data);

        /// <summary>
        /// Lấy danh sách bước làm của công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        IList<Step> ListSteps(long RecipeID);

        /// <summary>
        /// Xóa danh sách bước làm trước khi cập nhật
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool DeleteSteps(long RecipeID);

        /// <summary>
        /// Thêm danh sách Note của 1 công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        int AddNotes(Note data);

        /// <summary>
        /// Lấy danh sách ghi chú của công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        IList<Note> ListNotes(long RecipeID);

        /// <summary>
        /// Xóa danh sách ghi chú của công thức trước khi cập nhật
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool DeleteNotes(long RecipeID);

        /// <summary>
        /// Xóa danh sách thực đơn chứa công thức trước khi cập nhật
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        bool DeleteRecipeInCourse(long RecipeID);
        /// <summary>
        /// Thêm 1 công thức vào thực đơn
        /// </summary>
        /// <param name="CourseID"></param>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        int AddRecipeInCourse(int CourseId, long  RecipeID);

        /// <summary>
        /// Đếm số lượng lượt thích của công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        int CountFav(long RecipeID);
        /// <summary>
        /// Thêm một công thức vào 1 list
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="ListID"></param>
        /// <returns></returns>
        int AddToList(long  RecipeID, long ListID);
        /// <summary>
        /// Thêm 1 nguyên liệu cho công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="IngredientID"></param>
        /// <returns></returns>
        int AddIngredients(List<RecipeIngredient> data);
        /// <summary>
        /// Lấy danh sách nguyên liệu của công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        IList<RecipeIngredient> ListIngredients(long RecipeID);

		/// <summary>
		/// Lấy 3 nguyên liệu chính của công thức
		/// </summary>
		/// <param name="RecipeID"></param>
		/// <returns></returns>
		IList<Ingredient> ListMainIngredients(long RecipeID);
        /// <summary>
		/// Lấy ds nguyên liệu của công thức
		/// </summary>
		/// <param name="RecipeID"></param>
		/// <returns></returns>
		IList<Ingredient> ListTagIngredients(long RecipeID);

        /// <summary>
        /// Xóa danh sách nguyên liệu của công thức trước khi cập nhật
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool DeleteIngredients(long RecipeID);
        /// <summary>
        /// Đếm số lượng bình luận của 1 công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        int CountCmt(long RecipeID);
        /// <summary>
        /// Tính số điểm trung bình của công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        float GetRate(long RecipeID);
        /// <summary>
        /// Đếm số người đã đánh giá công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        int CountRate(long RecipeID);
        /// <summary>
        /// Xóa 1 bài viết khỏi 1 list
        /// </summary>
        /// <param name="ListID"></param>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        bool DeleteFromList(long ListID, long RecipeID);
        /// <summary>
        /// Lấy danh sách công thức trong thực đơn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<Recipe> GetRecipeListByCourse(int id);
        /// <summary>
        /// Lấy danh sách công thức trong món ăn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<Recipe> GetRecipeListByDish(int id);
        /// <summary>
        /// Lấy 8 công thức mới nhất
        /// </summary>
        /// <returns></returns>
        IList<Recipe> GetNewestRecipe();
        /// <summary>
        /// Lấy ds công thức dựa vào ds nguyên liệu
        /// </summary>
        /// <returns></returns>
        IList<Recipe> GetListRecipe(List<int> ListIng);
		/// <summary>
		/// Lấy ds công thức của người dùng
		/// </summary>
		/// <returns></returns>
		IList<Recipe> ListRecipeOfUser(long id);
        /// <summary>
        /// Lấy những thực đơn có chứa ct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<Course> GetCoursesOf(long id);
        /// <summary>
        /// Set chỉ số năng lượng cho công thức
        /// </summary>
        /// <param name="listIngredient"></param>
        /// <param name="listQuantity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool SetEnergy(long id);
        /// <summary>
        /// Phê duyệt công thức
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Verify(Recipe data);
        /// <summary>
        /// Hoàn tác phê duyệt
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool UndoVerify(Recipe data);
        /// <summary>
        /// Xem công thức đã tồn tại trong bộ sưu tập của người dùng hay chưa
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool CheckExistsInList(long recipeId, long userId);
        /// <summary>
        /// Xóa tb có liên quan tới công thức
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        bool DeleteNoti(long RecipeID);
        /// <summary>
        /// Xóa ds cmt có liên quan tới ct
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        bool DeleteComment(long RecipeID);
        /// <summary>
        /// Xóa lượt thích lquan
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        bool DeleteFav(long RecipeID);
        /// <summary>
        /// Xóa khỏi bst
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        bool DeleteList(long RecipeID);
        /// <summary>
        /// Xóa khỏi đánh giá
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        bool DeleteRate(long RecipeID);
    }
}
