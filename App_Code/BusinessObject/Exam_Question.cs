using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Exam_Question
    {
        #region Private Variables
        private Int32 exam_question_id = -1;
        private Int32 exam_id = -1;
        private Int32 question_id = -1;
        private string question_success_rate = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Exam_question_id { get { return exam_question_id; } set { exam_question_id = value; } }
        public Int32 Exam_id { get { return exam_id; } set { exam_id = value; } }
        public Int32 Question_id { get { return question_id; } set { question_id = value; } }
        public string Question_success_rate { get { return question_success_rate; } set { question_success_rate = value; } }


        #endregion
    }
}
