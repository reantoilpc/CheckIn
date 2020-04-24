using System.Configuration;

namespace CheckIn.Adapter
{
    /// <summary>
    ///     資料庫基底類別
    /// </summary>
    public class ConnectionBase
    {
        /// <summary>
        ///     資料庫連線字串
        /// </summary>
        protected static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }
}