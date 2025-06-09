using CookinRecipe.DataLayers;
using CookinRecipe.DataLayers.SQLServer;
using CookinRecipe.DomainModels;

namespace CookinRecipe.BusinessLayers
{
    public static class ListDataService
    {
        private static readonly IListDAL listDB;
        static ListDataService()
        {
            listDB = new ListDAL(Configuration.ConnectionString);
        }
        /// <summary>
        /// Tạo list mới
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static long AddList(List data)
        {
            return listDB.Add(data);
        }
        /// <summary>
        /// Xóa ds
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteList(long id)
        {
            return listDB.Delete(id);
        }
        /// <summary>
        /// Lấy list từ id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List? GetList(long id)
        {
            return listDB.Get(id);
        }
        /// <summary>
        /// Đổi thông tin list
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateList(List data)
        {
            return listDB.Update(data);
        }
        /// <summary>
        /// Lấy danh sách các list 1 người đã lưu
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static List<List> GetListOf(long UserID)
        {
            return listDB.List(UserID).ToList();
        }
        /// <summary>
        /// Lấy số công thức trong 1 list
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public static int GetListQuantity(long ListID)
        {
            return listDB.GetListQuantity(ListID);
        }
        /// <summary>
        /// Lấy ds ct trong 1 list
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public static IList<Recipe> GetRecipesOf(long ListID)
        {
            return listDB.GetRecipesOf(ListID);
        }
        /// <summary>
        /// Xóa ds ct được chọn khỏi bst
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="recipeIds"></param>
        /// <returns></returns>
        public static bool DeleteRecipesFromList(long listId, List<long> recipeIds)
        {
            return listDB.DeleteRecipesFromList(listId, recipeIds);
        }
    }
}
