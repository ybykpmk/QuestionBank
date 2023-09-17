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
    public class Exam_TemplateDB
    {
        public Exam_TemplateDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Exam_Template GetItem(Int32 pi_exam_template_id)
        {
            Exam_Template myExam_Template = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Exam_template where exam_template_id=@pi_exam_template_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_template_id", pi_exam_template_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myExam_Template = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myExam_Template;
        }

        public static Exam_TemplateList GetList(Int32 pi_exam_id)
        {
            Exam_TemplateList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Exam_template where exam_id=@pi_exam_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_id", pi_exam_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Exam_TemplateList();
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


        public static Int32 Insert(Exam_Template myExam_Template)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_exam_template", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_created_date", MySqlDbType.DateTime)).Value = myExam_Template.Created_date;

                if (myExam_Template.Exam_group_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_group_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_group_id", MySqlDbType.Int32)).Value = myExam_Template.Exam_group_id;
                }
                if (myExam_Template.Exam_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = myExam_Template.Exam_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_exam_template_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Exam_Template myExam_Template)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_exam_template", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myExam_Template.Exam_template_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_template_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_template_id", MySqlDbType.Int32)).Value = myExam_Template.Exam_template_id;
                }
                if (myExam_Template.Exam_group_id== -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_group_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_group_id", MySqlDbType.Int32)).Value = myExam_Template.Exam_group_id;
                }
                if (myExam_Template.Exam_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_id", MySqlDbType.Int32)).Value = myExam_Template.Exam_id;
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

        public static bool Delete(Int32 pi_exam_template_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_exam_template", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_exam_template_id", MySqlDbType.Int32)).Value = pi_exam_template_id;

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

        private static Exam_Template FillDataRecord(IDataRecord myDataRecord)
        {
            Exam_Template myExam_Template = new Exam_Template();

            myExam_Template.Exam_template_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_template_id"));
            myExam_Template.Exam_group_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_group_id"));
            myExam_Template.Exam_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Created_date")))
            {
                myExam_Template.Created_date =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Created_date"));
            }

            return myExam_Template;
        }

    }
}