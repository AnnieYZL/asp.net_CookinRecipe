using CookinRecipe.DomainModels;
using Dapper;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class RatingDAL : _BaseDAL, IRatingDAL
    {
        public RatingDAL(string connectionString) : base(connectionString)
        {
        }
        /// <summary>
        /// Đánh giá bài viết lần đầu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(Rating data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Ratings(UserID, RecipeID, Point, IsCancel) 
                            VALUES(@UserID, @RecipeID, @Point, @IsCancel); select @@IDENTITY";
                var parameters = new
                {
                    UserID = data.UserID,
                    RecipeID = data.RecipeID,
                    Point = data.Point,
                    IsCancel = data.IsCancel
                };
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

        /// <summary>
        /// Đánh giá lại bài viết
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Update(Rating data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Ratings
                            set IsCancel = @IsCancel, Point = @Point
                            where UserID = @UserID and RecipeID = @RecipeID";
                var parameters = new
                {
                    UserID = data.UserID,
                    RecipeID = data.RecipeID,
                    IsCancel = data.IsCancel,
                    Point = data.Point,
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
        /// <summary>
        /// Lấy số điểm người dùng đánh giá bài viết, nếu chưa đánh giá trả về 0
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public int CheckRate(long userID, long recipeID)
        {
            int result = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"SELECT COALESCE((
                                    SELECT r.Point 
                                    FROM Ratings r 
                                    WHERE r.UserID = @UserID AND r.RecipeID = @RecipeID AND IsCancel = 0
                                ), 0)";
                var parameters = new
                {
                    UserID = userID,
                    RecipeID = recipeID
                };
                result = connection.QueryFirstOrDefault<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return result;
        }
        /// <summary>
        /// Kiểm tra người dùng đã từng đánh giá công thức hay chưa
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        public bool CheckExistRate(long userID, long recipeID)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"if exists(select * from Ratings where UserID = @UserID and RecipeID = @RecipeID) select 1 else select 0";
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
    }
}
