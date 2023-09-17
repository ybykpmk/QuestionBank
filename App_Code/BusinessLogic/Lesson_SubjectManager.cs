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
    public class Lesson_SubjectManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Lesson_SubjectList GetList(Int32 pi_department_id)
        {
            //şimdilik herkes seçebilir
            return Lesson_SubjectDB.GetList(pi_department_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Lesson_SubjectList GetList(Int32 pi_department_id, Int32 pi_lesson_id)
        {
            //şimdilik herkes seçebilir
            return Lesson_SubjectDB.GetList(pi_department_id, pi_lesson_id);
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
        public static Lesson_Subject GetItem(string pi_lesson_subject_name, Int32 pi_lesson_id)
        {
            //şimdilik herkes seçebilir
            Lesson_Subject myLesson_Subject = Lesson_SubjectDB.GetItem(pi_lesson_subject_name, pi_lesson_id);
            return myLesson_Subject;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Lesson_Subject GetItem(Int32 pi_lesson_subject_id)
        {
            //şimdilik herkes seçebilir
            Lesson_Subject myLesson_Subject = Lesson_SubjectDB.GetItem(pi_lesson_subject_id);
            return myLesson_Subject;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 GetLesson_Count_About_Les_Sub_In_Exams(Int32 pi_lesson_subject_id)
        {
            //şimdilik herkes seçebilir
            Int32 les_count = Lesson_SubjectDB.GetLesson_Count_About_Les_Sub_In_Exams(pi_lesson_subject_id);
            return les_count;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Lesson_Subject myLesson_Subject)
        {
            Int32 rows = Lesson_SubjectDB.Insert(myLesson_Subject);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Lesson_Subject myLesson_Subject)
        {
            Int32 rows = Lesson_SubjectDB.Update(myLesson_Subject);

            return rows;
        }

        /// <summary>
        /// Deletes a Alt_kategori person from the database. 
        /// </summary> 
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete_For_Lesson(Int32 pi_lesson_id)
        {
            return Lesson_SubjectDB.Delete_For_Lesson(pi_lesson_id);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Int32 pi_lesson_subject_id)
        {
            return Lesson_SubjectDB.Delete(pi_lesson_subject_id);
        }

 
        #endregion
    }
}