using System.Data;
using System.Data.SqlClient;
using CheckIn.Class;
using Dapper;

namespace CheckIn.Adapter
{
    /// <summary>
    ///     使用者資料的資料庫介面
    /// </summary>
    public interface IProfileDao
    {
        /// <summary>
        ///     取得加密過的密碼
        /// </summary>
        /// <param name="userName">使用者帳號</param>
        /// <returns>加密過的密碼</returns>
        string GetHashPassword(string userName);

        /// <summary>
        ///     取得個人資料
        /// </summary>
        /// <param name="userName">使用者帳號</param>
        /// <returns>個人的資料</returns>
        Profile GetProfile(string userName);

        /// <summary>
        ///     更新使用者的AccessToken
        /// </summary>
        /// <param name="userName">使用者帳號</param>
        /// <param name="accessToken">AccessToken</param>
        void UpdateAccessToken(string userName, string accessToken);
    }

    /// <summary>
    ///     使用者資料的資料庫元件
    /// </summary>
    public class ProfileDao : ConnectionBase, IProfileDao
    {
        /// <summary>
        ///     取得加密過的密碼
        /// </summary>
        /// <param name="userName">使用者帳號</param>
        /// <returns>加密過的密碼</returns>
        public string GetHashPassword(string userName)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Get_Profile_Password"
                };

                sqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                connection.Open();
                var reader = sqlCommand.ExecuteReader();

                return reader.Read()
                    ? reader["Password"].ToString()
                    : string.Empty;
            }
        }

        /// <summary>
        ///     取得個人資料
        /// </summary>
        /// <param name="userName">使用者帳號</param>
        /// <returns>個人的資料</returns>
        public Profile GetProfile(string userName)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                var strSql = "select * from Profile where UserName = @UserName ";

                var result = conn.QueryFirstOrDefault<Profile>(strSql, new {userName});

                return result;
            }
        }

        /// <summary>
        ///     更新使用者的AccessToken
        /// </summary>
        /// <param name="userName">使用者帳號</param>
        /// <param name="accessToken">AccessToken</param>
        public void UpdateAccessToken(string userName, string accessToken)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sqlCommand = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Update_Profile_AccessToken"
                };

                sqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                sqlCommand.Parameters.Add("@AccessToken", SqlDbType.VarChar).Value = accessToken;
                connection.Open();
                sqlCommand.ExecuteReader();
            }
        }
    }
}