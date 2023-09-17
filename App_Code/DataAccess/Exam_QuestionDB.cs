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
    public class Exam_QuestionDB
    {
        public Exam_QuestionDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Exam_Question GetItem(Int32 pi_exam_question_id)
        {
            Exam_Question myExam_Question = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Exam_question where exam_question_id=@pi_exam_question_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_question_id", pi_exam_question_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myExam_Question = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myExam_Question;
        }

        public static Exam_Question GetItem(Int32 pi_exam_id, Int32 pi_question_id)
        {
            Exam_Question myExam_Question = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Exam_question where exam_id=@pi_exam_id and question_id=@pi_question_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_id", pi_exam_id);
                cmd.Parameters.AddWithValue("pi_question_id", pi_question_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myExam_Question = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myExam_Question;
        }

        public static Exam_QuestionList GetList(Int32 pi_exam_id)
        {
            Exam_QuestionList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Exam_question where exam_id=@pi_exam_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_id", pi_exam_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Exam_QuestionList();
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


        public static Int32 Insert(Exam_Question myExam_Question)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_exam_question", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_question_success_rate", MySqlDbType.VarChar)).Value = myExam_Question.Question_success_rate;

                if (myExam_Question.Exam_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = myExam_Question.Exam_id;
                }
                if (myExam_Question.Question_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = myExam_Question.Question_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_exam_question_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Exam_Question myExam_Question)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_exam_question", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myExam_Question.Exam_question_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_id", MySqlDbType.Int32)).Value = myExam_Question.Exam_question_id;
                }
                if (myExam_Question.Exam_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = myExam_Question.Exam_id;
                }
                if (myExam_Question.Question_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = myExam_Question.Question_id;
                }
                cmd.Parameters.Add(new MySqlParameter("pi_question_success_rate", MySqlDbType.VarChar)).Value = myExam_Question.Question_success_rate;

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

        public static bool Delete_All_Question(Int32 pi_exam_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_exam_question_all", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = pi_exam_id;

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

        public static bool Delete(Int32 pi_exam_question_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_exam_question", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_exam_question_id", MySqlDbType.Int32)).Value = pi_exam_question_id;

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

        private static Exam_Question FillDataRecord(IDataRecord myDataRecord)
        {
            Exam_Question myExam_Question = new Exam_Question();

            myExam_Question.Exam_question_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_question_id"));
            myExam_Question.Exam_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_id"));
            myExam_Question.Question_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_id"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_success_rate")))
            {
                myExam_Question.Question_success_rate =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_success_rate"));
            }

            return myExam_Question;
        }

    }
}