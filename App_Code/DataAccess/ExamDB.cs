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
    public class ExamDB
    {
        public ExamDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Exam GetItem(string pi_exam_name)
        {
            Exam myExam = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select exam_id,exam_name,te.lesson_id,te.created_date,te.user_id,asked_year,exam_question_finished,tl.lesson_name,tu.user_name from T_Exam te,T_Lesson tl,T_user tu where tu.user_id=te.user_id and te.lesson_id=tl.lesson_id and exam_name=@pi_exam_name", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_name", pi_exam_name);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myExam = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myExam;
        }

        public static Exam GetItem(Int32 pi_exam_id)
        {
            Exam myExam = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select exam_id,exam_name,te.lesson_id,te.created_date,te.user_id,asked_year,exam_question_finished,tl.lesson_name,tu.user_name from T_Exam te,T_Lesson tl,T_user tu where tu.user_id=te.user_id and te.lesson_id=tl.lesson_id and exam_id=@pi_exam_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_id", pi_exam_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myExam = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myExam;
        }

        public static ExamList GetList_Pub_Exam_For_Department(Int32 pi_department_id)
        {
            ExamList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select exam_id,exam_name,te.lesson_id,te.created_date,te.user_id,asked_year,exam_question_finished,tl.lesson_name,tu.user_name from T_Exam te,T_Lesson tl,T_user tu where tu.user_id=te.user_id and te.lesson_id=tl.lesson_id and tl.department_id=@pi_department_id and exam_id in (select distinct exam_id from t_exam_template)", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new ExamList();
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

        public static ExamList GetList_For_Department(Int32 pi_department_id)
        {
            ExamList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select exam_id,exam_name,te.lesson_id,te.created_date,te.user_id,asked_year,exam_question_finished,tl.lesson_name,tu.user_name from T_Exam te,T_Lesson tl,T_user tu where tu.user_id=te.user_id and te.lesson_id=tl.lesson_id and tl.department_id=@pi_department_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new ExamList();
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

        public static ExamList GetList_Pub_Exam_For_Lesson(Int32 pi_lesson_id)
        {
            ExamList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select exam_id,exam_name,te.lesson_id,te.created_date,te.user_id,asked_year,exam_question_finished,tl.lesson_name,tu.user_name from T_Exam te,T_Lesson tl,T_user tu where tu.user_id=te.user_id and te.lesson_id=tl.lesson_id and te.lesson_id=@pi_lesson_id and exam_id in (select distinct exam_id from t_exam_template)", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new ExamList();
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

        public static ExamList GetList(Int32 pi_lesson_id)
        {
            ExamList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select exam_id,exam_name,te.lesson_id,te.created_date,te.user_id,asked_year,exam_question_finished,tl.lesson_name,tu.user_name from T_Exam te,T_Lesson tl,T_user tu where tu.user_id=te.user_id and te.lesson_id=tl.lesson_id and te.lesson_id=@pi_lesson_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new ExamList();
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

        public static Int32 Insert(Exam myExam)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_exam", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_exam_name", MySqlDbType.VarChar)).Value = myExam.Exam_name;
                cmd.Parameters.Add(new MySqlParameter("pi_asked_year", MySqlDbType.VarChar)).Value = myExam.Asked_year;
                cmd.Parameters.Add(new MySqlParameter("pi_exam_question_finished", MySqlDbType.VarChar)).Value = myExam.Exam_question_finished;
                cmd.Parameters.Add(new MySqlParameter("pi_created_date", MySqlDbType.DateTime)).Value = myExam.Created_date;


                if (myExam.User_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = myExam.User_id;
                }
                if (myExam.Lesson_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = myExam.Lesson_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_exam_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Exam myExam)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_exam", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myExam.Exam_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = myExam.Exam_id;
                }

                if (myExam.Lesson_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = myExam.Lesson_id;
                }
                
                if (myExam.User_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = myExam.User_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_exam_name", MySqlDbType.VarChar)).Value = myExam.Exam_name;
                cmd.Parameters.Add(new MySqlParameter("pi_asked_year", MySqlDbType.VarChar)).Value = myExam.Asked_year;
                cmd.Parameters.Add(new MySqlParameter("pi_exam_question_finished", MySqlDbType.VarChar)).Value = myExam.Exam_question_finished;

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

        public static bool Delete(Int32 pi_exam_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_exam", conn);
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

            return result > 0;
        }

        private static Exam FillDataRecord(IDataRecord myDataRecord)
        {
            Exam myExam= new Exam();

            myExam.Exam_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_id"));
            myExam.Lesson_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Lesson_id"));
            myExam.User_id= myDataRecord.GetInt32(myDataRecord.GetOrdinal("User_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Exam_name")))
            {
                myExam.Exam_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Exam_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Asked_year")))
            {
                myExam.Asked_year =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Asked_year"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Exam_question_finished")))
            {
                myExam.Exam_question_finished =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Exam_question_finished"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Created_date")))
            {
                myExam.Created_date=
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Created_date"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_name")))
            {
                myExam.Lesson_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("User_name")))
            {
                myExam.User_name=
                    myDataRecord.GetString(myDataRecord.GetOrdinal("User_name"));
            }

            return myExam;
        }

    }
}