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
    public class QuestionDB
    {
        public QuestionDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Question GetItem(Int32 pi_question_id)
        {
            Question myQuestion = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select question_id,question_content,question_photo,tq.question_type_id,lesson_sub_topic_id,created_date,user_id,tq.question_difficulty_id,tqt.question_type_name,tqd.question_difficulty_degree from T_question tq,T_question_difficulty tqd,t_question_type tqt where tq.question_difficulty_id=tqd.question_difficulty_id and tq.question_type_id=tqt.question_type_id and question_id=@pi_question_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_question_id", pi_question_id);

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

        public static Int32 GetQuestion_Count_In_Exams(Int32 pi_question_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_sel_que_count_in_exams", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pi_question_id", pi_question_id);

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

        public static Int32 Get_Exam_Que(Int32 pi_lesson_sub_topic_id, Int32 pi_question_type_id, Int32 pi_question_difficulty_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_sel_t_question_for_exam", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pi_lesson_sub_topic_id", pi_lesson_sub_topic_id);
                cmd.Parameters.AddWithValue("pi_question_type_id", pi_question_type_id);
                cmd.Parameters.AddWithValue("pi_question_difficulty_id", pi_question_difficulty_id);

                MySqlParameter myParameter = new MySqlParameter("po_question_id", MySqlDbType.Int32);

                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);
                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Get_Que_Count(Int32 pi_lesson_sub_topic_id, Int32 pi_question_type_id, Int32 pi_question_difficulty_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_sel_t_question", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pi_lesson_sub_topic_id", pi_lesson_sub_topic_id);
                cmd.Parameters.AddWithValue("pi_question_type_id", pi_question_type_id);
                cmd.Parameters.AddWithValue("pi_question_difficulty_id", pi_question_difficulty_id);

                MySqlParameter myParameter = new MySqlParameter("po_que_count", MySqlDbType.Int32);

                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);
                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static QuestionList GetList_For_Upd_Del_Question(Int32 pi_department_id, Int32 pi_lesson_id, Int32 pi_lesson_subject_id, Int32 pi_lesson_sub_topic_id)
        {
            QuestionList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select question_id,question_content,question_photo,tq.question_type_id,tq.lesson_sub_topic_id,tq.created_date,user_id,tq.question_difficulty_id,tqt.question_type_name,tqd.question_difficulty_degree from T_question tq,T_question_difficulty tqd,t_question_type tqt,t_lesson tl,t_lesson_subject tls,t_lesson_sub_topic tlst where tq.question_difficulty_id=tqd.question_difficulty_id and tq.question_type_id=tqt.question_type_id and tl.lesson_id=tls.lesson_id and tls.lesson_subject_id=tlst.lesson_subject_id and tq.lesson_sub_topic_id=tlst.lesson_sub_topic_id and tl.department_id=@pi_department_id and tl.lesson_id=@pi_lesson_id and tls.lesson_subject_id=@pi_lesson_subject_id and tlst.lesson_sub_topic_id=@pi_lesson_sub_topic_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);
                cmd.Parameters.AddWithValue("pi_lesson_subject_id", pi_lesson_subject_id);
                cmd.Parameters.AddWithValue("pi_lesson_sub_topic_id", pi_lesson_sub_topic_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new QuestionList();
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

        public static QuestionList GetList_For_Upd_Del_Question(Int32 pi_department_id, Int32 pi_lesson_id, Int32 pi_lesson_subject_id)
        {
            QuestionList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select question_id,question_content,question_photo,tq.question_type_id,tq.lesson_sub_topic_id,tq.created_date,user_id,tq.question_difficulty_id,tqt.question_type_name,tqd.question_difficulty_degree from T_question tq,T_question_difficulty tqd,t_question_type tqt,t_lesson tl,t_lesson_subject tls,t_lesson_sub_topic tlst where tq.question_difficulty_id=tqd.question_difficulty_id and tq.question_type_id=tqt.question_type_id and tl.lesson_id=tls.lesson_id and tls.lesson_subject_id=tlst.lesson_subject_id and tq.lesson_sub_topic_id=tlst.lesson_sub_topic_id and tl.department_id=@pi_department_id and tl.lesson_id=@pi_lesson_id and tls.lesson_subject_id=@pi_lesson_subject_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);
                cmd.Parameters.AddWithValue("pi_lesson_subject_id", pi_lesson_subject_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new QuestionList();
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

        public static QuestionList GetList_For_Upd_Del_Question(Int32 pi_department_id, Int32 pi_lesson_id)
        {
            QuestionList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select question_id,question_content,question_photo,tq.question_type_id,tq.lesson_sub_topic_id,tq.created_date,user_id,tq.question_difficulty_id,tqt.question_type_name,tqd.question_difficulty_degree from T_question tq,T_question_difficulty tqd,t_question_type tqt,t_lesson tl,t_lesson_subject tls,t_lesson_sub_topic tlst where tq.question_difficulty_id=tqd.question_difficulty_id and tq.question_type_id=tqt.question_type_id and tl.lesson_id=tls.lesson_id and tls.lesson_subject_id=tlst.lesson_subject_id and tq.lesson_sub_topic_id=tlst.lesson_sub_topic_id and tl.department_id=@pi_department_id and tl.lesson_id=@pi_lesson_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new QuestionList();
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

        public static QuestionList GetList_For_Upd_Del_Question(Int32 pi_department_id)
        {
            QuestionList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select question_id,question_content,question_photo,tq.question_type_id,tq.lesson_sub_topic_id,tq.created_date,user_id,tq.question_difficulty_id,tqt.question_type_name,tqd.question_difficulty_degree from T_question tq,T_question_difficulty tqd,t_question_type tqt,t_lesson tl,t_lesson_subject tls,t_lesson_sub_topic tlst where tq.question_difficulty_id=tqd.question_difficulty_id and tq.question_type_id=tqt.question_type_id and tl.lesson_id=tls.lesson_id and tls.lesson_subject_id=tlst.lesson_subject_id and tq.lesson_sub_topic_id=tlst.lesson_sub_topic_id and tl.department_id=@pi_department_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new QuestionList();
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

        public static QuestionList GetList_For_Another_Questions(Int32 pi_exam_id, Int32 pi_question_id, Int32 pi_lesson_sub_topic_id, Int32 pi_question_type_id, Int32 pi_question_difficulty_id)
        {
            QuestionList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select question_id,question_content,question_photo,tq.question_type_id,lesson_sub_topic_id,created_date,user_id,tq.question_difficulty_id,tqt.question_type_name,tqd.question_difficulty_degree from T_question tq,T_question_difficulty tqd,t_question_type tqt where tq.question_difficulty_id=tqd.question_difficulty_id and tq.question_type_id=tqt.question_type_id and tq.question_id not in (@pi_question_id) and tq.question_id not in (select question_id from t_exam_question where exam_id=@pi_exam_id) and tq.lesson_sub_topic_id=@pi_lesson_sub_topic_id and tq.question_type_id=@pi_question_type_id and tq.question_difficulty_id=@pi_question_difficulty_id", conn);                

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_id", pi_exam_id);
                cmd.Parameters.AddWithValue("pi_question_id", pi_question_id);
                cmd.Parameters.AddWithValue("pi_lesson_sub_topic_id", pi_lesson_sub_topic_id);
                cmd.Parameters.AddWithValue("pi_question_type_id", pi_question_type_id);
                cmd.Parameters.AddWithValue("pi_question_difficulty_id", pi_question_difficulty_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new QuestionList();
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

        public static QuestionList GetList(Int32 pi_lesson_sub_topic_id)
        {
            QuestionList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select question_id,question_content,question_photo,tq.question_type_id,lesson_sub_topic_id,created_date,user_id,tq.question_difficulty_id,tqt.question_type_name,tqd.question_difficulty_degree from T_question tq,T_question_difficulty tqd,t_question_type tqt where tq.question_difficulty_id=tqd.question_difficulty_id and tq.question_type_id=tqt.question_type_id and lesson_sub_topic_id=@pi_lesson_sub_topic_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_lesson_sub_topic_id", pi_lesson_sub_topic_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new QuestionList();
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

        public static Int32 Insert(Question myQuestion)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_question", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_question_content", MySqlDbType.VarChar)).Value = myQuestion.Question_content;
                cmd.Parameters.Add(new MySqlParameter("pi_question_photo", MySqlDbType.VarChar)).Value = myQuestion.Question_photo;
                cmd.Parameters.Add(new MySqlParameter("pi_created_date", MySqlDbType.DateTime)).Value = myQuestion.Created_date;
                
                if (myQuestion.Question_type_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_type_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_type_id", MySqlDbType.Int32)).Value = myQuestion.Question_type_id;
                }
                if (myQuestion.Lesson_sub_topic_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = myQuestion.Lesson_sub_topic_id;
                }
                if (myQuestion.User_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = myQuestion.User_id;
                }
                if (myQuestion.Question_difficulty_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_difficulty_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_difficulty_id", MySqlDbType.Int32)).Value = myQuestion.Question_difficulty_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_question_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Question myQuestion)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_question", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myQuestion.Question_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_id", MySqlDbType.Int32)).Value = myQuestion.Question_id;
                }
                if (myQuestion.Question_type_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_type_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_type_id", MySqlDbType.Int32)).Value = myQuestion.Question_type_id;
                }
                if (myQuestion.Lesson_sub_topic_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = myQuestion.Lesson_sub_topic_id;
                }
                if (myQuestion.User_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = myQuestion.User_id;
                }
                if (myQuestion.Question_difficulty_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_difficulty_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_difficulty_id", MySqlDbType.Int32)).Value = myQuestion.Question_difficulty_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_question_content", MySqlDbType.VarChar)).Value = myQuestion.Question_content;
                cmd.Parameters.Add(new MySqlParameter("pi_question_photo", MySqlDbType.VarChar)).Value = myQuestion.Question_photo;              

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

        public static bool Delete(Int32 pi_question_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_question", conn);
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

            return result > 0;
        }

        private static Question FillDataRecord(IDataRecord myDataRecord)
        {
            Question myQuestion = new Question();

            myQuestion.Question_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_id"));
            myQuestion.Question_type_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_type_id"));
            myQuestion.Lesson_sub_topic_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Lesson_sub_topic_id"));
            myQuestion.User_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("User_id"));
            myQuestion.Question_difficulty_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_difficulty_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_content")))
            {
                myQuestion.Question_content =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_content"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_photo")))
            {
                myQuestion.Question_photo =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_photo"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Created_date")))
            {
                myQuestion.Created_date =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Created_date"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_type_name")))
            {
                myQuestion.Question_type_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_type_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Question_difficulty_degree")))
            {
                myQuestion.Question_difficulty_degree =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Question_difficulty_degree"));
            }

            return myQuestion;
        }

    }
}