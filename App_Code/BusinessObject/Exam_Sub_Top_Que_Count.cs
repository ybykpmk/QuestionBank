using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Exam_Sub_Top_Que_Count
    {
        #region Private Variables
        private Int32 exam_sub_top_que_count_id = -1;
        private Int32 exam_id = -1;
        private Int32 lesson_sub_topic_id = -1;
        private Int32 question_difficulty_id = -1;
        private Int32 question_count = -1;
        private Int32 question_type_id = -1;
        private string lesson_sub_topic_name = String.Empty;
        private string question_difficulty_degree = String.Empty;
        private Int32 lesson_subject_id = -1;
        private string lesson_subject_name = String.Empty;
        private string question_type_name = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Exam_sub_top_que_count_id { get { return exam_sub_top_que_count_id; } set { exam_sub_top_que_count_id = value; } }
        public Int32 Exam_id { get { return exam_id; } set { exam_id = value; } }
        public Int32 Lesson_sub_topic_id { get { return lesson_sub_topic_id; } set { lesson_sub_topic_id = value; } }
        public Int32 Question_difficulty_id { get { return question_difficulty_id; } set { question_difficulty_id = value; } }
        public Int32 Question_count { get { return question_count; } set { question_count = value; } }
        public Int32 Question_type_id { get { return question_type_id; } set { question_type_id = value; } }
        public string Lesson_sub_topic_name { get { return lesson_sub_topic_name; } set { lesson_sub_topic_name = value; } }
        public string Question_difficulty_degree { get { return question_difficulty_degree; } set { question_difficulty_degree = value; } }
        public Int32 Lesson_subject_id { get { return lesson_subject_id; } set { lesson_subject_id = value; } }
        public string Lesson_subject_name { get { return lesson_subject_name; } set { lesson_subject_name = value; } }
        public string Question_type_name { get { return question_type_name; } set { question_type_name = value; } }

        #endregion
    }
}
