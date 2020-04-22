using System;
using CheckIn.Adapter;
using CheckIn.Common;

namespace CheckIn.Service
{
    /// <summary>
    /// 認證方式介面
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// 取得AccessToken
        /// </summary>
        /// <param name="userName">使用者帳號</param>
        /// <param name="password">使用者密碼</param>
        /// <returns>AccessToken</returns>
        string GetAccessToken(string userName, string password);
    }

    /// <summary>
    /// 認證方式元件
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// 使用者資料的資料庫元件
        /// </summary>
        private readonly IProfileDao _profileDao;
        /// <summary>
        /// Sha256加密元件
        /// </summary>
        private readonly IHash _sha256Adapter;
        /// <summary>
        /// 驗證服務元件 
        /// </summary>
        private readonly IAuthService _authService;

        public AuthenticationService(IProfileDao profileDao, IHash sha256Adapter, IAuthService authService)
        {
            this._profileDao = profileDao;
            this._sha256Adapter = sha256Adapter;
            this._authService = authService;
        }

        /// <summary>
        /// 取得AccessToken
        /// </summary>
        /// <param name="userName">使用者帳號</param>
        /// <param name="password">使用者密碼</param>
        /// <returns>AccessToken</returns>
        public string GetAccessToken(string userName, string password)
        {
            var hashPassword = _profileDao.GetHashPassword(userName);
            var hash = _sha256Adapter.ComputeHash(password);

            if (hash == hashPassword)
            {
                var accessToken = _authService.GetAccessToken(userName);
                _profileDao.UpdateAccessToken(userName, accessToken);

                return accessToken;
            }

            throw new OperationFailedException("帳號或密碼驗證失敗!!");
        }
    }
}