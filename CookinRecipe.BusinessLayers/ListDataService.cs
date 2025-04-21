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
        public static int AddList(List data)
        {
            return listDB.Add(data);
        }
        /// <summary>
        /// Xóa ds
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteList(int id)
        {
            return listDB.Delete(id);
        }
        /// <summary>
        /// Lấy list từ id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List? GetList(int id)
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
        public static List<List> GetList(out int rowCount, long UserID)
        {
            rowCount = listDB.Count(UserID);
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
    }
}
