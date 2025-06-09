using Azure;
using CookinRecipe.DomainModels;
using Dapper;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class FavouriteDAL : _BaseDAL, IFavouriteDAL
    {
        public FavouriteDAL(string connectionString) : base(connectionString)
        {
        }
        /// <summary>
        /// Thích một bài viết lần đầu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Add(Favourite data)
        {
            bool id = false;
            using (var connection = OpenConnection())
            {
                var sql = @"IF EXISTS (
                            SELECT 1 FROM Favourites WHERE UserID = @UserID AND RecipeID = @RecipeID
                        )
                        BEGIN
                            UPDATE Favourites
                            SET IsCancel = CASE WHEN IsCancel = 1 THEN 0 ELSE 1 END,
                                CreatedAt = GETDATE()
                            WHERE UserID = @UserID AND RecipeID = @RecipeID;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO Favourites(UserID, RecipeID, CreatedAt, IsCancel)
                            VALUES(@UserID, @RecipeID, GETDATE(), 0);
                        END;
                        SELECT IsCancel FROM Favourites WHERE UserID = @UserID AND RecipeID = @RecipeID;";
                var parameters = new
                {
                    UserID = data.UserID,
                    RecipeID = data.RecipeID
                };
                id = connection.ExecuteScalar<bool>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

        /// <summary>
        /// Hủy thích / Thích lại bài viết
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(Favourite data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete Favourites
                            where UserID = @UserID and RecipeID = @RecipeID";
                var parameters = new
                {
                    UserID = data.UserID,
                    RecipeID = data.RecipeID
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
        /// <summary>
        /// Kiểm tra xem người dùng có thích bài viết hay không
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public bool CheckFav(long userID, long recipeID)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"if exists(select * from Favourites where UserID = @UserID and RecipeID = @RecipeID and IsCancel = 0) select 1 else select 0";
                var parameters = new
                {
                    UserID = userID,
                    RecipeID = recipeID
                };
                result = connection.QueryFirst<bool>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return result;
        }
        /// <summary>
        /// Kiểm tra người dùng đã từng thích công thức hay chưa
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public bool CheckExistFav(long userID, long recipeID)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"if exists(select * from Favourites where UserID = @UserID and RecipeID = @RecipeID and IsCancel = 0) select 1 else select 0";
                var parameters = new
                {
                    UserID = userID,
                    RecipeID = recipeID
                };
                result = connection.QueryFirstOrDefault<bool>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return result;
        }
        /// <summary>
        /// Lấy danh sách công thức người dùng đã thích
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<Favourite> List(long UserID, int page, int pageSize)
        {
            List<Favourite> data = new List<Favourite>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from (
	            select f.* , row_number() over (order by f.CreatedAt desc) as RowNumber
	            from Favourites f join Recipes r on r.RecipeID = f.RecipeID
	            where f.UserID = @UserID and r.IsVerify = 1 and f.IsCancel = 0
                ) as t
                where (@pageSize = 0) or (RowNumber between (@page - 1) * @pageSize+1 and @page * @pageSize)
                order by RowNumber;";
                var parameters = new
                {
                    page,
                    pageSize,
                    UserID = UserID
                };
                data = connection.Query<Favourite>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }
    }
}
