using CookinRecipe.DataLayers;
using CookinRecipe.DataLayers.SQLServer;
using CookinRecipe.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookinRecipe.BusinessLayers
{
    public static class UserDataService
    {
        private static readonly IUserDAL userDB;
        static UserDataService()
        {
            userDB = new UserDAL(Configuration.ConnectionString);
        }
        /// <summary>
        /// Lấy thông tin người dùng dựa vào id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User? GetUser(long id)
        {
            return userDB.Get(id);
        }
        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateUser(User data)
        {
            return userDB.Update(data);
        }
        /// <summary>
        /// Lấy danh sách người dùng
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUsers()
        {
            return userDB.GetAllUsers().ToList();
        }
        /// <summary>
        /// Phân quyền người dùng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Decentralisation(User data)
        {
            return userDB.Decentralisation(data);
        }
        /// <summary>
        /// Đếm ct duyệt/chưa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetSoCongThuc(long id, bool type)
        {
           return userDB.GetSoCongThuc(id, type);
        }
        /// <summary>
        /// Đếm số cmt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int CountCmt(long id)
        {
            return userDB.CountCmt(id);
        }
        /// <summary>
        /// Đếm số rate < 3
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int CountRate(long id)
        {
            return userDB.CountRate(id);
        }
        /// <summary>
        /// Đếm số lượt thích
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int CountFav(long id)
        {
            return userDB.CountFav(id);
        }
    }
}
