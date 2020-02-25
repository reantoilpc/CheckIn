using System;
using CheckIn.Adapter;

namespace CheckIn.Service
{
    public interface IAuthenticationService
    {
        bool ValidateAccessToken(string accessToken);
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

        public bool ValidateAccessToken(string accessToken)
        {
            throw new NotImplementedException();
        }

        public string GetAccessToken(string userName, string password)
        {
            var hashPassword = _profileDao.GetHashPassword(userName);
            var hash = _sha256Adapter.ComputeHash(password);

            if (hash == hashPassword)
            {
                return _authService.GetAccessToken(userName);
            }

            return string.Empty;
        }
    }
}