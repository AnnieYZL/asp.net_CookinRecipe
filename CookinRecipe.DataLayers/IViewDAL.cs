using CookinRecipe.DomainModels;

namespace CookinRecipe.DataLayers
{
    public interface IViewDAL
    {
        /// <summary>
        /// Lần xem đầu tiên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(View data);
        /// <summary>
        /// Lần xem thứ 2 trở đi
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(View data);
        /// <summary>
        /// Kiểm tra người dùng đã từng xem công thức này chưa
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        bool CheckView(long RecipeID, long UserID);
    }
}
