using System;

namespace CheckIn.Adapter
{
    public interface IProfileDao
    {
        string GetHashPassword(string userName);
    }


    public class ProfileDao : IProfileDao
    {
        public string GetHashPassword(string userName)
        {
            throw new NotImplementedException();
        }
    }
}