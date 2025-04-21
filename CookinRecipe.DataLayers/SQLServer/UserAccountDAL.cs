using CookinRecipe.DomainModels;
using Dapper;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class UserAccountDAL : _BaseDAL, IUserAccountDAL
    {
        public UserAccountDAL(string connectionString) : base(connectionString)
        {
        }

        public UserAccount? Authorize(string email, string password)
        {
            UserAccount? data = null;
            using (var cn = OpenConnection())
            {
                var sql = @"select UserID, Email, FullName, Password, UserImage, RoleNames
                           from Users where Email=@Email AND Password=@Password";
                var parameters = new
                {
                    Email = email,
                    Password = password,
                };
                data = cn.QuerySingleOrDefault<UserAccount>(sql, parameters);
                cn.Close();
            }
            return data;
        }

        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            bool result = false;
            using (var cn = OpenConnection())
            {
                var sql = @"update Users
                            set Password=@NewPassword 
                            where Email=@Email and Password=@OldPassword";
                var parameters = new
                {
                    Email = email,
                    OldPassword = oldPassword,
                    NewPassword = newPassword
                };
                result = cn.Execute(sql, parameters) > 0;
                cn.Close();
            }
            return result;
        }
    }
}
