using System.Configuration;

namespace CheckIn.Adapter
{
    public class ConnectionBase
    {
        protected static string ConnectionString => ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }
}