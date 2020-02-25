using System.Configuration;

namespace CheckIn.Adapter
{
    public class ConnectionBase
    {
        public string ConnectionString => ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }
}