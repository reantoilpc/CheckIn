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
        private readonly IProfileDao _profileDao;
        private readonly IHash _sha256Adapter;
        private readonly IAuthService _authService;

        public AuthenticationService(IProfileDao profileDao, IHash sha256Adapter, IAuthService authService)
        {
            _profileDao = profileDao;
            _sha256Adapter = sha256Adapter;
            _authService = authService;
        }


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