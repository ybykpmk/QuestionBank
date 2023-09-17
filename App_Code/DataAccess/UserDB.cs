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
    public class UserDB
    {
        public UserDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static User GetItem(Int32 pi_user_id)
        {
            User myUser = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select USER_ID,USER_NAME,REAL_NAME,tu.RANK_ID,tr.rank_name,ACTIVE,USER_PASSWORD,CREATED_DATE,HOST_IP,tu.DEPARTMENT_ID,td.DEPARTMENT_name,USER_TASK,password_changed from T_user tu, t_rank tr,t_DEPARTMENT td where user_id=@pi_user_id and tu.rank_id=tr.rank_id and tu.DEPARTMENT_ID=td.DEPARTMENT_ID", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_user_id", pi_user_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myUser = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myUser;
        }

        public static User GetItem(string pi_user_name)
        {
            User myUser = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select USER_ID,USER_NAME,REAL_NAME,tu.RANK_ID,tr.rank_name,ACTIVE,USER_PASSWORD,CREATED_DATE,HOST_IP,tu.DEPARTMENT_ID,td.DEPARTMENT_name,USER_TASK,password_changed from T_user tu, t_rank tr,t_DEPARTMENT td where user_name=@pi_user_name and tu.rank_id=tr.rank_id and tu.DEPARTMENT_ID=td.DEPARTMENT_ID", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_user_name", pi_user_name);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myUser = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myUser;
        }

        public static User GetItem(string pi_user_name, string pi_user_password)
        {
            User myUser = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select USER_ID,USER_NAME,REAL_NAME,tu.RANK_ID,tr.rank_name,ACTIVE,USER_PASSWORD,CREATED_DATE,HOST_IP,tu.DEPARTMENT_ID,td.DEPARTMENT_name,USER_TASK,password_changed from T_user tu, t_rank tr,t_DEPARTMENT td where user_name=@pi_user_name and user_password=@pi_user_password and tu.rank_id=tr.rank_id and tu.DEPARTMENT_ID=td.DEPARTMENT_ID", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_user_name", pi_user_name);
                cmd.Parameters.AddWithValue("pi_user_password", pi_user_password);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myUser = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myUser;
        }

        public static UserList GetList(Int32 pi_department_id)
        {
            UserList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select USER_ID,USER_NAME,REAL_NAME,tu.RANK_ID,tr.rank_name,ACTIVE,USER_PASSWORD,CREATED_DATE,HOST_IP,tu.DEPARTMENT_ID,td.DEPARTMENT_name,USER_TASK,password_changed from T_user tu, t_rank tr,t_DEPARTMENT td where tu.department_id=@pi_department_id and tu.rank_id=tr.rank_id and tu.DEPARTMENT_ID=td.DEPARTMENT_ID", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_department_id", pi_department_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new UserList();
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

        public static UserList GetList()
        {
            UserList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select USER_ID,USER_NAME,REAL_NAME,tu.RANK_ID,tr.rank_name,ACTIVE,USER_PASSWORD,CREATED_DATE,HOST_IP,tu.DEPARTMENT_ID,td.DEPARTMENT_name,USER_TASK,password_changed from T_user tu, t_rank tr,t_DEPARTMENT td where tu.department_id=td.department_id and tu.rank_id=tr.rank_id", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new UserList();
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

        public static Int32 Insert(User myUser)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_t_user", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_user_name", MySqlDbType.VarChar)).Value = myUser.User_name;
                cmd.Parameters.Add(new MySqlParameter("pi_real_name", MySqlDbType.VarChar)).Value = myUser.Real_name;               
                cmd.Parameters.Add(new MySqlParameter("pi_active", MySqlDbType.VarChar)).Value = myUser.Active;
                cmd.Parameters.Add(new MySqlParameter("pi_user_password", MySqlDbType.VarChar)).Value = myUser.User_password;
                cmd.Parameters.Add(new MySqlParameter("pi_password_changed", MySqlDbType.VarChar)).Value = myUser.Password_changed;
                cmd.Parameters.Add(new MySqlParameter("pi_created_date", MySqlDbType.DateTime)).Value = myUser.Created_date;
                cmd.Parameters.Add(new MySqlParameter("pi_host_ip", MySqlDbType.VarChar)).Value = myUser.Host_ip;
                cmd.Parameters.Add(new MySqlParameter("pi_user_task", MySqlDbType.VarChar)).Value = myUser.User_task;


                if (myUser.Rank_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_rank_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_rank_id", MySqlDbType.Int32)).Value = myUser.Rank_id;
                }
                if (myUser.Department_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_department_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_department_id", MySqlDbType.Int32)).Value = myUser.Department_id;
                }                

                MySqlParameter myParameter = new MySqlParameter("po_user_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(User myUser)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_t_user", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myUser.User_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_user_id", MySqlDbType.Int32)).Value = myUser.User_id;
                }

                if (myUser.Rank_id== -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_rank_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_rank_id", MySqlDbType.Int32)).Value = myUser.Rank_id;
                }
                
                if (myUser.Department_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_department_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_department_id", MySqlDbType.Int32)).Value = myUser.Department_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_user_name", MySqlDbType.VarChar)).Value = myUser.User_name;
                cmd.Parameters.Add(new MySqlParameter("pi_real_name", MySqlDbType.VarChar)).Value = myUser.Real_name;
                cmd.Parameters.Add(new MySqlParameter("pi_active", MySqlDbType.VarChar)).Value = myUser.Active;
                cmd.Parameters.Add(new MySqlParameter("pi_user_password", MySqlDbType.VarChar)).Value = myUser.User_password;
                cmd.Parameters.Add(new MySqlParameter("pi_password_changed", MySqlDbType.VarChar)).Value = myUser.Password_changed;
                cmd.Parameters.Add(new MySqlParameter("pi_host_ip", MySqlDbType.VarChar)).Value = myUser.Host_ip;
                cmd.Parameters.Add(new MySqlParameter("pi_user_task", MySqlDbType.VarChar)).Value = myUser.User_task;
                

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

        private static User FillDataRecord(IDataRecord myDataRecord)
        {
            User myUser = new User();

            myUser.User_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("User_id"));
            myUser.Rank_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Rank_id"));
            myUser.Department_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Department_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("User_name")))
            {
                myUser.User_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("User_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Real_name")))
            {
                myUser.Real_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Real_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Rank_name")))
            {
                myUser.Rank_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Rank_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Active")))
            {
                myUser.Active =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Active"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("User_password")))
            {
                myUser.User_password =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("User_password"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Password_changed")))
            {
                myUser.Password_changed =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Password_changed"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Created_date")))
            {
                myUser.Created_date =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Created_date"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Host_ip")))
            {
                myUser.Host_ip =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Host_ip"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Department_name")))
            {
                myUser.Department_name =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Department_name"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("User_task")))
            {
                myUser.User_task =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("User_task"));
            }

            return myUser;
        }

    }
}