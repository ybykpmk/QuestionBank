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
    public class LessonManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static LessonList GetList(Int32 pi_department_id)
        {
            //şimdilik herkes seçebilir
            return LessonDB.GetList(pi_department_id);
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
        public static Lesson GetItem(Int32 pi_lesson_id)
        {
            //şimdilik herkes seçebilir
            Lesson myLesson = LessonDB.GetItem(pi_lesson_id);
            return myLesson;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Lesson GetItem(string pi_lesson_name, Int32 pi_department_id)
        {
            //şimdilik herkes seçebilir
            Lesson myLesson = LessonDB.GetItem(pi_lesson_name,pi_department_id);
            return myLesson;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 GetLesson_Count_In_Exams(Int32 pi_lesson_id)
        {
            //şimdilik herkes seçebilir
            Int32 les_count = LessonDB.GetLesson_Count_In_Exams(pi_lesson_id);
            return les_count;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Lesson myLesson)
        {
            Int32 rows = LessonDB.Insert(myLesson);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Lesson myLesson)
        {
            Int32 rows = LessonDB.Update(myLesson);

            return rows;
        }

        /// <summary>
        /// Deletes a Alt_kategori person from the database. 
        /// </summary> 
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Int32 pi_lesson_id)
        {
            return LessonDB.Delete(pi_lesson_id);
        }

 
        #endregion
    }
}