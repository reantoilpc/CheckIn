using System;
using System.Security.Cryptography;
using System.Text;
using CheckIn.Adapter;
using CheckIn.Class;

namespace CheckIn.Service
{
    public interface IAuthService
    {
        string GetAccessToken(string userName);
        bool Verify(string accessToken);
    }

    public class AuthService : IAuthService
    {
        private readonly IProfileDao profileDao;
        public Profile Profile { get; private set; }

        public AuthService(IProfileDao profileDao)
        {
            this.profileDao = profileDao;
        }

        public string GetAccessToken(string userName)
        {
            var tokenValue = $"{Guid.NewGuid()}_{userName}_{new DateTime().AddHours(6)}";
            var bytes = Encoding.UTF8.GetBytes(tokenValue);
            return Convert.ToBase64String(bytes);
        }

        public bool Verify(string accessToken)
        {
            var bytes = Convert.FromBase64String(accessToken);
            var tokenValue = Encoding.UTF8.GetString(bytes);
            var values = tokenValue.Split('_');

            if (values.Length != 3)
            {
                return false;
            }

            Profile = profileDao.GetProfile(values[1]);
            return Profile.Exist;
        }
    }
}