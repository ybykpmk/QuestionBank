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
    public class LessonDB
    {
        public LessonDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Lesson GetItem(string pi_lesson_name,Int32 pi_department_id)
        {
            Lesson myLesson = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Lesson where lesson_name=@pi_lesson_name and department_id=@pi_department_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_lesson_name", pi_lesson_name);
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myLesson = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myLesson;
        }

        public static Lesson GetItem(Int32 pi_lesson_id)
        {
            Lesson myLesson = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Lesson where lesson_id=@pi_lesson_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myLesson = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myLesson;
        }

        public static LessonList GetList(Int32 pi_department_id)
        {
            LessonList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Lesson where department_id=@pi_department_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new LessonList();
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

        public static Int32 GetLesson_Count_In_Exams(Int32 pi_lesson_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_sel_les_count_in_exams", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);

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

        public static Int32 Insert(Lesson myLesson)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_lesson", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_lesson_name", MySqlDbType.VarChar)).Value = myLesson.Lesson_name;
                cmd.Parameters.Add(new MySqlParameter("pi_lesson_code", MySqlDbType.VarChar)).Value = myLesson.Lesson_code;              
                cmd.Parameters.Add(new MySqlParameter("pi_lesson_class", MySqlDbType.VarChar)).Value = myLesson.Lesson_class;
                cmd.Parameters.Add(new MySqlParameter("pi_lesson_term", MySqlDbType.VarChar)).Value = myLesson.Lesson_term;
                cmd.Parameters.Add(new MySqlParameter("pi_created_date", MySqlDbType.DateTime)).Value = myLesson.Created_date;

                if (myLesson.Department_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_department_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_department_id", MySqlDbType.Int32)).Value = myLesson.Department_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_lesson_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Lesson myLesson)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_lesson", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myLesson.Lesson_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_id", MySqlDbType.Int32)).Value = myLesson.Lesson_id;
                }
                if (myLesson.Department_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_department_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_department_id", MySqlDbType.Int32)).Value = myLesson.Department_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_lesson_name", MySqlDbType.VarChar)).Value = myLesson.Lesson_name;
                cmd.Parameters.Add(new MySqlParameter("pi_lesson_code", MySqlDbType.VarChar)).Value = myLesson.Lesson_code;
                cmd.Parameters.Add(new MySqlParameter("pi_lesson_class", MySqlDbType.VarChar)).Value = myLesson.Lesson_class;
                cmd.Parameters.Add(new MySqlParameter("pi_lesson_term", MySqlDbType.VarChar)).Value = myLesson.Lesson_term;                

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

        public static bool Delete(Int32 pi_lesson_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_lesson", conn);
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

            return result > 0;
        }

        private static Lesson FillDataRecord(IDataRecord myDataRecord)
        {
            Lesson myLesson = new Lesson();

            myLesson.Lesson_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Lesson_id"));
            myLesson.Department_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Department_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_name")))
            {
                myLesson.Lesson_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_code")))
            {
                myLesson.Lesson_code =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_code"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_class")))
            {
                myLesson.Lesson_class =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_class"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_term")))
            {
                myLesson.Lesson_term =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_term"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Created_date")))
            {
                myLesson.Created_date =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Created_date"));
            }

            return myLesson;
        }

    }
}