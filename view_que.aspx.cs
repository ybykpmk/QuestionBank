using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ybyk.QBank.Bll;
using Ybyk.QBank.BO;
using Ybyk.QBank.Dal;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            if (!Page.IsPostBack)
            {                
                User_AuthorityList myuserauthoritylist = User_AuthorityManager.GetList((Session["User"] as User).User_id);
                bool auth_cont = false;
                foreach (User_Authority myuserauthority in myuserauthoritylist)
                {
                    if (myuserauthority.Authority_id == 4)
                    {
                        auth_cont = true;
                        break;
                    }
                }
                if (auth_cont == false)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    LessonList MyLessonList = LessonManager.GetList((Session["User"] as User).Department_id);
                    if (MyLessonList != null)
                    {
                        Int32 i = 0;
                        DDL_les_name.Items.Clear();
                        DDL_les_name.Items.Add("All Lessons");
                        DDL_les_name.Items[i].Value = null;
                        i++;
                        foreach (Lesson MyLesson in MyLessonList)
                        {
                            DDL_les_name.Items.Add(MyLesson.Lesson_name);
                            DDL_les_name.Items[i].Value = MyLesson.Lesson_id.ToString();
                            i++;
                        }
                    }
                    ObjectDataSource1.SelectParameters.Add("pi_department_id", (Session["User"] as User).Department_id.ToString());
                }
            }
        }
    }
    public string Check_View_Question(string pi_question_id)
    {
        string myurl = "proc_view_que.aspx?pi_question_id=" + pi_question_id;
        return myurl;
    }
    protected void DDL_les_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_les_name.SelectedIndex != 0)
        {
            Lesson_SubjectList MyLesson_SubjectList = Lesson_SubjectManager.GetList((Session["User"] as User).Department_id, Convert.ToInt32(DDL_les_name.SelectedValue));
            Int32 i = 0;
            DDL_les_sub_name.Items.Clear();
            DDL_les_sub_name.Items.Add("All Lesson Subjects");
            DDL_les_sub_name.Items[i].Value = null;
            i++;
            if (MyLesson_SubjectList != null)
            {
                foreach (Lesson_Subject MyLesson_Subject in MyLesson_SubjectList)
                {
                    DDL_les_sub_name.Items.Add(MyLesson_Subject.Lesson_subject_name);
                    DDL_les_sub_name.Items[i].Value = MyLesson_Subject.Lesson_subject_id.ToString();
                    i++;
                }
            }
            else
            {
                DDL_les_sub_name.Items.Clear();
                DDL_les_sub_name.Items.Add("");
                DDL_les_name.Items[0].Value = null;
            }
        }
        else
        {
            DDL_les_sub_name.Items.Clear();
            DDL_les_sub_name.Items.Add("");
            DDL_les_name.Items[0].Value = null;
        }
        DDL_les_sub_name_SelectedIndexChanged(sender, e);
    }

    protected void DDL_les_sub_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_les_sub_name.SelectedIndex != 0)
        {
            Lesson_Sub_TopicList MyLesson_Sub_TopicList = Lesson_Sub_TopicManager.GetList((Session["User"] as User).Department_id, Convert.ToInt32(DDL_les_name.SelectedValue), Convert.ToInt32(DDL_les_sub_name.SelectedValue));
            Int32 i = 0;
            DDL_les_sub_top_name.Items.Clear();
            DDL_les_sub_top_name.Items.Add("All Lesson Sub-Topics");
            DDL_les_sub_top_name.Items[i].Value = null;
            i++;
            if (MyLesson_Sub_TopicList != null)
            {
                foreach (Lesson_Sub_Topic MyLesson_Sub_Topic in MyLesson_Sub_TopicList)
                {
                    DDL_les_sub_top_name.Items.Add(MyLesson_Sub_Topic.Lesson_sub_topic_name);
                    DDL_les_sub_top_name.Items[i].Value = MyLesson_Sub_Topic.Lesson_sub_topic_id.ToString();
                    i++;
                }
            }
            else
            {
                DDL_les_sub_top_name.Items.Clear();
                DDL_les_sub_top_name.Items.Add("");
                DDL_les_sub_top_name.Items[0].Value = null;
            }
        }
        else
        {
            DDL_les_sub_top_name.Items.Clear();
            DDL_les_sub_top_name.Items.Add("");
            DDL_les_sub_top_name.Items[0].Value = null;
        }
        DDL_les_sub_top_name_SelectedIndexChanged(sender, e);
    }

    protected void DDL_les_sub_top_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.SelectParameters.Clear();
        ObjectDataSource1.SelectParameters.Add("pi_department_id", (Session["User"] as User).Department_id.ToString());
        if (DDL_les_name.SelectedItem.Text != "All Lessons")
        {
            ObjectDataSource1.SelectParameters.Add("pi_lesson_id", DDL_les_name.SelectedValue);
            if (DDL_les_sub_name.SelectedItem.Text != "All Lesson Subjects")
            {
                ObjectDataSource1.SelectParameters.Add("pi_lesson_subject_id", DDL_les_sub_name.SelectedValue);
                if (DDL_les_sub_top_name.SelectedItem.Text != "All Lesson Sub-Topics")
                {
                    ObjectDataSource1.SelectParameters.Add("pi_lesson_sub_topic_id", DDL_les_sub_top_name.SelectedValue);
                }
            }
        }
    }
}
