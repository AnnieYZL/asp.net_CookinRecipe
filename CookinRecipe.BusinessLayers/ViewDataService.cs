using CookinRecipe.DataLayers;
using CookinRecipe.DataLayers.SQLServer;
using CookinRecipe.DomainModels;

namespace CookinRecipe.BusinessLayers
{
    public static class ViewDataService
    {
        private static readonly IViewDAL viewDB;
        static ViewDataService()
        {
            viewDB = new ViewDAL(Configuration.ConnectionString);
        }
        /// <summary>
        /// Xem bài viết lần đầu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddView(View data)
        {
            return viewDB.Add(data);
        }

        /// <summary>
        /// Xem bài lần 2 trở đi
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateView(View data)
        {
            return viewDB.Update(data);
        }
        /// <summary>
        /// Kiểm tra người dùng đã từng xem công thức này chưa
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static bool CheckView(long RecipeID, long UserID)
        {
            return viewDB.CheckView(RecipeID, UserID);
        }
    }
}
