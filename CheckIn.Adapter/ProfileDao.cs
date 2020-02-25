using System;
using CheckIn.Class;

namespace CheckIn.Adapter
{
    public interface IProfileDao
    {
        string GetHashPassword(string userName);
        Profile GetProfile(string userName);
        void UpdateAccessToken(string userName, string accessToken);
    }


    public class ProfileDao : IProfileDao
    {
        public string GetHashPassword(string userName)
        {
            throw new NotImplementedException();
        }

        public Profile GetProfile(string userName)
        {
            return new Profile();
        }

        public void UpdateAccessToken(string userName, string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}