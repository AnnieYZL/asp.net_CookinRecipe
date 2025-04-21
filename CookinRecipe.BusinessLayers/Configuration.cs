namespace CookinRecipe.BusinessLayers
{
    public static class Configuration
    {
        public static string ConnectionString { get; private set; } = "";
        /// <summary>
        /// Khởi tạo cấu hình
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
