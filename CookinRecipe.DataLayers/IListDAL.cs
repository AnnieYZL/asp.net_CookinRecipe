using CookinRecipe.DomainModels;

namespace CookinRecipe.DataLayers
{
    public interface IListDAL
    {
        /// <summary>
        /// Tạo ds mới
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(List data);
        /// <summary>
        /// Đếm số danh sách của người dùng
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        int Count(long userID);
        /// <summary>
        /// Xóa ds
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// Lấy ds dựa vào mã
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List? Get(int id);
        /// <summary>
        /// Cập nhật thông tin ds
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(List data);
        /// <summary>
        /// Lấy danh sách các list 1 người đã lưu
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IList<List> List(long UserID);
        /// <summary>
        /// Lấy số công thức trong 1 list
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        int GetListQuantity(long ListID);
    }
}
