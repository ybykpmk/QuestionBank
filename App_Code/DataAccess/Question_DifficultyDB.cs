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
    public class Question_DifficultyDB
    {
        public Question_DifficultyDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Question_Difficulty GetItem(Int32 pi_question_difficulty_id)
        {
            Question_Difficulty myQuestion_Difficulty = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Question_difficulty where question_difficulty_id=@pi_question_difficulty_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_question_difficulty_id", pi_question_difficulty_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myQuestion_Difficulty = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myQuestion_Difficulty;
        }

        public static Question_DifficultyList GetList()
        {
            Question_DifficultyList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Question_difficulty", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Question_DifficultyList();
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

        private static Question_Difficulty FillDataRecord(IDataRecord myDataRecord)
        {
            Question_Difficulty myQuestion_Difficulty = new Question_Difficulty();

            myQuestion_Difficulty.Question_difficulty_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_difficulty_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_difficulty_degree")))
            {
                myQuestion_Difficulty.Question_difficulty_degree =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_difficulty_degree"));
            }

            return myQuestion_Difficulty;
        }

    }
}