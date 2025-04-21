using CookinRecipe.DomainModels;
using Dapper;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class ViewDAL : _BaseDAL, IViewDAL
    {
        public ViewDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(View data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"INSERT INTO Views (RecipeID, UserID, LastView, ViewCount) 
                            VALUES (@RecipeID,@UserID,GETDATE(),1)";
                var parameters = new
                {
                    RecipeID = data.RecipeID,
                    UserID = data.UserID
                };
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }
        public bool Update(View data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"IF NOT EXISTS (SELECT 1 FROM Views WHERE RecipeID = @RecipeID AND UserID = @UserID AND LastView > DATEADD(MINUTE, -30, GETDATE()))
                            UPDATE Views
							SET LastView =	GETDATE(), ViewCount = ViewCount+1
                            WHERE RecipeID = @RecipeID and UserID = @UserID";
                var parameters = new
                {
                    RecipeID = data.RecipeID,
                    UserID = data.UserID
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
        /// <summary>
        /// Kiểm tra người dùng đã từng xem công thức này chưa
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool CheckView(long RecipeID, long UserID)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"if exists(select * from Views where RecipeID = @RecipeID and UserID = @UserID) select 1 else select 0";
                var parameters = new { RecipeID = RecipeID, UserID = UserID };
                result = connection.ExecuteScalar<bool>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return result;
        }

    }
}
