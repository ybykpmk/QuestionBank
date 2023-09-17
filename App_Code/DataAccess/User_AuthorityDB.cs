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
    public class User_AuthorityDB
    {
        public User_AuthorityDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static User_Authority GetItem(Int32 pi_user_authority_id)
        {
            User_Authority myUser_Authority = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select tua.user_authority_id,tua.user_id,tua.authority_id,ta.authority_name from T_User_authority tua,T_Authority ta where tua.user_authority_id=@pi_user_authority_id and tua.authority_id=ta.authority_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_user_authority_id", pi_user_authority_id);
                cmd.Connection = conn;
                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myUser_Authority = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myUser_Authority;
        }

        public static User_AuthorityList GetList(Int32 pi_user_id)
        {
            User_AuthorityList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select tua.user_authority_id,tua.user_id,tua.authority_id,ta.authority_name from T_User_authority tua,T_Authority ta where tua.authority_id=ta.authority_id and tua.user_id=@pi_user_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_user_id", pi_user_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new User_AuthorityList();
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


        public static Int32 Insert(User_Authority myUser_Authority)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_user_authority", conn);

                cmd.CommandType = CommandType.StoredProcedure;                

                if (myUser_Authority.Authority_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_authority_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_authority_id", MySqlDbType.Int32)).Value = myUser_Authority.Authority_id;
                }

                if (myUser_Authority.User_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = myUser_Authority.User_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_user_authority_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static bool Delete(Int32 pi_user_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_user_authority", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = pi_user_id;

                MySqlParameter myParameter = new MySqlParameter("po_rows", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();

            }

            return result > 0;
        }

        private static User_Authority FillDataRecord(IDataRecord myDataRecord)
        {
            User_Authority myUser_Authority = new User_Authority();

            myUser_Authority.Authority_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Authority_id"));
            myUser_Authority.User_authority_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("User_authority_id"));
            myUser_Authority.User_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("User_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Authority_name")))
            {
                myUser_Authority.Authority_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Authority_name"));
            }

            return myUser_Authority;
        }

    }
}