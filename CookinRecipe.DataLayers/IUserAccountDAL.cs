using CookinRecipe.DomainModels;

namespace CookinRecipe.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến tài khoản người dùng
    /// </summary>
    public interface IUserAccountDAL
    {
        /// <summary>
        /// Xác thực tài khoản đăng nhập của người dùng.
        /// Hàm trả về thông tin tài khoản nếu xác thực thành công,
        /// ngược lại hàm trả về null
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccount? Authorize(string email, string password);
        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        bool ChangePassword(string email, string newPassword);
        /// <summary>
        /// Tạo tài khoản mới
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        long CreateAccount(UserAccount account);
        /// <summary>
        /// Xác thực tài khoản đăng nhập của người dùng.
        /// Hàm trả về thông tin tài khoản nếu xác thực thành công,
        /// ngược lại hàm trả về null
        /// </summary>
        /// <param name="email"></param>ư
        /// <returns></returns>
        UserAccount? AuthorizeByEmail(string email);
    }
}
