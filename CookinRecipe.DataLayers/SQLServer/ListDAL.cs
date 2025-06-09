using CookinRecipe.DomainModels;
using Dapper;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class ListDAL : _BaseDAL, IListDAL
    {
        public ListDAL(string connectionString) : base(connectionString)
        {
        }

        public long Add(List data)
        {
            long id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Lists(UserID, ListName, ListImage) 
                            VALUES(@UserID, @ListName, @ListImage); select @@IDENTITY";
                var parameters = new
                {
                    UserID = data.UserID,
                    ListName = data.ListName ?? "",
                    ListImage = data.ListImage ?? ""
                };
                id = connection.ExecuteScalar<long>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public int Count(long userID)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*)
	                        from Lists
	                        where UserID = @UserID";
                var parameters = new { UserID = userID };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public bool Delete(long id)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @" delete from ListRecipes
                            where ListID = @ListId
                            delete from Lists
	                        where ListID = @ListId;";
                var parameters = new { ListId = id };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
        public bool DeleteRecipesFromList(long listId, List<long> recipeIds)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"DELETE FROM ListRecipes 
                    WHERE ListID = @ListId AND RecipeID IN @RecipeIds";
                var parameters = new { ListId = listId, RecipeIds = recipeIds };
                result = connection.Execute(sql, parameters) > 0;
            }
            return result;
        }


        public List? Get(long id)
        {
            List? data = null;
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Lists
	                        where ListID = @ListId";
                var parameters = new { ListId = id };
                data = connection.QueryFirstOrDefault<List>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return data;
        }

        public bool Update(List data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Lists
                            set ListName = @ListName, ListImage = @ListImage
                            where ListID = @ListId";
                var parameters = new
                {
                    ListId = data.ListID,
                    ListName = data.ListName ?? "",
                    ListImage = data.ListImage
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
        ///Lấy danh sách các list 1 người đã lưu
        public IList<List> List(long UserID)
        {
            List<List> data = new List<List>();
            using (var connection = OpenConnection())
            {
                var sql = @"select *
	                        from Lists
	                        where UserID = @UserID";
                var parameters = new
                {
                    UserID = UserID
                };
                data = connection.Query<List>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }
        ///Lấy số công thức trong 1 list
        public int GetListQuantity(long ListID)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*)
                            from ListRecipes lr
                            join Recipes r on r.RecipeID = lr.RecipeID
                            where lr.ListID = @ListID and r.IsVerify = 1";
                var parameters = new { ListID = ListID };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public IList<Recipe> GetRecipesOf(long ListID)
        {
            List<Recipe> data = new List<Recipe>();
            using (var connection = OpenConnection())
            {
                var sql = @"select r.*
                            from ListRecipes l join Recipes r on l.RecipeID = r.RecipeID
                            where l.ListID = @ListId and r.IsVerify = 1";
                var parameters = new
                {
                    ListId = ListID
                };
                data = connection.Query<Recipe>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }
    }
}
