using CookinRecipe.DomainModels;
using Dapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class NotificationDAL : _BaseDAL, ICommonDAL<Notification>
    {
        public NotificationDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Notification data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Notifications(UserID, RecipeID, Title, Message, Type, CreatedAt, IsRead, AdminID) 
                            VALUES(@UserID, @RecipeID, @Title, @Message, @Type, GETDATE(), 0, @AdminID); select @@IDENTITY";
                var parameters = new
                {
                    UserID = data.UserID,
                    RecipeID = data.RecipeID,
                    Title = data.Title ?? "",
                    Message = data.Message ?? "",
                    Type = data.Type ?? "",
                    AdminID = data.AdminID,
                };
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public int Count(string searchValue = "")
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from Notifications
	                        where NotificationID = @NotificationId";
                var parameters = new { NotificationId = id };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public Notification? Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Notification> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            throw new NotImplementedException();
        }

        public bool Update(Notification data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Notifications
                            set IsRead = 1 
                            WHERE NotificationID = @NotificationID";
                var parameters = new
                {
                    NotificationID = data.NotificationID
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public IList<Notification> GetList(long UserID)
        {
            List<Notification> data = new List<Notification>();
            using (var connection = OpenConnection())
            {
                var sql = @"select *
                            from Notifications
                            where UserID = @UserID
                            order by IsRead asc, CreatedAt desc";
                var parameters = new
                {
                    UserID = UserID
                };
                data = connection.Query<Notification>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public int CountRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Notification> GetAll()
        {
            throw new NotImplementedException();
        }

        public int CountUnread(long userId)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*)
	                        from Notifications
	                        where UserID = @UserID and IsRead = 0";
                var parameters = new { UserID = userId };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public bool Change(long id)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Notifications
                            set IsRead = 1
                            WHERE NotificationID = @NotificationID";
                var parameters = new
                {
                    NotificationID = id
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
    }
}
