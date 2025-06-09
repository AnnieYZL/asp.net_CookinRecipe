using CookinRecipe.DomainModels;
using Dapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public UserAccount? AuthorizeByEmail(string email)
        {
            UserAccount? data = null;
            using (var cn = OpenConnection())
            {
                var sql = @"select UserID, Email, FullName, Password, UserImage, RoleNames
                           from Users where Email=@Email";
                var parameters = new
                {
                    Email = email,
                };
                data = cn.QuerySingleOrDefault<UserAccount>(sql, parameters);
                cn.Close();
            }
            return data;
        }

        public bool ChangePassword(string email, string newPassword)
        {
            bool result = false;
            using (var cn = OpenConnection())
            {
                var sql = @"update Users
                            set Password=@NewPassword 
                            where Email=@Email";
                var parameters = new
                {
                    Email = email,
                    NewPassword = newPassword
                };
                result = cn.Execute(sql, parameters) > 0;
                cn.Close();
            }
            return result;
        }

        public long CreateAccount(UserAccount account)
        {
            long id = 0;
            float energy = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Users(FullName, Gender, UserPoint, Email, Password, UserImage, CreatedAt, IsLocked, RoleNames) 
                            VALUES(@FullName, 0, 0, @Email, @Password, 'nophoto.jpg', GETDATE(), 0, 'user'); select SCOPE_IDENTITY();";
                var parameters = new
                {
                    FullName = account.FullName,
                    Email = account.Email,
                    Password = account.Password,
                };
                id = connection.ExecuteScalar<long>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

    }
}
