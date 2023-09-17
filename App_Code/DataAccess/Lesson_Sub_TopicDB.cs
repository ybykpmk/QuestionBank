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
    public class Lesson_Sub_TopicDB
    {
        public Lesson_Sub_TopicDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Lesson_Sub_Topic GetItem(Int32 pi_lesson_sub_topic_id)
        {
            Lesson_Sub_Topic myLesson_Sub_Topic = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select lesson_sub_topic_id,lesson_sub_topic_name,lesson_sub_topic_code,tlsi.lesson_subject_id,tlsi.created_date,tls.lesson_subject_name,tls.lesson_id,tl.lesson_name from T_Lesson_sub_topic tlsi,T_Lesson_subject tls,T_Lesson tl where tlsi.lesson_subject_id=tls.lesson_subject_id and tls.lesson_id=tl.lesson_id and lesson_sub_topic_id=@pi_lesson_sub_topic_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_lesson_sub_topic_id", pi_lesson_sub_topic_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myLesson_Sub_Topic = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myLesson_Sub_Topic;
        }

        public static Lesson_Sub_Topic GetItem(Int32 pi_lesson_id, Int32 pi_lesson_subject_id, string pi_lesson_sub_topic_name)
        {
            Lesson_Sub_Topic myLesson_Sub_Topic = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select lesson_sub_topic_id,lesson_sub_topic_name,lesson_sub_topic_code,tlsi.lesson_subject_id,tlsi.created_date,tls.lesson_subject_name,tls.lesson_id,tl.lesson_name from T_Lesson_sub_topic tlsi,T_Lesson_subject tls,T_Lesson tl where tlsi.lesson_subject_id=tls.lesson_subject_id and tls.lesson_id=tl.lesson_id and tlsi.lesson_subject_id=@pi_lesson_subject_id and tls.lesson_id=@pi_lesson_id and lesson_sub_topic_name=@pi_lesson_sub_topic_name", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);
                cmd.Parameters.AddWithValue("pi_lesson_subject_id", pi_lesson_subject_id);
                cmd.Parameters.AddWithValue("pi_lesson_sub_topic_name", pi_lesson_sub_topic_name);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myLesson_Sub_Topic = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myLesson_Sub_Topic;
        }

        public static Lesson_Sub_TopicList GetList(Int32 pi_department_id, Int32 pi_lesson_id, Int32 pi_lesson_subject_id)
        {
            Lesson_Sub_TopicList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select lesson_sub_topic_id,lesson_sub_topic_name,lesson_sub_topic_code,tlsi.lesson_subject_id,tlsi.created_date,tls.lesson_subject_name,tls.lesson_id,tl.lesson_name from T_Lesson_sub_topic tlsi,T_Lesson_subject tls,T_Lesson tl where tlsi.lesson_subject_id=tls.lesson_subject_id and tls.lesson_id=tl.lesson_id and tl.department_id=@pi_department_id and tls.lesson_id=@pi_lesson_id and tlsi.lesson_subject_id=@pi_lesson_subject_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);
                cmd.Parameters.AddWithValue("pi_lesson_subject_id", pi_lesson_subject_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Lesson_Sub_TopicList();
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

        public static Lesson_Sub_TopicList GetList(Int32 pi_department_id, Int32 pi_lesson_id)
        {
            Lesson_Sub_TopicList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select lesson_sub_topic_id,lesson_sub_topic_name,lesson_sub_topic_code,tlsi.lesson_subject_id,tlsi.created_date,tls.lesson_subject_name,tls.lesson_id,tl.lesson_name from T_Lesson_sub_topic tlsi,T_Lesson_subject tls,T_Lesson tl where tlsi.lesson_subject_id=tls.lesson_subject_id and tls.lesson_id=tl.lesson_id and tl.department_id=@pi_department_id and tls.lesson_id=@pi_lesson_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);
                cmd.Parameters.AddWithValue("pi_lesson_id", pi_lesson_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Lesson_Sub_TopicList();
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

        public static Lesson_Sub_TopicList GetList(Int32 pi_department_id)
        {
            Lesson_Sub_TopicList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select lesson_sub_topic_id,lesson_sub_topic_name,lesson_sub_topic_code,tlsi.lesson_subject_id,tlsi.created_date,tls.lesson_subject_name,tls.lesson_id,tl.lesson_name from T_Lesson_sub_topic tlsi,T_Lesson_subject tls,T_Lesson tl where tlsi.lesson_subject_id=tls.lesson_subject_id and tls.lesson_id=tl.lesson_id and tl.department_id=@pi_department_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Lesson_Sub_TopicList();
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

        public static Int32 GetExam_Count_About_Les_Sub_Topic(Int32 pi_lesson_sub_topic_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_sel_exam_count_about_les_sub_topic", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pi_lesson_sub_topic_id", pi_lesson_sub_topic_id);

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

        public static Int32 Insert(Lesson_Sub_Topic myLesson_Sub_Topic)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_lesson_sub_topic", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_name", MySqlDbType.VarChar)).Value = myLesson_Sub_Topic.Lesson_sub_topic_name;
                cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_code", MySqlDbType.VarChar)).Value = myLesson_Sub_Topic.Lesson_sub_topic_code;
                cmd.Parameters.Add(new MySqlParameter("pi_created_date", MySqlDbType.DateTime)).Value = myLesson_Sub_Topic.Created_date;

                if (myLesson_Sub_Topic.Lesson_subject_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_id", MySqlDbType.Int32)).Value = myLesson_Sub_Topic.Lesson_subject_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_lesson_sub_topic_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Lesson_Sub_Topic myLesson_Sub_Topic)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_lesson_sub_topic", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myLesson_Sub_Topic.Lesson_sub_topic_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = myLesson_Sub_Topic.Lesson_sub_topic_id;
                }
                if (myLesson_Sub_Topic.Lesson_subject_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_lesson_subject_id", MySqlDbType.Int32)).Value = myLesson_Sub_Topic.Lesson_subject_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_name", MySqlDbType.VarChar)).Value = myLesson_Sub_Topic.Lesson_sub_topic_name;
                cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_code", MySqlDbType.VarChar)).Value = myLesson_Sub_Topic.Lesson_sub_topic_code;

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
                MySqlCommand cmd = new MySqlCommand("pro_del_t_lesson_sub_topic_for_lesson", conn);
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

        public static bool Delete_For_Lesson_Subject(Int32 pi_lesson_subject_id)
        {
            Int32 result = -1;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_lesson_sub_topic_for_lesson_subject", conn);
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

            return result > -1;
        }

        public static bool Delete(Int32 pi_lesson_sub_topic_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_lesson_sub_topic", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_lesson_sub_topic_id", MySqlDbType.Int32)).Value = pi_lesson_sub_topic_id;

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

        private static Lesson_Sub_Topic FillDataRecord(IDataRecord myDataRecord)
        {
            Lesson_Sub_Topic myLesson_Sub_Topic = new Lesson_Sub_Topic();

            myLesson_Sub_Topic.Lesson_sub_topic_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Lesson_sub_topic_id"));
            myLesson_Sub_Topic.Lesson_subject_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Lesson_subject_id"));
            myLesson_Sub_Topic.Lesson_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Lesson_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_name")))
            {
                myLesson_Sub_Topic.Lesson_name=
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_subject_name")))
            {
                myLesson_Sub_Topic.Lesson_subject_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_subject_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_sub_topic_name")))
            {
                myLesson_Sub_Topic.Lesson_sub_topic_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_sub_topic_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lesson_sub_topic_code")))
            {
                myLesson_Sub_Topic.Lesson_sub_topic_code =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Lesson_sub_topic_code"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Created_date")))
            {
                myLesson_Sub_Topic.Created_date =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Created_date"));
            }

            return myLesson_Sub_Topic;
        }

    }
}