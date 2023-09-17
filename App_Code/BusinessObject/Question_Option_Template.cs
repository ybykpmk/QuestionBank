using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Question_Option_Template
    {
        #region Private Variables
        private Int32 question_option_template_id = -1;
        private Int32 question_option_id = -1;
        private Int32 exam_question_template_id = -1;
        private Int32 question_option_order = -1;

        #endregion
        #region Public Properties
        public Int32 Question_option_template_id { get { return question_option_template_id; } set { question_option_template_id = value; } }
        public Int32 Question_option_id { get { return question_option_id; } set { question_option_id = value; } }
        public Int32 Exam_question_template_id { get { return exam_question_template_id; } set { exam_question_template_id = value; } }
        public Int32 Question_option_order { get { return question_option_order; } set { question_option_order = value; } }
                
        #endregion
    }
}
