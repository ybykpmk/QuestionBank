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
    public class Lesson_Sub_TopicManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Lesson_Sub_TopicList GetList(Int32 pi_department_id)
        {
            //şimdilik herkes seçebilir
            return Lesson_Sub_TopicDB.GetList(pi_department_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Lesson_Sub_TopicList GetList(Int32 pi_department_id, Int32 pi_lesson_id)
        {
            //şimdilik herkes seçebilir
            return Lesson_Sub_TopicDB.GetList(pi_department_id, pi_lesson_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Lesson_Sub_TopicList GetList(Int32 pi_department_id, Int32 pi_lesson_id, Int32 pi_lesson_subject_id)
        {
            //şimdilik herkes seçebilir
            return Lesson_Sub_TopicDB.GetList(pi_department_id, pi_lesson_id, pi_lesson_subject_id);
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
        public static Lesson_Sub_Topic GetItem(Int32 pi_lesson_sub_topic_id)
        {
            //şimdilik herkes seçebilir
            Lesson_Sub_Topic myLesson_Sub_Topic = Lesson_Sub_TopicDB.GetItem(pi_lesson_sub_topic_id);
            return myLesson_Sub_Topic;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Lesson_Sub_Topic GetItem(Int32 pi_lesson_id, Int32 pi_lesson_subject_id, string pi_lesson_sub_topic_name)
        {
            //şimdilik herkes seçebilir
            Lesson_Sub_Topic myLesson_Sub_Topic = Lesson_Sub_TopicDB.GetItem(pi_lesson_id, pi_lesson_subject_id, pi_lesson_sub_topic_name);
            return myLesson_Sub_Topic;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 GetExam_Count_About_Les_Sub_Topic(Int32 pi_lesson_sub_topic_id)
        {
            //şimdilik herkes seçebilir
            Int32 exam_count = Lesson_Sub_TopicDB.GetExam_Count_About_Les_Sub_Topic(pi_lesson_sub_topic_id);
            return exam_count;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Lesson_Sub_Topic myLesson_Sub_Topic)
        {
            Int32 rows = Lesson_Sub_TopicDB.Insert(myLesson_Sub_Topic);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Lesson_Sub_Topic myLesson_Sub_Topic)
        {
            Int32 rows = Lesson_Sub_TopicDB.Update(myLesson_Sub_Topic);

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
            return Lesson_Sub_TopicDB.Delete_For_Lesson(pi_lesson_id);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete_For_Lesson_Subject(Int32 pi_lesson_subject_id)
        {
            return Lesson_Sub_TopicDB.Delete_For_Lesson_Subject(pi_lesson_subject_id);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Int32 pi_lesson_sub_topic_id)
        {
            return Lesson_Sub_TopicDB.Delete(pi_lesson_sub_topic_id);
        }

 
        #endregion
    }
}