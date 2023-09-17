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
    public class Question_OptionDB
    {
        public Question_OptionDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Question_Option GetItem(Int32 pi_question_option_id)
        {
            Question_Option myQuestion_Option = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_question_option where question_option_id=@pi_question_option_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_question_option_id", pi_question_option_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myQuestion_Option = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myQuestion_Option;
        }

        public static Question_OptionList GetList(Int32 pi_question_id)
        {
            Question_OptionList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_question_option where question_id=@pi_question_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_question_id", pi_question_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Question_OptionList();
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


        public static Int32 Insert(Question_Option myQuestion_Option)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_question_option", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_question_option_content", MySqlDbType.VarChar)).Value = myQuestion_Option.Question_option_content;
                cmd.Parameters.Add(new MySqlParameter("pi_question_option_photo", MySqlDbType.VarChar)).Value = myQuestion_Option.Question_option_photo;                
                cmd.Parameters.Add(new MySqlParameter("pi_question_option_true", MySqlDbType.VarChar)).Value = myQuestion_Option.Question_option_true;

                if (myQuestion_Option.Question_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = myQuestion_Option.Question_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_question_option_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Question_Option myQuestion_Option)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_question_option", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myQuestion_Option.Question_option_id== -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_id", MySqlDbType.Int32)).Value = myQuestion_Option.Question_option_id;
                }
                if (myQuestion_Option.Question_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = myQuestion_Option.Question_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_question_option_content", MySqlDbType.VarChar)).Value = myQuestion_Option.Question_option_content;
                cmd.Parameters.Add(new MySqlParameter("pi_question_option_photo", MySqlDbType.VarChar)).Value = myQuestion_Option.Question_option_photo;
                cmd.Parameters.Add(new MySqlParameter("pi_question_option_true", MySqlDbType.VarChar)).Value = myQuestion_Option.Question_option_true;

                MySqlParameter myParameter = new MySqlParameter("po_rows", MySqlDbType.Int32);

                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);
                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static bool Delete(Int32 pi_question_option_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_question_option", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_question_option_id", MySqlDbType.Int32)).Value = pi_question_option_id;

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

        public static bool Delete_Que_Opts(Int32 pi_question_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_question_all_options", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = pi_question_id;

                MySqlParameter myParameter = new MySqlParameter("po_rows", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();

            }

            return result > -1;
        }

        private static Question_Option FillDataRecord(IDataRecord myDataRecord)
        {
            Question_Option myQuestion_Option = new Question_Option();

            myQuestion_Option.Question_option_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_option_id"));
            myQuestion_Option.Question_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_option_content")))
            {
                myQuestion_Option.Question_option_content =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_option_content"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_option_photo")))
            {
                myQuestion_Option.Question_option_photo =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_option_photo"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_option_true")))
            {
                myQuestion_Option.Question_option_true =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_option_true"));
            }

            return myQuestion_Option;
        }

    }
}