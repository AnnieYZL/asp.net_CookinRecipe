using CookinRecipe.DataLayers;
using CookinRecipe.DataLayers.SQLServer;
using CookinRecipe.DomainModels;

namespace CookinRecipe.BusinessLayers
{
    public static class FavouriteDataService
    {
        private static readonly IFavouriteDAL favouriteDB;
        static FavouriteDataService()
        {
            favouriteDB = new FavouriteDAL(Configuration.ConnectionString);
        }
        /// <summary>
        /// Thích một bài viết lần đầu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddFav(Favourite data)
        {
            return favouriteDB.Add(data);
        }

        /// <summary>
        /// Hủy thích / Thích lại bài viết
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool Update(Favourite data)
        {
            return favouriteDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra xem người dùng có thích bài viết hay không
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public static bool CheckFav(long userID, long recipeID)
        {
            return favouriteDB.CheckFav(userID, recipeID);
        }
        /// <summary>
        /// Kiểm tra người dùng đã từng thích công thức hay chưa
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public static bool CheckExistFav(long userID, long recipeID)
        {
            return favouriteDB.CheckExistFav(userID, recipeID);
        }
        /// <summary>
        /// Lấy danh sách công thức người dùng đã thích
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static List<Favourite> ListFav(long UserID, int page, int pageSize)
        {
            return favouriteDB.List(UserID, page, pageSize).ToList();
        }
    }
}
