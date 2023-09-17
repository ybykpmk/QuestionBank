using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Question_Type
    {
        #region Private Variables
        private Int32 question_type_id = -1;
        private string question_type_name = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Question_type_id { get { return question_type_id; } set { question_type_id = value; } }
        public string Question_type_name { get { return question_type_name; } set { question_type_name = value; } }
        
        #endregion
    }
}
