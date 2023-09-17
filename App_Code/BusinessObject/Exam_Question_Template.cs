using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Exam_Question_Template
    {
        #region Private Variables
        private Int32 exam_question_template_id = -1;
        private Int32 exam_template_id = -1;
        private Int32 exam_question_id = -1;
        private Int32 exam_question_order = -1;

        #endregion
        #region Public Properties
        public Int32 Exam_question_template_id { get { return exam_question_template_id; } set { exam_question_template_id = value; } }
        public Int32 Exam_template_id { get { return exam_template_id; } set { exam_template_id = value; } }
        public Int32 Exam_question_id { get { return exam_question_id; } set { exam_question_id = value; } }
        public Int32 Exam_question_order { get { return exam_question_order; } set { exam_question_order = value; } }


        #endregion
    }
}
