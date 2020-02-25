namespace CheckIn.Service
{
    public interface IAuthService
    {
        string GetAccessToken(string userName);
    }

    public class AuthService : IAuthService
    {
        public string GetAccessToken(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}