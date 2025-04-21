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
    }
}
