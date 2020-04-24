namespace CheckIn.Common
{
    public class GetAccessTokenRequest
    {
        /// <summary>
        ///     使用者密碼
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     使用者帳號
        /// </summary>
        public string UserName { get; set; }
    }
}