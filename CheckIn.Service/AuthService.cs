using System;
using System.Security.Cryptography;
using System.Text;
using CheckIn.Adapter;

namespace CheckIn.Service
{
    public interface IAuthService
    {
        string GetAccessToken(string userName);
        bool Verfy(string accessToken);
    }

    public class AuthService : IAuthService
    {
        private IProfileDao _profileDao;

        public AuthService(IProfileDao profileDao)
        {
            _profileDao = profileDao;
        }

        public string GetAccessToken(string userName)
        {
            var tokenValue = $"{Guid.NewGuid()}_{userName}_{new DateTime().AddHours(6)}";
            var bytes = Encoding.UTF8.GetBytes(tokenValue);
            return Convert.ToBase64String(bytes);
        }

        public bool Verfy(string accessToken)
        {
            var bytes = Convert.FromBase64String(accessToken);
            var tokenValue = Encoding.UTF8.GetString(bytes);
            var values = tokenValue.Split('_');

            if (values.Length != 3)
            {
                return false;
            }

            return _profileDao.UserExist(values[1]);
        }
    }
}