using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Lesson
    {
        #region Private Variables
        private Int32 lesson_id = -1;
        private string lesson_name = String.Empty;
        private string lesson_code = String.Empty;
        private Int32 department_id = -1;
        private string lesson_class = String.Empty;
        private string lesson_term = String.Empty;
        private DateTime created_date = DateTime.MinValue; 

        #endregion
        #region Public Properties
        public Int32 Lesson_id { get { return lesson_id; } set { lesson_id = value; } }
        public string Lesson_name { get { return lesson_name; } set { lesson_name = value; } }
        public string Lesson_code { get { return lesson_code; } set { lesson_code = value; } }
        public Int32 Department_id { get { return department_id; } set { department_id = value; } }
        public string Lesson_class { get { return lesson_class; } set { lesson_class = value; } }
        public string Lesson_term { get { return lesson_term; } set { lesson_term = value; } }
        public DateTime Created_date { get { return created_date; } set { created_date = value; } }

        #endregion
    }
}
