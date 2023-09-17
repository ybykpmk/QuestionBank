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
    public class Exam_Sub_Top_Que_CountDB
    {
        public Exam_Sub_Top_Que_CountDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Exam_Sub_Top_Que_Count GetItem(Int32 pi_exam_sub_top_que_count_id)
        {
            Exam_Sub_Top_Que_Count myQuestion = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select exam_sub_top_que_count_id,exam_id,testqc.lesson_sub_topic_id,testqc.question_difficulty_id,testqc.question_type_id,tqt.question_type_name,question_count,tlst.lesson_sub_topic_name,tqd.question_difficulty_degree,tlst.lesson_subject_id,tls.lesson_subject_name from t_exam_sub_top_que_count testqc,t_lesson_sub_topic tlst,t_question_difficulty tqd,t_lesson_subject tls,t_question_type tqt where testqc.question_type_id=tqt.question_type_id and tls.lesson_subject_id=tlst.lesson_subject_id and testqc.lesson_sub_topic_id=tlst.lesson_sub_topic_id and testqc.question_difficulty_id=tqd.question_difficulty_id and exam_sub_top_que_count_id=@pi_exam_sub_top_que_count_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_sub_top_que_count_id", pi_exam_sub_top_que_count_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myQuestion = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myQuestion;
        }

        public static Exam_Sub_Top_Que_Count GetItem(Int32 pi_exam_id, Int32 pi_lesson_sub_topic_id, Int32 pi_question_difficulty_id, Int32 pi_question_type_id)
        {
            Exam_Sub_Top_Que_Count myQuestion = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select exam_sub_top_que_count_id,exam_id,testqc.lesson_sub_topic_id,testqc.question_difficulty_id,testqc.question_type_id,tqt.question_type_name,question_count,tlst.lesson_sub_topic_name,tqd.question_difficulty_degree,tlst.lesson_subject_id,tls.lesson_subject_name from t_exam_sub_top_que_count testqc,t_lesson_sub_topic tlst,t_question_difficulty tqd,t_lesson_subject tls,t_question_type tqt where testqc.question_type_id=tqt.question_type_id and tls.lesson_subject_id=tlst.lesson_subject_id and testqc.lesson_sub_topic_id=tlst.lesson_sub_topic_id and testqc.question_difficulty_id=tqd.question_difficulty_id and exam_id=@pi_exam_id and testqc.lesson_sub_topic_id=@pi_lesson_sub_topic_id and testqc.question_difficulty_id=@pi_question_difficulty_id and testqc.question_type_id=@pi_question_type_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_id", pi_exam_id);
                cmd.Parameters.AddWithValue("pi_lesson_sub_topic_id", pi_lesson_sub_topic_id);
                cmd.Parameters.AddWithValue("pi_question_difficulty_id", pi_question_difficulty_id);
                cmd.Parameters.AddWithValue("pi_question_type_id", pi_question_type_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myQuestion = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myQuestion;
        }

        public static Exam_Sub_Top_Que_CountList GetList(Int32 pi_exam_id)
        {
            Exam_Sub_Top_Que_CountList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select exam_sub_top_que_count_id,exam_id,testqc.lesson_sub_topic_id,testqc.question_difficulty_id,testqc.question_type_id,tqt.question_type_name,question_count,tlst.lesson_sub_topic_name,tqd.question_difficulty_degree,tlst.lesson_subject_id,tls.lesson_subject_name from t_exam_sub_top_que_count testqc,t_lesson_sub_topic tlst,t_question_difficulty tqd,t_lesson_subject tls,t_question_type tqt where testqc.question_type_id=tqt.question_type_id and tls.lesson_subject_id=tlst.lesson_subject_id and testqc.lesson_sub_topic_id=tlst.lesson_sub_topic_id and testqc.question_difficulty_id=tqd.question_difficulty_id and exam_id=@pi_exam_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_id", pi_exam_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Exam_Sub_Top_Que_CountList();
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

        public static Int32 Insert(Exam_Sub_Top_Que_Count myExam_Sub_Top_Que_Count)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_exam_sub_top_que_count", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                if (myExam_Sub_Top_Que_Count.Exam_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Exam_id;
                }
                if (myExam_Sub_Top_Que_Count.Lesson_sub_topic_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Lesson_sub_topic_id;
                }
                if (myExam_Sub_Top_Que_Count.Question_count == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_count", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_count", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Question_count;
                }
                if (myExam_Sub_Top_Que_Count.Question_difficulty_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_difficulty_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_difficulty_id", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Question_difficulty_id;
                }
                if (myExam_Sub_Top_Que_Count.Question_type_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_type_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_type_id", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Question_type_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_exam_sub_top_que_count_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Exam_Sub_Top_Que_Count myExam_Sub_Top_Que_Count)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_exam_sub_top_que_count", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myExam_Sub_Top_Que_Count.Exam_id== -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Exam_id;
                }
                if (myExam_Sub_Top_Que_Count.Exam_sub_top_que_count_id== -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_sub_top_que_count_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_sub_top_que_count_id", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Exam_sub_top_que_count_id;
                }
                if (myExam_Sub_Top_Que_Count.Lesson_sub_topic_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Lesson_sub_topic_id;
                }
                if (myExam_Sub_Top_Que_Count.Question_count == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_count", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_count", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Question_count;
                }
                if (myExam_Sub_Top_Que_Count.Question_difficulty_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_difficulty_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_difficulty_id", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Question_difficulty_id;
                }
                if (myExam_Sub_Top_Que_Count.Question_type_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_type_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_type_id", MySqlDbType.Int32)).Value = myExam_Sub_Top_Que_Count.Question_type_id;
                }

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

        public static bool Delete_All_Questions(Int32 pi_exam_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_exam_sub_top_que_count_all", conn);
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

        public static bool Delete(Int32 pi_exam_sub_top_que_count_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_exam_sub_top_que_count", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_exam_sub_top_que_count_id", MySqlDbType.Int32)).Value = pi_exam_sub_top_que_count_id;

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

        private static Exam_Sub_Top_Que_Count FillDataRecord(IDataRecord myDataRecord)
        {
            Exam_Sub_Top_Que_Count myExam_Sub_Top_Que_Count = new Exam_Sub_Top_Que_Count();

            myExam_Sub_Top_Que_Count.Exam_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_id"));
            myExam_Sub_Top_Que_Count.Exam_sub_top_que_count_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_sub_top_que_count_id"));
            myExam_Sub_Top_Que_Count.Lesson_sub_topic_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Lesson_sub_topic_id"));
            myExam_Sub_Top_Que_Count.Question_count = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_count"));
            myExam_Sub_Top_Que_Count.Question_difficulty_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_difficulty_id"));
            myExam_Sub_Top_Que_Count.Lesson_subject_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Lesson_subject_id"));
            myExam_Sub_Top_Que_Count.Question_type_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_type_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_sub_topic_name")))
            {
                myExam_Sub_Top_Que_Count.Lesson_sub_topic_name=
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_sub_topic_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_difficulty_degree")))
            {
                myExam_Sub_Top_Que_Count.Question_difficulty_degree =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_difficulty_degree"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_subject_name")))
            {
                myExam_Sub_Top_Que_Count.Lesson_subject_name=
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_subject_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_type_name")))
            {
                myExam_Sub_Top_Que_Count.Question_type_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_type_name"));
            }

            return myExam_Sub_Top_Que_Count;
        }

    }
}