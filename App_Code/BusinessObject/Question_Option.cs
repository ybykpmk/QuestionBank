using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Question_Option
    {
        #region Private Variables
        private Int32 question_option_id = -1;
        private string question_option_content = String.Empty;
        private string question_option_photo = String.Empty;
        private Int32 question_id = -1;
        private string question_option_true = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Question_option_id { get { return question_option_id; } set { question_option_id = value; } }
        public string Question_option_content { get { return question_option_content; } set { question_option_content = value; } }
        public string Question_option_photo { get { return question_option_photo; } set { question_option_photo = value; } }
        public Int32 Question_id { get { return question_id; } set { question_id = value; } }
        public string Question_option_true { get { return question_option_true; } set { question_option_true = value; } }
        
        #endregion
    }
}
