using CookinRecipe.DomainModels;

namespace CookinRecipe.DataLayers
{
    public interface ICommonDAL<T> where T : class
    {
        /// <summary>
        /// Tìm kiếm và lấy danh sách dữ liệu dưới dạng phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        IList<T> List(int page = 1, int pageSize = 0, string searchValue = "");
        /// <summary>
        /// Đếm số dòng dữ liệu tìm kiếm được
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue = "");
        /// <summary>
        /// Lấy một bản ghi dựa trên id. Hàm trả về id của dữ liệu được bổ sung.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T? Get(int id);
        /// <summary>
        /// Bổ sung dữ liệu vào bảng. Trả về id của dữ liệu được bổ sung.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(T data);
        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(T data);
        /// <summary>
        /// Xóa 1 bản ghi dựa vào id
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// Kiểm tra xem 1 dòng dữ liệu có mã là id hiện có dữ liệu liên quan đến bảng khác hay không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool InUsed(int id);
        /// <summary>
        /// Lấy list của người dùng có id là userID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        IList<T> GetList(long UserID);
        /// <summary>
        /// Lấy danh sách công thức liên quan của trường dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int CountRecipe(int id);
    }
}
