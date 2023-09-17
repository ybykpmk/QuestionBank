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
                if (Request.QueryString["process"]=="update_canceled")
                {
                    Lbl_record_stat.Text = "<font color='red'>Updating Lesson Sub-Topic has been Canceled.</font>";
                }
                else if (Request.QueryString["process"] == "lesson_sub_topic_updated")
                {
                    Lbl_record_stat.Text = "<font color='navy'>Lesson Sub-Topic has been Updated.</font>";
                }
                User_AuthorityList myuserauthoritylist = User_AuthorityManager.GetList((Session["User"] as User).User_id);
                bool auth_cont = false;
                foreach (User_Authority myuserauthority in myuserauthoritylist)
                {
                    if (myuserauthority.Authority_id == 2)
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
                    Int32 i = 0;
                    if (MyLessonList != null)
                    {
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
    public string Check_Update_Lesson_Sub_Topic(string pi_lesson_sub_topic_id)
    {
        string myurl = "proc_upd_les_sub_top.aspx?pi_lesson_sub_topic_id=" + pi_lesson_sub_topic_id;
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
        ObjectDataSource1.SelectParameters.Clear();
        ObjectDataSource1.SelectParameters.Add("pi_department_id", (Session["User"] as User).Department_id.ToString());
        if (DDL_les_name.SelectedItem.Text != "All Lessons")
        {
            if (DDL_les_sub_name.SelectedItem.Text != "All Lesson Subjects")
            {
                ObjectDataSource1.SelectParameters.Add("pi_lesson_id", DDL_les_name.SelectedValue);
                ObjectDataSource1.SelectParameters.Add("pi_lesson_subject_id", DDL_les_sub_name.SelectedValue);
            }
            else
            {
                ObjectDataSource1.SelectParameters.Add("pi_lesson_id", DDL_les_name.SelectedValue);
            }
        }
    }
}
