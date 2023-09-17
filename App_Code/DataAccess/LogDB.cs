using System;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.ComponentModel;
using Ybyk.QBank.BO;

namespace Ybyk.QBank.Dal
{
    [DataObjectAttribute()]
    public class LogDB
    {
        public LogDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Log GetItem(Int32 pi_log_id)
        {
            Log myLog = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select log_id,log_content,user_id,user_name,log_date,host_ip from T_log tl,T_user tu where tl.user_id=tu.user_id and log_id=@pi_log_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_log_id", pi_log_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myLog = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myLog;
        }

        public static LogList GetList()
        {
            LogList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select log_id,log_content,tu.user_id,user_name,log_date,tl.host_ip from T_log tl,T_user tu where tl.user_id=tu.user_id", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new LogList();
                        while (myReader.Read())
                        {
                            myList.Add(FillDataRecord(myReader));
                        }
                    }
                    myReader.Close();
                }
            }

            return myList;
        }

        public static LogList GetList(Int32 pi_user_id)
        {
            LogList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select log_id,log_content,tu.user_id,user_name,log_date,tl.host_ip from T_log tl,T_user tu where tl.user_id=tu.user_id and tu.user_id=@pi_user_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_user_id", pi_user_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new LogList();
                        while (myReader.Read())
                        {
                            myList.Add(FillDataRecord(myReader));
                        }
                    }
                    myReader.Close();
                }
            }

            return myList;
        }

        public static LogList GetList(string pi_user_id, string pi_start_date, string pi_finish_date)
        {
            LogList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select log_id,log_content,tu.user_id,user_name,log_date,tl.host_ip from T_log tl,T_user tu where tl.user_id=tu.user_id and tu.user_id=@pi_user_id and DATEDIFF(log_date,@pi_start_date)>=0 and DATEDIFF(@pi_finish_date,log_date)>=0", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_user_id", pi_user_id);
                cmd.Parameters.AddWithValue("pi_start_date", pi_start_date);
                cmd.Parameters.AddWithValue("pi_finish_date", pi_finish_date);
                
                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new LogList();
                        while (myReader.Read())
                        {
                            myList.Add(FillDataRecord(myReader));
                        }
                    }
                    myReader.Close();
                }
            }

            return myList;
        }


        public static Int32 Insert(Log myLog)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_log", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_log_content", MySqlDbType.VarChar)).Value = myLog.Log_content;                
                cmd.Parameters.Add(new MySqlParameter("pi_log_date", MySqlDbType.DateTime)).Value = myLog.Log_date;
                cmd.Parameters.Add(new MySqlParameter("pi_host_ip", MySqlDbType.VarChar)).Value = myLog.Host_ip;

                if (myLog.User_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = myLog.User_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_log_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        private static Log FillDataRecord(IDataRecord myDataRecord)
        {
            Log myLog = new Log();

            myLog.Log_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Log_id"));
            myLog.User_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("User_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Log_content")))
            {
                myLog.Log_content =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Log_content"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Host_ip")))
            {
                myLog.Host_ip =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Host_ip"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Log_date")))
            {
                myLog.Log_date =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Log_date"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("User_name")))
            {
                myLog.User_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("User_name"));
            }
            return myLog;
        }

    }
}