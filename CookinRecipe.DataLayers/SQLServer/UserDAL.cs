using CookinRecipe.DomainModels;
using Dapper;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class UserDAL : _BaseDAL, IUserDAL
    {
        public UserDAL(string connectionString) : base(connectionString)
        {
        }

        public User? Get(long id)
        {
            User? data = null;
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Users
	                        where UserID = @UserId";
                var parameters = new { UserId = id };
                data = connection.QueryFirstOrDefault<User>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return data;
        }

        public bool Update(User data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Users
                            set FullName = @FullName, Gender = @Gender, Address = @Address, UserImage = @UserImage, Caption = @Caption
                            where UserID = @UserId";
                var parameters = new
                {
                    UserId = data.UserID,
                    FullName = data.FullName ?? "",
                    Gender = data.Gender,
                    Address = data.Address ?? "",
                    UserImage = data.UserImage ?? "",
                    Caption = data.Caption ?? ""
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
        public IList<User> GetAllUsers()
        {
            List<User> data = new List<User>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Users";
                data = connection.Query<User>(sql: sql, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public bool Decentralisation(User data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Users
                            set RoleNames = @RoleNames
                            where UserID = @UserId";
                var parameters = new
                {
                    UserId = data.UserID,
                    RoleNames = data.RoleNames
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public int GetSoCongThuc(long id, bool type)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select COUNT(*)
                            from Recipes
                            where AuthorID = @UserID and IsVerify = @Type";
                var parameters = new { UserID = id, Type = type};
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public int CountCmt(long id)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select COUNT(*)
                            from Comments
                            where UserID = @UserID";
                var parameters = new { UserID = id };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public int CountRate(long id)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select COUNT(*)
                            from Ratings
                            where UserID = @UserID and Point < 3";
                var parameters = new { UserID = id };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public int CountFav(long id)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select COUNT(*)
                            from Favourites
                            where UserID = @UserID and IsCancel = 0";
                var parameters = new { UserID = id };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }
    }
}
