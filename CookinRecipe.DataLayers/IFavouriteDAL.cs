using CookinRecipe.DomainModels;

namespace CookinRecipe.DataLayers
{
    public interface IFavouriteDAL
    {
        /// <summary>
        /// Thích một bài viết lần đầu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Favourite data);

        /// <summary>
        /// Hủy thích / Thích lại bài viết
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        bool Update(Favourite data);
        /// <summary>
        /// Kiểm tra xem người dùng có thích bài viết hay không
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        bool CheckFav(long userID, long recipeID);
        /// <summary>
        /// Kiểm tra người dùng đã từng thích công thức hay chưa
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        bool CheckExistFav(long userID, long recipeID);
        /// <summary>
        /// Lấy danh sách công thức người dùng đã thích
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        IList<Favourite> List(long UserID, int page, int pageSize);
    }
}
