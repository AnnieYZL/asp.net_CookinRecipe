using CookinRecipe.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookinRecipe.DataLayers
{
    public interface IRatingDAL
    {

        /// <summary>
        /// Đánh giá bài viết lần đầu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Rating data);
        /// <summary>
        /// Đánh giá lại bài viết
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        bool Update(Rating data);
        /// <summary>
        /// Lấy số điểm người dùng đánh giá bài viết, nếu chưa đánh giá trả về 0
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        int CheckRate(long userID, long recipeID);
        /// <summary>
        /// Kiểm tra người dùng đã từng đánh giá công thức hay chưa
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        bool CheckExistRate(long userID, long recipeID);
    }
}
