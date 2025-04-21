namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin đăng nhập của tài khoản
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// ID Tài khoản
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// Tên hiển thị
        /// </summary>
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// Email (Tên đăng nhập)
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// Đường dẫn file ảnh
        /// </summary>
        public string UserImage { get; set; } = string.Empty;
        /// <summary>
        /// Chuỗi các quyền của tài khoản, phân cách bởi dấu phẩy
        /// </summary>
        public string RoleNames { get; set; } = string.Empty;
    }
}
