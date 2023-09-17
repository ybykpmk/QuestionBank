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
    public class Lesson_SubjectDB
    {
        public Lesson_SubjectDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Lesson_Subject GetItem(string pi_lesson_subject_name,Int32 pi_lesson_id)
        {
            Lesson_Subject myLesson_Subject = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select lesson_subject_id,lesson_subject_name,lesson_subject_code,tls.lesson_id,tls.created_date,tl.lesson_name from T_Lesson_subject tls,T_Lesson tl where tls.lesson_id=tl.lesson_id and tls.lesson_id=@pi_lesson_id and lesson_subject_name=@pi_lesson_subject_name", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_lesson_subject_name", pi_lesson_subject_name);
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myLesson_Subject = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myLesson_Subject;
        }

        public static Lesson_Subject GetItem(Int32 pi_lesson_subject_id)
        {
            Lesson_Subject myLesson_Subject = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select lesson_subject_id,lesson_subject_name,lesson_subject_code,tls.lesson_id,tls.created_date,tl.lesson_name from T_Lesson_subject tls,T_Lesson tl where tls.lesson_id=tl.lesson_id and tls.lesson_subject_id=@pi_lesson_subject_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_lesson_subject_id", pi_lesson_subject_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myLesson_Subject = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myLesson_Subject;
        }

        public static Lesson_SubjectList GetList(Int32 pi_department_id)
        {
            Lesson_SubjectList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select lesson_subject_id,lesson_subject_name,lesson_subject_code,tls.lesson_id,tls.created_date,tl.lesson_name from T_Lesson_subject tls,T_Lesson tl where tls.lesson_id=tl.lesson_id and tl.department_id=@pi_department_id order by lesson_name", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Lesson_SubjectList();
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

        public static Lesson_SubjectList GetList(Int32 pi_department_id, Int32 pi_lesson_id)
        {
            Lesson_SubjectList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select lesson_subject_id,lesson_subject_name,lesson_subject_code,tls.lesson_id,tls.created_date,tl.lesson_name from T_Lesson_subject tls,T_Lesson tl where tls.lesson_id=tl.lesson_id and tls.lesson_id=@pi_lesson_id and tl.department_id=@pi_department_id order by lesson_name", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Lesson_SubjectList();
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

        public static Int32 GetLesson_Count_About_Les_Sub_In_Exams(Int32 pi_lesson_subject_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_sel_les_count_about_les_sub_in_exams", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pi_lesson_subject_id", pi_lesson_subject_id);

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

        public static Int32 Insert(Lesson_Subject myLesson_Subject)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_lesson_subject", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_name", MySqlDbType.VarChar)).Value = myLesson_Subject.Lesson_subject_name;
                cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_code", MySqlDbType.VarChar)).Value = myLesson_Subject.Lesson_subject_code;
                cmd.Parameters.Add(new MySqlParameter("pi_created_date", MySqlDbType.DateTime)).Value = myLesson_Subject.Created_date;

                if (myLesson_Subject.Lesson_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = myLesson_Subject.Lesson_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_lesson_subject_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Lesson_Subject myLesson_Subject)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_lesson_subject", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myLesson_Subject.Lesson_subject_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_id", MySqlDbType.Int32)).Value = myLesson_Subject.Lesson_subject_id;
                }
                if (myLesson_Subject.Lesson_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = myLesson_Subject.Lesson_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_name", MySqlDbType.VarChar)).Value = myLesson_Subject.Lesson_subject_name;
                cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_code", MySqlDbType.VarChar)).Value = myLesson_Subject.Lesson_subject_code;

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

        public static bool Delete_For_Lesson(Int32 pi_lesson_id)
        {
            Int32 result = -1;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_lesson_subject_for_lesson", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = pi_lesson_id;

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

        public static bool Delete(Int32 pi_lesson_subject_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_lesson_subject", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_id", MySqlDbType.Int32)).Value = pi_lesson_subject_id;

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

        private static Lesson_Subject FillDataRecord(IDataRecord myDataRecord)
        {
            Lesson_Subject myLesson_Subject = new Lesson_Subject();

            myLesson_Subject.Lesson_subject_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Lesson_subject_id"));
            myLesson_Subject.Lesson_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Lesson_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_subject_name")))
            {
                myLesson_Subject.Lesson_subject_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_subject_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_subject_code")))
            {
                myLesson_Subject.Lesson_subject_code =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_subject_code"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_name")))
            {
                myLesson_Subject.Lesson_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Created_date")))
            {
                myLesson_Subject.Created_date =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Created_date"));
            }
            return myLesson_Subject;
        }

    }
}