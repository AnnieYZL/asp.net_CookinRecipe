using CookinRecipe.DomainModels;
using Dapper;
using System.Buffers;

namespace CookinRecipe.DataLayers.SQLServer
{
    public class CourseDAL : _BaseDAL, ICommonDAL<Course>
    {
        public CourseDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Course data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Courses(CourseName, CourseImage, Description) 
                            VALUES(@CourseName, @CourseImage, @Description); select @@IDENTITY";
                var parameters = new
                {
                    CourseName = data.CourseName ?? "",
                    CourseImage = data.CourseImage ?? "",
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
	                        from Courses
	                        where (CourseName like @searchValue) or (Description like @searchValue)";
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
	                        from CourseRecipes
	                        where CourseID = @CourseID";
                var parameters = new { CourseID = id};
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
                var sql = @"delete from Courses
	                        where CourseID = @CourseId;
                            delete from CourseRecipes
                            where CourseID = @CourseId";
                var parameters = new { CourseId = id };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public Course? Get(int id)
        {
            Course? data = null;
            using (var connection = OpenConnection())
            {
                var sql = @"select * from Courses
	                        where CourseID = @CourseId";
                var parameters = new { CourseId = id };
                data = connection.QueryFirstOrDefault<Course>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return data;
        }

        public IList<Course> GetList(long UserID)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Course> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<Course> data = new List<Course>();
            using (var connection = OpenConnection())
            {
                var sql = @"select * from (
	            select * , row_number() over (order by CourseName) as RowNumber
	            from Courses
	            where (CourseName like @searchValue) or (Description like @searchValue)

            ) as t
            where (@pageSize = 0) or (RowNumber between (@page - 1) * @pageSize+1 and @page * @pageSize)
            order by RowNumber;";
                var parameters = new
                {
                    page,
                    pageSize,
                    searchValue = $"%{searchValue}%"
                };
                data = connection.Query<Course>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
            }
            return data;
        }

        public bool Update(Course data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"update Courses
                            set CourseName = @CourseName, Description = @Description, CourseImage = @CourseImage
                            where CourseID = @CourseId";
                var parameters = new
                {
                    CourseName = data.CourseName ?? "",
                    Description = data.Description ?? "",
                    CourseImage = data.CourseImage ?? ""
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: System.Data.CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }
    }
}
