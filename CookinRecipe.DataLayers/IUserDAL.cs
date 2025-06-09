using CookinRecipe.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookinRecipe.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến người dùng
    /// </summary>
    public interface IUserDAL
    {
        /// <summary>
        /// Lấy thông tin người dùng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User? Get(long id);

        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(User data);
        /// <summary>
        /// Lấy tất cả người dùng
        /// </summary>
        /// <returns></returns>
        IList<User> GetAllUsers();
        /// <summary>
        /// Cập nhật quyền cho người dùng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Decentralisation(User data);
        /// <summary>
        /// Lấy số ct duyệt/chưa của người dùng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        int GetSoCongThuc(long id, bool type);
        int CountCmt(long id);
        int CountRate(long id);
        int CountFav(long id);
    }
}
