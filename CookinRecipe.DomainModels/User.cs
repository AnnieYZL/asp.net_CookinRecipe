namespace CookinRecipe.DomainModels
{
    /// <summary>
    /// Thông tin về người dùng
    /// </summary>
    public class User
    {
        public long UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// Giới tính 0: nam, 1: nữ
        /// </summary>
        public bool Gender { get; set; } 
        public int UserPoint {  get; set; }
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserImage { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Caption { get; set; } = string.Empty;
        public bool IsLocked { get; set; }
       
    }
}
