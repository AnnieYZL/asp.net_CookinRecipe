using CookinRecipe.DataLayers;
using CookinRecipe.DataLayers.SQLServer;
using CookinRecipe.DomainModels;

namespace CookinRecipe.BusinessLayers
{
    public static class RatingDataService
    {
        private static readonly IRatingDAL ratingDB;
        static RatingDataService()
        {
            ratingDB = new RatingDAL(Configuration.ConnectionString);
        }
        /// <summary>
        /// Đánh giá bài viết lần đầu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddRating(Rating data)
        {
            return ratingDB.Add(data);
        }

        /// <summary>
        /// Đánh giá lại bài viết
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool UpdateRating(Rating data)
        {
            return ratingDB.Update(data);
        }
        /// <summary>
        /// Lấy số điểm người dùng đánh giá bài viết, nếu chưa đánh giá trả về 0
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public static int CheckRate(long userID, long recipeID)
        {
            return ratingDB.CheckRate(userID, recipeID);
        }
        /// <summary>
        /// Kiểm tra người dùng đã từng đánh giá công thức hay chưa
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public static bool CheckExistRate(long userID, long recipeID)
        {
            return ratingDB.CheckExistRate(userID, recipeID);
        }
    }
}
