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
    public class AuthorityDB
    {
        public AuthorityDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Authority GetItem(Int32 pi_authority_id)
        {
            Authority myAuthority = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Authority where authority_id=@pi_authority_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_authority_id", pi_authority_id);
                cmd.Connection = conn;
                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myAuthority = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myAuthority;
        }

        public static AuthorityList GetList()
        {
            AuthorityList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Authority", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new AuthorityList();
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

        private static Authority FillDataRecord(IDataRecord myDataRecord)
        {
            Authority myAuthority = new Authority();
            myAuthority.Authority_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Authority_id"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Authority_name")))
            {
                myAuthority.Authority_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Authority_name"));
            }

            return myAuthority;
        }

    }
}