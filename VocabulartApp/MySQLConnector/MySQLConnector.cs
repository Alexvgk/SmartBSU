using Android.Util;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartBSU.MySQLConnector
{
    public class MySQLConnector
    {
        private static readonly string CON_STRING = "server=128.140.32.175;user=bsuuser;password=bsuuser;database=smartBSU;";
        private static readonly string EMAIL_CODE_INSERT = "INSERT INTO `smartBSU`.`users` ( `Email`, `RegCode`) VALUES (@param_email, @param_code);";
        private static readonly string UID_INSERT = "UPDATE `smartBSU`.`users` SET `UID` = @param_uid WHERE (`Email` = @param_email);";
        private static readonly string SELECT_CODE = "SELECT `RegCode` FROM `smartBSU`.`users` where `Email` = @param_email;";

        public static void SetEmailToDB(string email, string code)
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(CON_STRING))
                {
                    mySqlConnection.Open();
                    string sql = EMAIL_CODE_INSERT;
                    using (MySqlCommand msq = new MySqlCommand(sql, mySqlConnection))
                    {
                        msq.Parameters.AddWithValue("@param_email", email);
                        msq.Parameters.AddWithValue("@param_code", code);
                        msq.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
        public static void SetUIDToDB(string uid,string email) {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(CON_STRING))
                {
                    mySqlConnection.Open();
                    string sql = UID_INSERT;
                    using (MySqlCommand msq = new MySqlCommand(sql, mySqlConnection))
                    {
                        msq.Parameters.AddWithValue("@param_email", email);
                        msq.Parameters.AddWithValue("@param_uid", uid);
                        msq.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
        public static string GetCodeFormDB(string Email)
        {
            string code = null;

            using (MySqlConnection mySqlConnection = new MySqlConnection(CON_STRING))
            {
                mySqlConnection.Open();
                string sql = SELECT_CODE;
                MySqlCommand msq = new MySqlCommand(sql, mySqlConnection);
                msq.Parameters.AddWithValue("@param_email", Email);
                using (MySqlDataReader mysrd = msq.ExecuteReader())
                {
                    if (mysrd.Read())
                    {
                        code = mysrd.GetString(0);
                    }
                }
            }
            return code;

        }
    }
}
