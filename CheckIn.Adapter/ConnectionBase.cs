using System.Configuration;

namespace CheckIn.Adapter
{
    public class ConnectionBase
    {
        /// <summary>
        /// 資料庫連線字串
        /// </summary>
        protected static string ConnectionString => ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }
}