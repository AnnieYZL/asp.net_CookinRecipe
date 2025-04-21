using CookinRecipe.DataLayers;
using CookinRecipe.DomainModels;

namespace CookinRecipe.BusinessLayers
{
    public static class CommonDataService
    {
        private static readonly ICommonDAL<Course> courseDB;
        private static readonly ICommonDAL<Dish> dishDB;
        private static readonly ICommonDAL<Ingredient> ingredientDB;
        private static readonly ICommonDAL<Notification> notificationDB;
        /// <summary>
        /// Ctor
        /// </summary>
        static CommonDataService()
        {
            courseDB = new DataLayers.SQLServer.CourseDAL(Configuration.ConnectionString);
            dishDB = new DataLayers.SQLServer.DishDAL(Configuration.ConnectionString);
            ingredientDB = new DataLayers.SQLServer.IngredientDAL(Configuration.ConnectionString);
            notificationDB = new DataLayers.SQLServer.NotificationDAL(Configuration.ConnectionString);
        }
        /// <summary>
        /// Thêm thực đơn
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCourse(Course data)
        {
            return courseDB.Add(data);
        }
        /// <summary>
        /// Xóa thực đơn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteCourse(int id)
        {
            return courseDB.Delete(id); 
        }
        /// <summary>
        /// Lấy thực đơn dựa vào mã
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Course? GetCourse(int id)
        {
            return courseDB.Get(id);
        }
        /// <summary>
        /// Tìm kiếm thực đơn, phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Course> ListCourse(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = courseDB.Count(searchValue);
            return courseDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Cập nhật thực đơn
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCourse(Course data)
        {
            return courseDB.Update(data);
        }
        /// <summary>
        /// Đếm số công thức trong 1 thực đơn
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int CountRecipeByCourse(Course data)
        {
            return courseDB.CountRecipe(data.CourseID);
        }

        /// <summary>
        /// Thêm món ăn
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddDish(Dish data)
        {
            return dishDB.Add(data);
        }
        /// <summary>
        /// Xóa món ăn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteDish(int id)
        {
            return dishDB.Delete(id);
        }
        /// <summary>
        /// Lấy món ăn dựa vào mã
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Dish? GetDish(int id)
        {
            return dishDB.Get(id);
        }
        /// <summary>
        /// Tìm kiếm món ăn, phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Dish> ListDish(out int rowCount, int page = 1, int pageSize = 0, string searchValue = "")
        {
            rowCount = dishDB.Count(searchValue);
            return dishDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Cập nhật món ăn
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateDish(Dish data)
        {
            return dishDB.Update(data);
        }
        /// <summary>
        /// Đếm số công thức trong 1 món ăn
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int CountRecipeByDish(Dish data)
        {
            return courseDB.CountRecipe(data.DishID);
        }


        /// <summary>
        /// Thêm nguyên liệu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddIngredient(Ingredient data)
        {
            return ingredientDB.Add(data);
        }
        /// <summary>
        /// Xóa nguyên liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteIngredient(int id)
        {
            return ingredientDB.Delete(id);
        }
        /// <summary>
        /// Lấy nguyên liệu dựa vào mã
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Ingredient? GetIngredient(int id)
        {
            return ingredientDB.Get(id);
        }
        /// <summary>
        /// Tìm kiếm nguyên liệu
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Ingredient> ListIngredient( int page = 1, int pageSize = 0, string searchValue = "")
        {
            return ingredientDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Cập nhật nguyên liệu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateIngredient(Ingredient data)
        {
            return ingredientDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem nguyên liệu có liên quan đến công thức nào không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool InUsed(int id)
        {
            return ingredientDB.InUsed(id);
        }


        /// <summary>
        /// Thêm thông báo
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddNotification(Notification data)
        {
            return notificationDB.Add(data);
        }
        /// <summary>
        /// Xóa thông báo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteNotification(int id)
        {
            return notificationDB.Delete(id);
        }
        /// <summary>
        /// Lấy danh sách thông báo của người dùng
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static List<Notification> GetListNoti(long UserID)
        {
            return notificationDB.GetList(UserID).ToList();
        }

    }
}
