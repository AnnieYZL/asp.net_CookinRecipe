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
        public int Add(Favourite data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Favourites(UserID, RecipeID, CreatedAt, IsCancel) 
                            VALUES(@UserID, @RecipeID, GETDATE(), 0); select @@IDENTITY";
                var parameters = new
                {
                    UserID = data.UserID,
                    RecipeID = data.RecipeID
                };
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
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
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
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
        /// <param name="searchValue"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<Favourite> List(long UserID, int page, int pageSize)
        {
            List<Favourite> data = new List<Favourite>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from (
	            select * , row_number() over (order by CreatedAt desc) as RowNumber
	            from Favourites
	            where UserID = @UserID
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
