using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.QBank.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class User_Authority
    {
        #region Private Variables
        private Int32 user_authority_id = -1;
        private Int32 user_id = -1;
        private Int32 authority_id = -1;
        private string authority_name = String.Empty;

        #endregion
        #region Public Properties
        public Int32 User_authority_id { get { return user_authority_id; } set { user_authority_id = value; } }
        public Int32 User_id { get { return user_id; } set { user_id = value; } }
        public Int32 Authority_id { get { return authority_id; } set { authority_id = value; } }
        public string Authority_name { get { return authority_name; } set { authority_name = value; } }

        #endregion
    }
}
