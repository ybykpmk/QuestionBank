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
    public class DepartmentDB
    {
        public DepartmentDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Department GetItem(Int32 pi_department_id)
        {
            Department myDepartment = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Department where department_id=@pi_department_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myDepartment = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myDepartment;
        }

        public static DepartmentList GetList()
        {
            DepartmentList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from T_Department", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new DepartmentList();
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

        private static Department FillDataRecord(IDataRecord myDataRecord)
        {
            Department myDepartment = new Department();
            myDepartment.Department_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Department_id"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Department_name")))
            {
                myDepartment.Department_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Department_name"));
            }

            return myDepartment;
        }

    }
}