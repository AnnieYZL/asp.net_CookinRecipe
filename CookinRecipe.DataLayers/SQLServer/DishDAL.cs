using CookinRecipe.DomainModels;
using Dapper;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class DishDAL : _BaseDAL, ICommonDAL<Dish>
    {
        public DishDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Dish data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Dishes(DishName, DishImage, Description) 
                            VALUES(@DishName, @DishImage, @Description); select @@IDENTITY";
                var parameters = new
                {
                    DishName = data.DishName ?? "",
                    DishImage = data.DishImage ?? "",
                    Description = data.Description ?? ""
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
	                        from Dishes
	                        where (DishName like @searchValue) or (Description like @searchValue)";
                var parameters = new { searchValue = $"%{searchValue}%" };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public int CountRecipe(int id)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*)
	                        from DishRecipes
	                        where DishID= @DishID";
                var parameters = new { DishID = id };
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
                var sql = @"delete from Dishes
	                        where DishID = @DishId;
                            delete from DishRecipes
                            where DishID = @DishId";
                var parameters = new { DishId = id };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public Dish? Get(int id)
        {
            Dish? data = null;
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Dishes
	                        where DishID = @DishId";
                var parameters = new { DishId = id };
                data = connection.QueryFirstOrDefault<Dish>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return data;
        }

        public IList<Dish> GetList(long UserID)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Dish> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<Dish> data = new List<Dish>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from (
	            select * , row_number() over (order by DishName) as RowNumber
	            from Dishes
	            where (DishName like @searchValue) or (Description like @searchValue)

            ) as t
            where (@pageSize = 0) or (RowNumber between (@page - 1) * @pageSize+1 and @page * @pageSize)
            order by RowNumber;";
                var parameters = new
                {
                    page,
                    pageSize,
                    searchValue = $"%{searchValue}%"
                };
                data = connection.Query<Dish>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public bool Update(Dish data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Dishes
                            set DishName = @DishName, Description = @Description, DishImage = @DishImage
                            where DishID = @DishId";
                var parameters = new
                {
                    DishName = data.DishName ?? "",
                    Description = data.Description ?? "",
                    DishImage = data.DishImage ?? ""
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
    }
}
