using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Question_Difficulty
    {
        #region Private Variables
        private Int32 question_difficulty_id = -1;
        private string question_difficulty_degree = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Question_difficulty_id { get { return question_difficulty_id; } set { question_difficulty_id = value; } }
        public string Question_difficulty_degree { get { return question_difficulty_degree; } set { question_difficulty_degree = value; } }
        
        #endregion
    }
}
