using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Department
    {
        #region Private Variables
        private Int32 department_id = -1;
        private string department_name = String.Empty;


        #endregion
        #region Public Properties
        public Int32 Department_id { get { return department_id; } set { department_id = value; } }
        public string Department_name { get { return department_name; } set { department_name = value; } }

        #endregion
    }
}
