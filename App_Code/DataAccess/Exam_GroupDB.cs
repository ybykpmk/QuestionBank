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
    public class Exam_GroupDB
    {
        public Exam_GroupDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Exam_Group GetItem(Int32 pi_exam_group_id)
        {
            Exam_Group myExam_Group = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Exam_group where exam_group_id=@pi_exam_group_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_exam_group_id", pi_exam_group_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myExam_Group = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myExam_Group;
        }

        public static Exam_GroupList GetList()
        {
            Exam_GroupList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Exam_group", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Exam_GroupList();
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

        private static Exam_Group FillDataRecord(IDataRecord myDataRecord)
        {
            Exam_Group myExam_Group = new Exam_Group();

            myExam_Group.Exam_group_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Exam_group_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Exam_group_name")))
            {
                myExam_Group.Exam_group_name=
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Exam_group_name"));
            }

            return myExam_Group;
        }

    }
}