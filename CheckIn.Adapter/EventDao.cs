using System;
using System.Data;
using System.Data.SqlClient;

namespace CheckIn.Adapter
{
    public interface IEventDao
    {
        string GetQrCode(int eventId, int accountId);
        bool UpdateQrCodeStatus(int eventId, int accountId, bool isCheckIn);
        bool DeleteQrCode(int eventId, int accountId);
    }

    public class EventDao : ConnectionBase, IEventDao
    {
        public string GetQrCode(int eventId, int accountId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sqlCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Get_Event_QrCode"
                };

                sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;
                sqlCommand.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
                connection.Open();
                var reader = sqlCommand.ExecuteReader();

                return reader.Read() 
                    ? reader["QrCode"].ToString() 
                    : string.Empty;
            }
        }

        public bool UpdateQrCodeStatus(int eventId, int accountId, bool isCheckIn)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sqlCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Update_Event_QrCode"
                };

                sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;
                sqlCommand.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
                sqlCommand.Parameters.Add("@CheckInStatus", SqlDbType.SmallInt).Value = Convert.ToInt32(isCheckIn);
                connection.Open();
                var reader = sqlCommand.ExecuteReader();

                return reader.RecordsAffected > 0;
            }
        }

        public bool DeleteQrCode(int eventId, int accountId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sqlCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Delete_Event_QrCode"
                };

                sqlCommand.Parameters.Add("@EventId", SqlDbType.Int).Value = eventId;
                sqlCommand.Parameters.Add("@AccountId", SqlDbType.Int).Value = accountId;
                connection.Open();
                var reader = sqlCommand.ExecuteReader();

                return reader.RecordsAffected > 0;
            }
        }
    }
}