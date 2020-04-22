using System;
using System.Data;
using System.Data.SqlClient;

namespace CheckIn.Adapter
{
    /// <summary>
    /// 活動的資料庫介面
    /// </summary>
    public interface IEventDao
    {
        /// <summary>
        /// 取得QrCode
        /// </summary>
        /// <param name="eventId">活動Id</param>
        /// <param name="accountId">帳號Id</param>
        /// <returns>QrCode字串</returns>
        string GetQrCode(int eventId, int accountId);
        /// <summary>
        /// 更新QrCode的狀態
        /// </summary>
        /// <param name="eventId">活動Id</param>
        /// <param name="accountId">帳號Id</param>
        /// <param name="isCheckIn">是否己經報到</param>
        /// <returns>更新成功或失敗</returns>
        bool UpdateQrCodeStatus(int eventId, int accountId, bool isCheckIn);
        /// <summary>
        /// 刪除QrCode
        /// </summary>
        /// <param name="eventId">活動Id</param>
        /// <param name="accountId">帳號Id</param>
        /// <returns>刪除成功或失敗</returns>
        bool DeleteQrCode(int eventId, int accountId);
    }
    
    /// <summary>
    /// 活動的資料庫元件
    /// </summary>
    public class EventDao : ConnectionBase, IEventDao
    {
        /// <summary>
        /// 取得QrCode
        /// </summary>
        /// <param name="eventId">活動Id</param>
        /// <param name="accountId">帳號Id</param>
        /// <returns>QrCode字串</returns>
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
        /// <summary>
        /// 更新QrCode的狀態
        /// </summary>
        /// <param name="eventId">活動Id</param>
        /// <param name="accountId">帳號Id</param>
        /// <param name="isCheckIn">是否己經報到</param>
        /// <returns>更新成功或失敗</returns>
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
        /// <summary>
        /// 刪除QrCode
        /// </summary>
        /// <param name="eventId">活動Id</param>
        /// <param name="accountId">帳號Id</param>
        /// <returns>刪除成功或失敗</returns>
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