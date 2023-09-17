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
    public class Exam_Question_TemplateDB
    {
        public Exam_Question_TemplateDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Exam_Question_Template GetItem(Int32 pi_exam_question_template_id)
        {
            Exam_Question_Template myExam_Question_Template = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Exam_question_template where exam_question_template_id=@pi_exam_question_template_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_question_template_id", pi_exam_question_template_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myExam_Question_Template = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myExam_Question_Template;
        }

        public static Int32 AskQuestion_Order_In_Exam_Group(Int32 pi_exam_id, Int32 pi_exam_group_id, Int32 pi_exam_question_order)
        {
            Int32 result = -1;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_sel_que_order_in_exam_group", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pi_exam_id", pi_exam_id);
                cmd.Parameters.AddWithValue("pi_exam_group_id", pi_exam_group_id);
                cmd.Parameters.AddWithValue("pi_exam_question_order", pi_exam_question_order);

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

        public static Exam_Question_TemplateList GetList(Int32 pi_exam_template_id)
        {
            Exam_Question_TemplateList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Exam_question_template where exam_template_id=@pi_exam_template_id order by exam_question_order", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_template_id", pi_exam_template_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Exam_Question_TemplateList();
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


        public static Int32 Insert(Exam_Question_Template myExam_Question_Template)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_exam_question_template", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                if (myExam_Question_Template.Exam_template_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_template_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_template_id", MySqlDbType.Int32)).Value = myExam_Question_Template.Exam_template_id;
                }
                if (myExam_Question_Template.Exam_question_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_id", MySqlDbType.Int32)).Value = myExam_Question_Template.Exam_question_id;
                }
                if (myExam_Question_Template.Exam_question_order == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_order", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_order", MySqlDbType.Int32)).Value = myExam_Question_Template.Exam_question_order;
                }


                MySqlParameter myParameter = new MySqlParameter("po_exam_question_template_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Exam_Question_Template myExam_Question_Template)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_exam_question_template", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myExam_Question_Template.Exam_question_template_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_template_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_template_id", MySqlDbType.Int32)).Value = myExam_Question_Template.Exam_question_template_id;
                }
                if (myExam_Question_Template.Exam_template_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_template_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_template_id", MySqlDbType.Int32)).Value = myExam_Question_Template.Exam_template_id;
                }
                if (myExam_Question_Template.Exam_question_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_id", MySqlDbType.Int32)).Value = myExam_Question_Template.Exam_question_id;
                }
                if (myExam_Question_Template.Exam_question_order == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_order", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_order", MySqlDbType.Int32)).Value = myExam_Question_Template.Exam_question_order;
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

        public static bool Delete(Int32 pi_exam_question_template_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_exam_question_template", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_exam_question_template_id", MySqlDbType.Int32)).Value = pi_exam_question_template_id;

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

        private static Exam_Question_Template FillDataRecord(IDataRecord myDataRecord)
        {
            Exam_Question_Template myExam_Question_Template = new Exam_Question_Template();

            myExam_Question_Template.Exam_question_template_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_question_template_id"));
            myExam_Question_Template.Exam_template_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_template_id"));
            myExam_Question_Template.Exam_question_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_question_id"));
            myExam_Question_Template.Exam_question_order = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_question_order"));

            return myExam_Question_Template;
        }

    }
}