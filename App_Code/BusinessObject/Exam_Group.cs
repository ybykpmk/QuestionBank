using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Exam_Group
    {
        #region Private Variables
        private Int32 exam_group_id = -1;
        private string exam_group_name = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Exam_group_id { get { return exam_group_id; } set { exam_group_id = value; } }
        public string Exam_group_name { get { return exam_group_name; } set { exam_group_name = value; } }

        #endregion
    }
}
