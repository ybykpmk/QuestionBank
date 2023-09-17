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
    public class Question_Option_TemplateDB
    {
        public Question_Option_TemplateDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Question_Option_Template GetItem(Int32 pi_question_option_template_id)
        {
            Question_Option_Template myQuestion_Option_Template = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_question_option_template where question_option_template_id=@pi_question_option_template_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_question_option_template_id", pi_question_option_template_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myQuestion_Option_Template = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myQuestion_Option_Template;
        }

        public static Question_Option_TemplateList GetList(Int32 pi_exam_question_template_id)
        {
            Question_Option_TemplateList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_question_option_template where exam_question_template_id=@pi_exam_question_template_id order by question_option_order", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_question_template_id", pi_exam_question_template_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Question_Option_TemplateList();
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

        public static Int32 AskQuestion_Option_Order_In_Exam(Int32 pi_exam_id, Int32 pi_exam_group_id, Int32 pi_exam_question_id, Int32 pi_question_option_order)
        {
            Int32 result = -1;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_sel_que_opt_order_in_exam", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pi_exam_id", pi_exam_id);
                cmd.Parameters.AddWithValue("pi_exam_group_id", pi_exam_group_id);
                cmd.Parameters.AddWithValue("pi_exam_question_id", pi_exam_question_id);
                cmd.Parameters.AddWithValue("pi_question_option_order", pi_question_option_order);

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

        public static Int32 Insert(Question_Option_Template myQuestion_Option_Template)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_question_option_template", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                if (myQuestion_Option_Template.Question_option_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_id", MySqlDbType.Int32)).Value = myQuestion_Option_Template.Question_option_id;
                }
                if (myQuestion_Option_Template.Exam_question_template_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_template_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_template_id", MySqlDbType.Int32)).Value = myQuestion_Option_Template.Exam_question_template_id;
                }
                if (myQuestion_Option_Template.Question_option_order == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_order", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_order", MySqlDbType.Int32)).Value = myQuestion_Option_Template.Question_option_order;
                }

                MySqlParameter myParameter = new MySqlParameter("po_question_option_template_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Question_Option_Template myQuestion_Option_Template)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_question_option_template", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myQuestion_Option_Template.Question_option_template_id== -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_template_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_template_id", MySqlDbType.Int32)).Value = myQuestion_Option_Template.Question_option_template_id;
                }
                if (myQuestion_Option_Template.Question_option_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_id", MySqlDbType.Int32)).Value = myQuestion_Option_Template.Question_option_id;
                }
                if (myQuestion_Option_Template.Exam_question_template_id== -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_template_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_exam_question_template_id", MySqlDbType.Int32)).Value = myQuestion_Option_Template.Exam_question_template_id;
                }
                if (myQuestion_Option_Template.Question_option_order == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_order", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_question_option_order", MySqlDbType.Int32)).Value = myQuestion_Option_Template.Question_option_order;
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

        public static bool Delete(Int32 pi_question_option_template_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_t_question_option_template", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_question_option_template_id", MySqlDbType.Int32)).Value = pi_question_option_template_id;

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

        private static Question_Option_Template FillDataRecord(IDataRecord myDataRecord)
        {
            Question_Option_Template myQuestion_Option_Template = new Question_Option_Template();

            myQuestion_Option_Template.Question_option_template_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_option_template_id"));
            myQuestion_Option_Template.Question_option_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_option_id"));
            myQuestion_Option_Template.Exam_question_template_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_question_template_id"));
            myQuestion_Option_Template.Question_option_order = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Question_option_order"));

            return myQuestion_Option_Template;
        }

    }
}