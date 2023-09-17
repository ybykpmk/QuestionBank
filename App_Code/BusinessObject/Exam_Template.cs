using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Exam_Template
    {
        #region Private Variables

        private Int32 exam_template_id = -1;
        private Int32 exam_group_id = -1;
        private Int32 exam_id = -1;
        private DateTime created_date = DateTime.MinValue;

        #endregion
        #region Public Properties
        public Int32 Exam_template_id { get { return exam_template_id; } set { exam_template_id = value; } }
        public Int32 Exam_group_id { get { return exam_group_id; } set { exam_group_id = value; } }
        public Int32 Exam_id { get { return exam_id; } set { exam_id = value; } }
        public DateTime Created_date { get { return created_date; } set { created_date = value; } }

        #endregion
    }
}
