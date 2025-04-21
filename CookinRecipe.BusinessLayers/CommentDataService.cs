using CookinRecipe.DataLayers;
using CookinRecipe.DataLayers.SQLServer;
using CookinRecipe.DomainModels;

namespace CookinRecipe.BusinessLayers
{
    public static class CommentDataService
    {
        private static readonly ICommentDAL commentDB;
        static CommentDataService()
        {
            commentDB = new CommentDAL(Configuration.ConnectionString);
        }
        /// <summary>
        /// Tạo cmt
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddComment(Comment data)
        {
            return commentDB.Add(data);
        }
        /// <summary>
        /// Đếm số cmt của 1 công thức
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public static int CountCommentByID(long recipeID)
        { 
            return commentDB.CountByID(recipeID);
        }
        /// <summary>
        /// Xóa cmt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteComment(int id)
        {
            return commentDB.Delete(id);
        }

        /// <summary>
        /// Lấy ds comment của 1 công thức, phân trang
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="recipeID"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static List<Comment> ListComment(out int rowCount, long recipeID, int page = 1, int pageSize = 0)
        {
            rowCount = commentDB.CountByID(recipeID);
            return commentDB.List(recipeID, page, pageSize).ToList();
        }
        /// <summary>
        /// Chỉnh sửa cmt
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateComment(Comment data)
        {
            return commentDB.Update(data);
        }
    }
}
