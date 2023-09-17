using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class User
    {
        #region Private Variables
        private Int32 user_id = -1;
        private string user_name = String.Empty;
        private string real_name = String.Empty;
        private Int32 rank_id = -1;
        private string rank_name = String.Empty;
        private string active = String.Empty;
        private string user_password = String.Empty;
        private string password_changed = String.Empty;
        private DateTime created_date = DateTime.MinValue;        
        private string host_ip = String.Empty;
        private Int32 department_id = -1;
        private string department_name = String.Empty;
        private string user_task = String.Empty;

        #endregion
        #region Public Properties
        public Int32 User_id { get { return user_id; } set { user_id = value; } }
        public string User_name { get { return user_name; } set { user_name = value; } }
        public string Real_name { get { return real_name; } set { real_name = value; } }
        public Int32 Rank_id { get { return rank_id; } set { rank_id = value; } }
        public string Rank_name { get { return rank_name; } set { rank_name = value; } }
        public string Active { get { return active; } set { active = value; } }
        public string User_password { get { return user_password; } set { user_password = value; } }
        public string Password_changed { get { return password_changed; } set { password_changed = value; } }
        public DateTime Created_date { get { return created_date; } set { created_date = value; } }
        public string Host_ip { get { return host_ip; } set { host_ip = value; } }
        public Int32 Department_id { get { return department_id; } set { department_id = value; } }
        public string Department_name { get { return department_name; } set { department_name = value; } }
        public string User_task { get { return user_task; } set { user_task = value; } }

        #endregion
    }
}
