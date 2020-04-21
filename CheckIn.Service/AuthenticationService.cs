using System;
using CheckIn.Adapter;
using CheckIn.Common;

namespace CheckIn.Service
{
    public interface IAuthenticationService
    {
        string GetAccessToken(string userName, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IProfileDao profileDao;
        private readonly IHash sha256Adapter;
        private readonly IAuthService authService;

        public AuthenticationService(IProfileDao profileDao, IHash sha256Adapter, IAuthService authService)
        {
            this.profileDao = profileDao;
            this.sha256Adapter = sha256Adapter;
            this.authService = authService;
        }


        public string GetAccessToken(string userName, string password)
        {
            var hashPassword = profileDao.GetHashPassword(userName);
            var hash = sha256Adapter.ComputeHash(password);

            if (hash == hashPassword)
            {
                var accessToken = authService.GetAccessToken(userName);
                profileDao.UpdateAccessToken(userName, accessToken);

                return accessToken;
            }

            throw new OperationFailedException("帳號或密碼驗證失敗!!");
        }
    }
}