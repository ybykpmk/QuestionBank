using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Rank
    {
        #region Private Variables
        private Int32 rank_id = -1;
        private string rank_name = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Rank_id { get { return rank_id; } set { rank_id = value; } }
        public string Rank_name { get { return rank_name; } set { rank_name = value; } }
        
        #endregion
    }
}
