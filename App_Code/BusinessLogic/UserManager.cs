using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Web.Security;
using MySql.Data.MySqlClient;

using Ybyk.QBank.BO;
using Ybyk.QBank.Dal;

namespace Ybyk.QBank.Bll
{
    /// <summary>
    /// The Alt_kategoriPersonManager class is responsible for managing BO.UrunPerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class UserManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static UserList GetList(Int32 pi_department_id)
        {
            //şimdilik herkes seçebilir
            return UserDB.GetList(pi_department_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static UserList GetList()
        {
            //şimdilik herkes seçebilir
            return UserDB.GetList();
        }
        /// <summary> 
        /// Gets a single Alt_kategoriPerson from the database without its Alt_kategori data.
        /// </summary>
        /// <param name="id">The ID of the Alt_kategori person in the database.</param> 
        /// <returns>A Alt_kategoriPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>


        /// <summary> 
        /// Gets a single Alt_kategoriPerson from the database without its Alt_kategori data.
        /// </summary>
        /// <param name="id">The ID of the Alt_kategori person in the database.</param> 
        /// <returns>A Alt_kategoriPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>
        /// 

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static User GetItem(Int32 pi_user_id)
        {
            //şimdilik herkes seçebilir
            User myUser = UserDB.GetItem(pi_user_id);
            return myUser;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static User GetItem(string pi_user_name)
        {
            //şimdilik herkes seçebilir
            User myUser = UserDB.GetItem(pi_user_name);
            return myUser;
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static User GetItem(string pi_user_name, string pi_user_password)
        {
            //şimdilik herkes seçebilir
            User myUser = UserDB.GetItem(pi_user_name, pi_user_password);
            return myUser;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(User myUser)
        {
            Int32 rows = UserDB.Insert(myUser);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(User myUser)
        {
            Int32 rows = UserDB.Update(myUser);

            return rows;
        }

        /// <summary>
        /// Deletes a Alt_kategori person from the database. 
        /// </summary> 
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 
 
        #endregion
    }
}