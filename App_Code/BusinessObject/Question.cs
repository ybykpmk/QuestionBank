using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Question
    {
        #region Private Variables
        private Int32 question_id = -1;
        private string question_content = String.Empty;
        private string question_photo = String.Empty;
        private Int32 question_type_id = -1;
        private Int32 lesson_sub_topic_id = -1;
        private DateTime created_date = DateTime.MinValue;
        private Int32 user_id = -1;
        private Int32 question_difficulty_id = -1;
        private string question_type_name = String.Empty;
        private string question_difficulty_degree = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Question_id { get { return question_id; } set { question_id = value; } }
        public string Question_content { get { return question_content; } set { question_content = value; } }
        public string Question_photo { get { return question_photo; } set { question_photo = value; } }
        public Int32 Question_type_id { get { return question_type_id; } set { question_type_id = value; } }
        public Int32 Lesson_sub_topic_id { get { return lesson_sub_topic_id; } set { lesson_sub_topic_id = value; } }
        public DateTime Created_date { get { return created_date; } set { created_date = value; } }
        public Int32 User_id { get { return user_id; } set { user_id = value; } }
        public Int32 Question_difficulty_id { get { return question_difficulty_id; } set { question_difficulty_id = value; } }
        public string Question_type_name { get { return question_type_name; } set { question_type_name = value; } }
        public string Question_difficulty_degree { get { return question_difficulty_degree; } set { question_difficulty_degree = value; } }

        #endregion
    }
}
