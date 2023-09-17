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
                if (Request.QueryString["process"]=="delete_canceled")
                {
                    Lbl_record_stat.Text = "<font color='red'>Deleting Lesson Subject has been Canceled.</font>";
                }
                else if (Request.QueryString["process"] == "lesson_subject_deleted")
                {
                    Lbl_record_stat.Text = "<font color='navy'>Lesson Subject has been Deleted.</font>";
                }
                else if (Request.QueryString["process"] == "lesson_in_exams")
                {
                    Lbl_record_stat.Text = "<font color='red'>There is (are) " + Request.QueryString["les_count"] + " exam(s) about lesson which includes this lesson subject. If you want to delete this lesson subject, you must delete exam(s) which is(are) about the lesson includes this lesson subject or delete question(s) about this lesson subject in exams.</font>";
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
    public string Check_Delete_Lesson_Subject(string pi_lesson_subject_id)
    {
        string myurl = "proc_del_les_sub.aspx?pi_lesson_subject_id=" + pi_lesson_subject_id;
        return myurl;
    }
    protected void DDL_les_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.SelectParameters.Clear();
        ObjectDataSource1.SelectParameters.Add("pi_department_id", (Session["User"] as User).Department_id.ToString());
        if (DDL_les_name.SelectedItem.Text != "All Lessons")
        {
            ObjectDataSource1.SelectParameters.Add("pi_lesson_id", DDL_les_name.SelectedValue);
        }
    }
}
