using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Authority
    {
        #region Private Variables
        private Int32 authority_id = -1;
        private string authority_name = String.Empty;


        #endregion
        #region Public Properties
        public Int32 Authority_id { get { return authority_id; } set { authority_id = value; } }
        public string Authority_name { get { return authority_name; } set { authority_name = value; } }

        #endregion
    }
}
