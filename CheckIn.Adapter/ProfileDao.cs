using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CheckIn.Class;
using Dapper;

namespace CheckIn.Adapter
{
    public interface IProfileDao
    {
        string GetHashPassword(string userName);
        Profile GetProfile(string userName);
        void UpdateAccessToken(string userName, string accessToken);
    }


    public class ProfileDao : ConnectionBase, IProfileDao
    {
        public string GetHashPassword(string userName)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sqlCommand = new SqlCommand()
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "Get_Profile_Password"
                };

                sqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                connection.Open();
                var reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    return reader["Password"].ToString();
                }

                return string.Empty;
            }
        }

        public Profile GetProfile(string userName)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                var strSql = "select * from Profile where UserName = @UserName ";

                var result = conn.QueryFirstOrDefault<Profile>(strSql, new {userName});

                return result;
            }
            //using (var connection = new SqlConnection(ConnectionString))
            //{
            //    var sqlCommand = new SqlCommand()
            //    {
            //        Connection = connection,
            //        CommandType = CommandType.StoredProcedure,
            //        CommandText = "Get_Profile"
            //    };

            //    sqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
            //    connection.Open();
            //    var reader = sqlCommand.ExecuteReader();

            //    if (reader.Read())
            //    {
            //        return new Profile()
            //        {
            //            AccountId = Convert.ToInt32(reader["Id"]),
            //            UserName = reader["UserName"].ToString(),
            //            AccessToken = reader["AccessToken"].ToString(),
            //        };
            //    }

            //    return new Profile();
            //}
        }

        public void UpdateAccessToken(string userName, string accessToken)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sqlCommand = new SqlCommand()
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