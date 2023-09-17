using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Lesson_Subject
    {
        #region Private Variables
        private Int32 lesson_subject_id = -1;
        private string lesson_subject_name = String.Empty;
        private string lesson_subject_code = String.Empty;
        private Int32 lesson_id = -1;
        private DateTime created_date = DateTime.MinValue;
        private string lesson_name = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Lesson_subject_id { get { return lesson_subject_id; } set { lesson_subject_id = value; } }
        public string Lesson_subject_name { get { return lesson_subject_name; } set { lesson_subject_name = value; } }
        public string Lesson_subject_code { get { return lesson_subject_code; } set { lesson_subject_code = value; } }
        public Int32 Lesson_id { get { return lesson_id; } set { lesson_id = value; } }
        public DateTime Created_date { get { return created_date; } set { created_date = value; } }
        public string Lesson_name { get { return lesson_name; } set { lesson_name = value; } }

        #endregion
    }
}
