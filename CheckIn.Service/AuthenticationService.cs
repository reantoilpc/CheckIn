using System;

namespace CheckIn.Service
{
    public interface IAuthenticationService
    {
        bool ValidateAccessToken(string accessToken);
    }

    public class AuthenticationService : IAuthenticationService
    {
        public bool ValidateAccessToken(string accessToken)
        {
            throw new NotImplementedException();
        }

        public string GetAccessToken(string userName, string password)
        {
            return string.Empty;
        }
    }
}