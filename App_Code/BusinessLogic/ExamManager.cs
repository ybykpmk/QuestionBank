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
    public class ExamManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static ExamList GetList(Int32 pi_lesson_id)
        {
            //şimdilik herkes seçebilir
            return ExamDB.GetList(pi_lesson_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static ExamList GetList_For_Department(Int32 pi_department_id)
        {
            //şimdilik herkes seçebilir
            return ExamDB.GetList_For_Department(pi_department_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static ExamList GetList_Pub_Exam_For_Department(Int32 pi_department_id)
        {
            //şimdilik herkes seçebilir
            return ExamDB.GetList_Pub_Exam_For_Department(pi_department_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static ExamList GetList_Pub_Exam_For_Lesson(Int32 pi_lesson_id)
        {
            //şimdilik herkes seçebilir
            return ExamDB.GetList_Pub_Exam_For_Lesson(pi_lesson_id);
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
        public static Exam GetItem(Int32 pi_exam_id)
        {
            //şimdilik herkes seçebilir
            Exam myExam = ExamDB.GetItem(pi_exam_id);
            return myExam;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Exam GetItem(string pi_exam_name)
        {
            //şimdilik herkes seçebilir
            Exam myExam = ExamDB.GetItem(pi_exam_name);
            return myExam;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Exam myExam)
        {
            Int32 rows = ExamDB.Insert(myExam);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Exam myExam)
        {
            Int32 rows = ExamDB.Update(myExam);

            return rows;
        }

        /// <summary>
        /// Deletes a Alt_kategori person from the database. 
        /// </summary> 
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Int32 pi_exam_id)
        {
            return ExamDB.Delete(pi_exam_id);
        }

 
        #endregion
    }
}