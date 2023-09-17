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
    public class Question_Option_TemplateManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Question_Option_TemplateList GetList(Int32 pi_exam_question_template_id)
        {
            //şimdilik herkes seçebilir
            return Question_Option_TemplateDB.GetList(pi_exam_question_template_id);
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
        public static Question_Option_Template GetItem(Int32 pi_question_option_template_id)
        {
            //şimdilik herkes seçebilir
            Question_Option_Template myQuestion_Option_Template = Question_Option_TemplateDB.GetItem(pi_question_option_template_id);
            return myQuestion_Option_Template;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 AskQuestion_Option_Order_In_Exam(Int32 pi_exam_id, Int32 pi_exam_group_id, Int32 pi_exam_question_id, Int32 pi_question_option_order)
        {
            //şimdilik herkes seçebilir
            Int32 rec_count = Question_Option_TemplateDB.AskQuestion_Option_Order_In_Exam(pi_exam_id, pi_exam_group_id, pi_exam_question_id, pi_question_option_order);
            return rec_count;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Question_Option_Template myQuestion_Option_Template)
        {
            Int32 rows = Question_Option_TemplateDB.Insert(myQuestion_Option_Template);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Question_Option_Template myQuestion_Option_Template)
        {
            Int32 rows = Question_Option_TemplateDB.Update(myQuestion_Option_Template);

            return rows;
        }

        /// <summary>
        /// Deletes a Alt_kategori person from the database. 
        /// </summary> 
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Int32 pi_question_option_template_id)
        {
            return Question_Option_TemplateDB.Delete(pi_question_option_template_id);
        }

 
        #endregion
    }
}