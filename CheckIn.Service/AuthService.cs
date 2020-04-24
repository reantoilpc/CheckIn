using System;
using System.Text;
using CheckIn.Adapter;
using CheckIn.Class;

namespace CheckIn.Service
{
    /// <summary>
    ///     驗證服務介面
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        ///     取得AccessToken
        /// </summary>
        /// <param name="userName">使用者帳號</param>
        /// <returns>AccessToken</returns>
        string GetAccessToken(string userName);

        /// <summary>
        ///     驗證AccessToken
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <returns>驗證成功或失敗</returns>
        bool Verify(string accessToken);
    }

    /// <summary>
    ///     驗證服務元件
    /// </summary>
    public class AuthService : IAuthService
    {
        /// <summary>
        ///     使用者資料的資料庫元件
        /// </summary>
        private readonly IProfileDao _profileDao;

        public AuthService(IProfileDao profileDao)
        {
            _profileDao = profileDao;
        }

        /// <summary>
        ///     使用者資料
        /// </summary>
        public Profile Profile { get; private set; }

        /// <summary>
        ///     取得AccessToken
        /// </summary>
        /// <param name="userName">使用者帳號</param>
        /// <returns>AccessToken</returns>
        public string GetAccessToken(string userName)
        {
            var tokenValue = $"{Guid.NewGuid()}_{userName}_{new DateTime().AddHours(6)}";
            var bytes = Encoding.UTF8.GetBytes(tokenValue);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        ///     驗證AccessToken
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <returns>驗證成功或失敗</returns>
        public bool Verify(string accessToken)
        {
            var bytes = Convert.FromBase64String(accessToken);
            var tokenValue = Encoding.UTF8.GetString(bytes);
            var values = tokenValue.Split('_');

            if (values.Length != 3) return false;

            Profile = _profileDao.GetProfile(values[1]);
            return Profile.Exist;
        }
    }
}