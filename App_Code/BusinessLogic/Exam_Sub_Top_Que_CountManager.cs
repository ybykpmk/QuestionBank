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
    public class Exam_Sub_Top_Que_CountManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Exam_Sub_Top_Que_CountList GetList(Int32 pi_exam_id)
        {
            //şimdilik herkes seçebilir
            return Exam_Sub_Top_Que_CountDB.GetList(pi_exam_id);
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
        public static Exam_Sub_Top_Que_Count GetItem(Int32 pi_exam_sub_top_que_count_id)
        {
            //şimdilik herkes seçebilir
            Exam_Sub_Top_Que_Count myExam_Sub_Top_Que_Count = Exam_Sub_Top_Que_CountDB.GetItem(pi_exam_sub_top_que_count_id);
            return myExam_Sub_Top_Que_Count;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Exam_Sub_Top_Que_Count GetItem(Int32 pi_exam_id, Int32 pi_lesson_sub_topic_id, Int32 pi_question_difficulty_id, Int32 pi_question_type_id)
        {
            //şimdilik herkes seçebilir
            Exam_Sub_Top_Que_Count myExam_Sub_Top_Que_Count = Exam_Sub_Top_Que_CountDB.GetItem(pi_exam_id, pi_lesson_sub_topic_id, pi_question_difficulty_id, pi_question_type_id);
            return myExam_Sub_Top_Que_Count;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Exam_Sub_Top_Que_Count myExam_Sub_Top_Que_Count)
        {
            Int32 rows = Exam_Sub_Top_Que_CountDB.Insert(myExam_Sub_Top_Que_Count);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Exam_Sub_Top_Que_Count myExam_Sub_Top_Que_Count)
        {
            Int32 rows = Exam_Sub_Top_Que_CountDB.Update(myExam_Sub_Top_Que_Count);

            return rows;
        }

        /// <summary>
        /// Deletes a Alt_kategori person from the database. 
        /// </summary> 
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Int32 pi_exam_sub_top_que_count_id)
        {
            return Exam_Sub_Top_Que_CountDB.Delete(pi_exam_sub_top_que_count_id);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete_All_Questions(Int32 pi_exam_id)
        {
            return Exam_Sub_Top_Que_CountDB.Delete_All_Questions(pi_exam_id);
        }
 
        #endregion
    }
}