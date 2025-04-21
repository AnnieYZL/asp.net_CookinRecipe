using CookinRecipe.DomainModels;
using Dapper;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class CommentDAL : _BaseDAL, ICommentDAL
    {
        public CommentDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Comment data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Comments(UserID, RecipeID, CreatedAt, CommentContent) 
                            VALUES(@UserID, @RecipeID, GETDATE(), @CommentContent); select @@IDENTITY";
                var parameters = new
                {
                    UserID = data.UserID,
                    RecipeID = data.RecipeID,
                    CommentContent = data.CommentContent ?? ""
                };
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public int CountByID(long recipeID)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*)
	                        from Comments
	                        where RecipeID = @RecipeID";
                var parameters = new { RecipeID = recipeID };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public bool Delete(int id)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from Comments
	                        where CommentID = @CommentId";
                var parameters = new { CommentId = id };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }


        public IList<Comment> List(long recipeID, int page = 1, int pageSize = 0)
        {
            List<Comment> data = new List<Comment>();
            using (var connection = OpenConnection())
            {
                var sql = @"
	            select * 
	            from Comments
	            where RecipeID = @RecipeID
                order by CreatedAt desc";
                var parameters = new
                {
                    RecipeID = recipeID
                };
                data = connection.Query<Comment>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public bool Update(Comment data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Comments
                            set CommentContent = @CommentContent
                            where CommentID = @CommentId";
                var parameters = new
                {
                    CommentId = data.CommentID,
                    CommentContent = data.CommentContent ?? ""
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
    }
}
