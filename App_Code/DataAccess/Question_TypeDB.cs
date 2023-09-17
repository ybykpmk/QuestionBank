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
    public class Question_TypeDB
    {
        public Question_TypeDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Question_Type GetItem(Int32 pi_question_type_id)
        {
            Question_Type myQuestion_Type = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_question_type where question_type_id=@pi_question_type_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_question_type_id", pi_question_type_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myQuestion_Type = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myQuestion_Type;
        }

        public static Question_TypeList GetList()
        {
            Question_TypeList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Question_type", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Question_TypeList();
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

        private static Question_Type FillDataRecord(IDataRecord myDataRecord)
        {
            Question_Type myQuestion_Type = new Question_Type();

            myQuestion_Type.Question_type_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_type_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_type_name")))
            {
                myQuestion_Type.Question_type_name=
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_type_name"));
            }

            return myQuestion_Type;
        }

    }
}