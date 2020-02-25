using System.Text;

namespace CheckIn.Adapter
{
    public interface IHash
    {
        string ComputeHash(string password);
    }

    public class Sha256Adapter : IHash
    {
        public  string ComputeHash(string password)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();
            var computeHash = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));

            foreach (var b in computeHash)
            {
                hash.Append(b.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}