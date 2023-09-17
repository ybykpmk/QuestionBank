using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Log
    {
        #region Private Variables
        private Int32 log_id = -1;
        private string log_content = String.Empty;
        private Int32 user_id = -1;
        private DateTime log_date = DateTime.MinValue;
        private string host_ip = String.Empty;
        private string user_name = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Log_id { get { return log_id; } set { log_id = value; } }
        public string Log_content { get { return log_content; } set { log_content = value; } }
        public Int32 User_id { get { return user_id; } set { user_id = value; } }
        public DateTime Log_date { get { return log_date; } set { log_date = value; } }
        public string Host_ip { get { return host_ip; } set { host_ip = value; } }
        public string User_name { get { return user_name; } set { user_name = value; } }

        #endregion
    }
}
