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
    public class Exam_QuestionManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Exam_QuestionList GetList(Int32 pi_exam_id)
        {
            //şimdilik herkes seçebilir
            return Exam_QuestionDB.GetList(pi_exam_id);
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
        public static Exam_Question GetItem(Int32 pi_exam_question_id)
        {
            //şimdilik herkes seçebilir
            Exam_Question myExam_Question = Exam_QuestionDB.GetItem(pi_exam_question_id);
            return myExam_Question;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Exam_Question GetItem(Int32 pi_exam_id, Int32 pi_question_id)
        {
            //şimdilik herkes seçebilir
            Exam_Question myExam_Question = Exam_QuestionDB.GetItem(pi_exam_id, pi_question_id);
            return myExam_Question;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Exam_Question myExam_Question)
        {
            Int32 rows = Exam_QuestionDB.Insert(myExam_Question);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Exam_Question myExam_Question)
        {
            Int32 rows = Exam_QuestionDB.Update(myExam_Question);

            return rows;
        }

        /// <summary>
        /// Deletes a Alt_kategori person from the database. 
        /// </summary> 
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Int32 pi_exam_question_id)
        {
            return Exam_QuestionDB.Delete(pi_exam_question_id);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete_All_Question(Int32 pi_exam_id)
        {
            return Exam_QuestionDB.Delete_All_Question(pi_exam_id);
        }
 
        #endregion
    }
}