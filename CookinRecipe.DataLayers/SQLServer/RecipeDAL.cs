using CookinRecipe.DomainModels;
using Dapper;
using System.Buffers;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class RecipeDAL : _BaseDAL, IRecipeDAL
    {
        public RecipeDAL(string connectionString) : base(connectionString)
        {
        }

        public bool SetEnergy(long recipeId)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Recipes
							set Energy = (select sum(i.Energy*r.Quantity)
                                from RecipeIngredients r
	                            join Ingredients i on r.IngredientID = i.IngredientID
                                where r.RecipeID = @RecipeID)
							where RecipeID = @RecipeID";
                var parameters = new { RecipeID = recipeId };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public long Add(Recipe data)
        {
            long id = 0;
            float energy = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Recipes(RecipeName, Description, CreatedAt, PrepTime, Serving, Difficulty, RecipeImage, RecipeVideo, Energy, AuthorID, IsVerify, IsRemove) 
                            VALUES(@RecipeName, @Description, GETDATE(), @PrepTime, @Serving, @Difficulty, @RecipeImage, @RecipeVideo, @Energy, @AuthorID, @IsVerify, @IsRemove); select @@IDENTITY";
                var parameters = new
                {
                    RecipeName = data.RecipeName ?? "",
                    Description = data.Description ?? "",
                    PrepTime = data.PrepTime,
                    Serving = data.Serving ?? "",
                    Difficulty = data.Difficulty,
                    RecipeImage = data.RecipeImage ?? "",
                    RecipeVideo = data.RecipeVideo ?? "",
                    Energy = energy,
                    AuthorID = data.AuthorID,
                    IsVerify = data.IsVerify,
                    IsRemove = data.IsRemove,
                };
                id = connection.ExecuteScalar<long>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public int AddIngredients(List<RecipeIngredient> data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into RecipeIngredients(RecipeID, IngredientID, Quantity) 
                            VALUES(@RecipeID, @IngredientID, @Quantity); select @@IDENTITY";
                foreach (var s in data)
                {
                    var parameters = new
                    {
                        RecipeID = s.RecipeID,
                        IngredientID = s.IngredientID,
                        Quantity = s.Quantity,
                    };
                    id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                }
                connection.Close();
            }
            return id;
        }

        public int AddNotes(Note data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Notes(RecipeID, NoteNumber, NoteContent) 
                            VALUES(@RecipeID, @NoteNumber, @NoteContent); select @@IDENTITY";
               
                    var parameters = new
                    {
                        RecipeID = data.RecipeID,
                        NoteNumber = data.NoteNumber,
                        NoteContent = data.NoteContent ?? "",
                    };
                    id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public int AddSteps(Step data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Steps(RecipeID, StepNumber, Description) 
                            VALUES(@RecipeID, @StepNumber, @Description); select @@IDENTITY";
                    var parameters = new
                    {
                        RecipeID = data.RecipeID,
                        StepNumber = data.StepNumber,
                        Description = data.Description ?? "",
                    };
                    id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public int AddToList(long RecipeID, long ListID)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into ListRecipes(RecipeID, ListID)
                            VALUES(@RecipeID, @ListID); select @@IDENTITY";
                var parameters = new
                {
                    RecipeID = RecipeID,
                    ListID = ListID
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
	                        from Recipes
	                        where (RecipeName like @searchValue) or (Description like @searchValue)";
                var parameters = new { searchValue = $"%{searchValue}%" };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public int CountCmt(long RecipeID)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*)
	                        from Comments
	                        where RecipeID = @RecipeID";
                var parameters = new { RecipeID = RecipeID };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public int CountFav(long RecipeID)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*)
	                        from Favourites
	                        where RecipeID = @RecipeID";
                var parameters = new { RecipeID = RecipeID };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public int CountRate(long RecipeID)
        {
            int count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*)
	                        from Ratings
	                        where RecipeID = @RecipeID and IsCancel = 0";
                var parameters = new { RecipeID = RecipeID };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public bool Delete(long RecipeID)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from Recipes
	                        where RecipeID = @RecipeID";
                var parameters = new { RecipeID = RecipeID };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public bool DeleteFromList(long ListID, long RecipeID)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from ListRecipes
	                        where RecipeID = @RecipeID and ListID = @ListID";
                var parameters = new { RecipeID = RecipeID, ListID = ListID };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public bool DeleteIngredients(long RecipeID)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from RecipeIngredients
	                        where RecipeID = @RecipeID";
                var parameters = new { RecipeID = RecipeID };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public bool DeleteNotes(long RecipeID)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from Notes
	                        where RecipeID = @RecipeId;";
                var parameters = new { RecipeId = RecipeID };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public bool DeleteSteps(long RecipeID)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from Steps
	                        where RecipeID = @RecipeId;";
                var parameters = new { RecipeId = RecipeID };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public Recipe? Get(long RecipeID)
        {
            Recipe? data = null;
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Recipes
	                        where RecipeID = @RecipeId";
                var parameters = new { RecipeId = RecipeID };
                data = connection.QueryFirstOrDefault<Recipe>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return data;
        }

        public float GetRate(long RecipeID)
        {
            float count = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"select ROUND(AVG(CAST(Point as float)),2)
                            from Ratings
                            where RecipeID = @RecipeID";
                var parameters = new { RecipeID = RecipeID };
                count = connection.ExecuteScalar<float>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public IList<Recipe> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<Recipe> data = new List<Recipe>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from (
	            select * , row_number() over (order by CreatedAt desc) as RowNumber
	            from Recipes
	            where (RecipeName like @searchValue) or (Description like @searchValue)
            ) as t
            where (@pageSize = 0) or (RowNumber between (@page - 1) * @pageSize+1 and @page * @pageSize)
            order by RowNumber;";
                var parameters = new
                {
                    page,
                    pageSize,
                    searchValue = $"%{searchValue}%"
                };
                data = connection.Query<Recipe>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public IList<RecipeIngredient> ListIngredients(long RecipeID)
        {
            List<RecipeIngredient> data = new List<RecipeIngredient>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from RecipeIngredients where RecipeID = @RecipeID";
                var parameters = new
                {
                    RecipeID = RecipeID
                };
                data = connection.Query<RecipeIngredient>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public IList<Note> ListNotes(long RecipeID)
        {
            List<Note> data = new List<Note>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Notes where RecipeID = @RecipeID order by NoteNumber";
                var parameters = new
                {
                    RecipeID = RecipeID
                };
                data = connection.Query<Note>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public IList<Step> ListSteps(long RecipeID)
        {
            List<Step> data = new List<Step>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Steps where RecipeID = @RecipeID order by StepNumber";
                var parameters = new
                {
                    RecipeID = RecipeID
                };
                data = connection.Query<Step>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public bool Update(Recipe data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Recipes
                            set RecipeName = @RecipeName, Description = @Description, PrepTime = @PrepTime, Serving = @Serving, Difficulty = @Difficulty, RecipeImage = @RecipeImage, RecipeVideo = @RecipeVideo, Energy = @Energy 
                            where RecipeID = @RecipeID";
                var parameters = new
                {
                    RecipeID = data.RecipeID,
                    RecipeName = data.RecipeName ?? "",
                    Description = data.Description ?? "",
                    PrepTime = data.PrepTime,
                    Serving = data.Serving ?? "",
                    Difficulty = data.Difficulty,
                    RecipeImage = data.RecipeImage ?? "",
                    RecipeVideo = data.RecipeVideo ?? "",
                    Energy = data.Energy
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public IList<Recipe> GetRecipeListByCourse(int id)
        {
            List<Recipe> data = new List<Recipe>();
            using (var connection = OpenConnection())
            {
                var sql = @"select r.*
                            from CourseRecipes cr
                            join Recipes r on cr.RecipeID = r.RecipeID
                            where cr.CourseID = @CourseId";
                var parameters = new
                {
                    CourseId = id
                };
                data = connection.Query<Recipe>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public IList<Recipe> GetRecipeListByDish(int id)
        {
            List<Recipe> data = new List<Recipe>();
            using (var connection = OpenConnection())
            {
                var sql = @"select r.*
                            from DishRecipes dr
                            join Recipes r on dr.RecipeID = r.RecipeID
                            join Dish d on d.DishID = dr.DishID
                            where d.DishID = @DishId";
                var parameters = new
                {
                    DishId = id
                };
                data = connection.Query<Recipe>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public IList<Recipe> GetNewestRecipe()
        {
            List<Recipe> data = new List<Recipe>();
            using (var connection = OpenConnection())
            {
                var sql = @"select top(8) *
                            from Recipes
                            order by CreatedAt";
                var parameters = new
                {
                };
                data = connection.Query<Recipe>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

		public IList<Ingredient> ListMainIngredients(long RecipeID)
		{
			List<Ingredient> data = new List<Ingredient>();
			using (var connection = OpenConnection())
			{
                var sql = @"select top(2) i.*
                            from RecipeIngredients p
	                            join Ingredients i on p.IngredientID = i.IngredientID
                            where i.IsMain = 1 and p.RecipeID = @RecipeID";
				var parameters = new
				{
					RecipeID = RecipeID
				};
				data = connection.Query<Ingredient>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
			}
			return data;
		}

        public IList<Recipe> GetListRecipe(List<int> ListIng)
        {
            List<Recipe> data = new List<Recipe>();
            using (var connection = OpenConnection())
            {
                var sql = @"select distinct r.*
                            from Recipes r
                            join RecipeIngredients i on r.RecipeID = i.RecipeID
                            where i.IngredientID in @IngredientId";
                var parameters = new
                {
                    IngredientId = ListIng
                };
                data = connection.Query<Recipe>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

		public IList<Recipe> ListRecipeOfUser(long id)
		{
			List<Recipe> data = new List<Recipe>();
			using (var connection = OpenConnection())
			{
				var sql = @"select *
                            from Recipes
                            where AuthorID = @UserId";
				var parameters = new
				{
					UserId = id
				};
				data = connection.Query<Recipe>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
			}
			return data;
		}

        public IList<Ingredient> ListTagIngredients(long RecipeID)
        {
            List<Ingredient> data = new List<Ingredient>();
            using (var connection = OpenConnection())
            {
                var sql = @"select i.*
                            from RecipeIngredients p
	                            join Ingredients i on p.IngredientID = i.IngredientID
                            where p.RecipeID = @RecipeID";
                var parameters = new
                {
                    RecipeID = RecipeID
                };
                data = connection.Query<Ingredient>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public IList<Course> GetCoursesOf(long id)
        {
            List<Course> data = new List<Course>();
            using (var connection = OpenConnection())
            {
                var sql = @"select c.*
                            from CourseRecipes cr
	                            join Courses c on c.CourseID = cr.CourseID
                            where cr.RecipeID = @RecipeID";
                var parameters = new
                {
                    RecipeID = id
                };
                data = connection.Query<Course>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public bool DeleteRecipeInCourse(long RecipeID)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"delete from CourseRecipes
	                        where RecipeID = @RecipeId;";
                var parameters = new { RecipeId = RecipeID };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public int AddRecipeInCourse(int CourseId, long RecipeID)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into CourseRecipes(RecipeID, CourseID) 
                            VALUES(@RecipeID, @CourseID); select @@IDENTITY";
                    var parameters = new
                    {
                        RecipeID = RecipeID,
                        CourseID = CourseId,
                    };
                    id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;
        }

    }
}
