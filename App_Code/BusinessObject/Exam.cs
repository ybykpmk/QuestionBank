using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Exam
    {
        #region Private Variables
        private Int32 exam_id = -1;
        private string exam_name = String.Empty;
        private Int32 lesson_id = -1;
        private DateTime created_date = DateTime.MinValue;
        private Int32 user_id = -1;
        private string asked_year = String.Empty;
        private string exam_question_finished = String.Empty;
        private string lesson_name = String.Empty;
        private string user_name = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Exam_id { get { return exam_id; } set { exam_id = value; } }
        public string Exam_name { get { return exam_name; } set { exam_name = value; } }
        public Int32 Lesson_id { get { return lesson_id; } set { lesson_id = value; } }
        public DateTime Created_date { get { return created_date; } set { created_date = value; } }
        public Int32 User_id { get { return user_id; } set { user_id = value; } }
        public string Asked_year { get { return asked_year; } set { asked_year = value; } }
        public string Exam_question_finished { get { return exam_question_finished; } set { exam_question_finished = value; } }
        public string Lesson_name { get { return lesson_name; } set { lesson_name = value; } }
        public string User_name { get { return user_name; } set { user_name = value; } }

        #endregion
    }
}
