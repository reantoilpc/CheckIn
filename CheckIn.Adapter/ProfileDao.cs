using System;

namespace CheckIn.Adapter
{
    public interface IProfileDao
    {
        string GetHashPassword(string userName);
        bool UserExist(string userName);
    }


    public class ProfileDao : IProfileDao
    {
        public string GetHashPassword(string userName)
        {
            throw new NotImplementedException();
        }

        public bool UserExist(string userName)
        {
            throw new NotImplementedException();
        }
    }
}