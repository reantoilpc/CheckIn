namespace CheckIn.Class
{
    /// <summary>
    /// 使用者資料
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// 帳號是否存在
        /// </summary>
        public bool Exist => AccountID > 0;
        /// <summary>
        /// 帳號ID
        /// </summary>
        public int AccountID { get; set; }
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 使用者AccessToken
        /// </summary>
        public string AccessToken { get; set; }
    }
}