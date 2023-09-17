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
    public class RankDB
    {
        public RankDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Rank GetItem(Int32 pi_rank_id)
        {
            Rank myRank = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_rank where rank_id=@pi_rank_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_rank_id", pi_rank_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myRank = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myRank;
        }

        public static RankList GetList()
        {
            RankList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_rank", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new RankList();
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

        private static Rank FillDataRecord(IDataRecord myDataRecord)
        {
            Rank myRank = new Rank();

            myRank.Rank_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Rank_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Rank_name")))
            {
                myRank.Rank_name=
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Rank_name"));
            }

            return myRank;
        }

    }
}