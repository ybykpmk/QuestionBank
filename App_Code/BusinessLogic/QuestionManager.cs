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
    public class QuestionManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static QuestionList GetList(Int32 pi_lesson_sub_topic_id)
        {
            //şimdilik herkes seçebilir
            return QuestionDB.GetList(pi_lesson_sub_topic_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static QuestionList GetList_For_Another_Questions(Int32 pi_exam_id, Int32 pi_question_id, Int32 pi_lesson_sub_topic_id, Int32 pi_question_type_id, Int32 pi_question_difficulty_id)
        {
            //şimdilik herkes seçebilir
            return QuestionDB.GetList_For_Another_Questions(pi_exam_id, pi_question_id, pi_lesson_sub_topic_id, pi_question_type_id, pi_question_difficulty_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static QuestionList GetList_For_Upd_Del_Question(Int32 pi_department_id)
        {
            //şimdilik herkes seçebilir
            return QuestionDB.GetList_For_Upd_Del_Question(pi_department_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static QuestionList GetList_For_Upd_Del_Question(Int32 pi_department_id, Int32 pi_lesson_id)
        {
            //şimdilik herkes seçebilir
            return QuestionDB.GetList_For_Upd_Del_Question(pi_department_id, pi_lesson_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static QuestionList GetList_For_Upd_Del_Question(Int32 pi_department_id, Int32 pi_lesson_id, Int32 pi_lesson_subject_id)
        {
            //şimdilik herkes seçebilir
            return QuestionDB.GetList_For_Upd_Del_Question(pi_department_id,pi_lesson_id,pi_lesson_subject_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static QuestionList GetList_For_Upd_Del_Question(Int32 pi_department_id, Int32 pi_lesson_id, Int32 pi_lesson_subject_id, Int32 pi_lesson_sub_topic_id)
        {
            //şimdilik herkes seçebilir
            return QuestionDB.GetList_For_Upd_Del_Question(pi_department_id, pi_lesson_id, pi_lesson_subject_id, pi_lesson_sub_topic_id);
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
        public static Question GetItem(Int32 pi_question_id)
        {
            //şimdilik herkes seçebilir
            Question myQuestion = QuestionDB.GetItem(pi_question_id);
            return myQuestion;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 GetQuestion_Count_In_Exams(Int32 pi_question_id)
        {
            //şimdilik herkes seçebilir
            Int32 que_count = QuestionDB.GetQuestion_Count_In_Exams(pi_question_id);
            return que_count;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 Get_Que_Count(Int32 pi_lesson_sub_topic_id, Int32 pi_question_type_id, Int32 pi_question_difficulty_id)
        {
            //şimdilik herkes seçebilir
            Int32 que_count = QuestionDB.Get_Que_Count(pi_lesson_sub_topic_id, pi_question_type_id, pi_question_difficulty_id);
            return que_count;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 Get_Exam_Que(Int32 pi_lesson_sub_topic_id, Int32 pi_question_type_id, Int32 pi_question_difficulty_id)
        {
            //şimdilik herkes seçebilir
            Int32 que_count = QuestionDB.Get_Exam_Que(pi_lesson_sub_topic_id, pi_question_type_id, pi_question_difficulty_id);
            return que_count;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Question myQuestion)
        {
            Int32 rows = QuestionDB.Insert(myQuestion);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Question myQuestion)
        {
            Int32 rows = QuestionDB.Update(myQuestion);

            return rows;
        }

        /// <summary>
        /// Deletes a Alt_kategori person from the database. 
        /// </summary> 
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Int32 pi_question_id)
        {
            return QuestionDB.Delete(pi_question_id);
        }

 
        #endregion
    }
}