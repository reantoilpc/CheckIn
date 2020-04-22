using System.Text;

namespace CheckIn.Adapter
{
    /// <summary>
    /// 加密介面
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// 使用Hash進行加密
        /// </summary>
        /// <param name="password">登入的密碼</param>
        /// <returns>加密過的密碼</returns>
        string ComputeHash(string password);
    }

    /// <summary>
    /// Sha256加密元件
    /// </summary>
    public class Sha256Adapter : IHash
    {
        /// <summary>
        /// 使用Hash進行加密
        /// </summary>
        /// <param name="password">登入的密碼</param>
        /// <returns>加密過的密碼</returns>
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