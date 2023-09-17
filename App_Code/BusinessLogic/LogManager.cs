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
    public class LogManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static LogList GetList()
        {
            //şimdilik herkes seçebilir
            return LogDB.GetList();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static LogList GetList(Int32 pi_user_id)
        {
            //şimdilik herkes seçebilir
            return LogDB.GetList(pi_user_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static LogList GetList(string pi_user_id, string pi_start_date, string pi_finish_date)
        {
            //şimdilik herkes seçebilir
            return LogDB.GetList(pi_user_id,pi_start_date, pi_finish_date);
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
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Log GetItem(Int32 pi_log_id)
        {
            //şimdilik herkes seçebilir
            Log myLog = LogDB.GetItem(pi_log_id);
            return myLog;
        }


        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Log myLog)
        {
            Int32 rows = LogDB.Insert(myLog);

            return rows;
        }

        #endregion
    }
}