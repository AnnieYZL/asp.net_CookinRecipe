using CookinRecipe.DomainModels;

namespace CookinRecipe.DataLayers
{
    public interface ICommentDAL 
    {
        /// <summary>
        /// Thêm cmt
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Comment data);
        /// <summary>
        /// Đếm số cmt của 1 ct
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        int CountByID(long recipeID);
        /// <summary>
        /// Xóa cmt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// Lấy ds cmt phân trang
        /// </summary>
        /// <param name="recipeID"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IList<Comment> List(long recipeID, int page = 1, int pageSize = 0);
        /// <summary>
        /// Chỉnh sửa cmt
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Comment data);
    }
}
