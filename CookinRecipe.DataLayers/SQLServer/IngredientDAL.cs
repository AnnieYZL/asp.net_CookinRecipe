using CookinRecipe.DomainModels;
using Dapper;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class IngredientDAL : _BaseDAL, ICommonDAL<Ingredient>
    {
        public IngredientDAL(string connectionString) : base(connectionString)
        {
        }
        public IList<Ingredient> GetAll()
        {
            List<Ingredient> data = new List<Ingredient>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Ingredients";
                data = connection.Query<Ingredient>(sql: sql, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }
        public int Add(Ingredient data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Ingredients(IngredientName, Unit, Energy, IsMain) 
                            VALUES(@IngredientName, @Unit, @Energy, @IsMain); select @@IDENTITY";
                var parameters = new
                {
                    IngredientName = data.IngredientName ?? "",
                    Unit = data.Unit ?? "",
                    Energy = data.Energy,
                    IsMain = data.IsMain
                };
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public int Count(string searchValue = "")
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*)
	                        from Ingredients
	                        where IngredientName like @searchValue";
                var parameters = new { searchValue = $"%{searchValue}%" };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public int CountRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from Ingredients
	                        where IngredientID = @IngredientId";
                var parameters = new { IngredientId = id };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public Ingredient? Get(int id)
        {
            Ingredient? data = null;
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Ingredients
	                        where IngredientID = @IngredientId";
                var parameters = new { IngredientId = id };
                data = connection.QueryFirstOrDefault<Ingredient>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return data;
        }


        public IList<Ingredient> GetList(long UserID)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int id)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"if exists(select * from RecipeIngredients where IngredientID = @IngredientId) select 1 else select 0";
                var parameters = new { IngredientId = id };
                result = connection.ExecuteScalar<bool>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return result;
        }

        public IList<Ingredient> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<Ingredient> data = new List<Ingredient>();
            using (var connection = OpenConnection())
            {
                var sql = @"
	            select *
	            from Ingredients
	            where IngredientName like @searchValue";
                var parameters = new
                {
                    searchValue = $"%{searchValue}%"
                };
                data = connection.Query<Ingredient>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public bool Update(Ingredient data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Ingredients
                            set IngredientName = @IngredientName, Unit = @Unit, Energy = @Energy, IsMain = @IsMain
                            where IngredientID = @IngredientId";
                var parameters = new
                {
                    IngredientId = data.IngredientID,
                    IngredientName = data.IngredientName ?? "",
                    Unit = data.Unit ?? "",
                    IsMain = data.IsMain,
                    Energy = data.Energy
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
    }
}
