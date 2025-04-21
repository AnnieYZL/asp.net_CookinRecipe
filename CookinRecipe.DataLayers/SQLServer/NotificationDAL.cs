using CookinRecipe.DomainModels;
using Dapper;

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
                var sql = @"insert into Notifications(UserID, RecipeID, Title, Message, Type, CreatedAt, IsRead) 
                            VALUES(@UserID, @RecipeID, @Title, @Message, @Type, GETDATE(), 0); select @@IDENTITY";
                var parameters = new
                {
                    UserID = data.UserID,
                    RecipeID = data.RecipeID,
                    Title = data.Title ?? "",
                    Message = data.Message ?? "",
                    Type = data.Type ?? ""
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
            throw new NotImplementedException();
        }

        public IList<Notification> GetList(long UserID)
        {
            List<Notification> data = new List<Notification>();
            using (var connection = OpenConnection())
            {
                var sql = @"select top(10) *
                            from Notifications
                            where UserID = @UserID
                            order by CreatedAt desc";
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
    }
}
