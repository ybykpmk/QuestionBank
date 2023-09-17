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
                if (Request.QueryString["process"] == "canceled_publishing_exam")
                {
                    Lbl_record_stat.Text = "<font color='red'>Exam has been Canceled to be published.</font>";
                }
                User_AuthorityList myuserauthoritylist = User_AuthorityManager.GetList((Session["User"] as User).User_id);
                bool auth_cont = false;
                foreach (User_Authority myuserauthority in myuserauthoritylist)
                {
                    if (myuserauthority.Authority_id == 3)
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
    public string Check_Pub_Exam(string pi_exam_id)
    {
        string myurl = "";
        myurl = "<a href='pub_exam_book_lst.aspx?pi_exam_id=" + pi_exam_id + "'>View Published Exam</a>";
        myurl = myurl + "&nbsp;&nbsp;<a onclick='return Cancel_pub_exam();' href='canc_pub_exam.aspx?pi_exam_id=" + pi_exam_id + "'>Cancel Publishing Exam</a>";
        return myurl;
    }
    protected void DDL_les_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.SelectParameters.Clear();
        if (DDL_les_name.SelectedItem.Text != "All Lessons")
        {
            ObjectDataSource1.SelectMethod = "GetList_Pub_Exam_For_Lesson";
            ObjectDataSource1.SelectParameters.Add("pi_lesson_id", DDL_les_name.SelectedValue);
        }
        else
        {
            ObjectDataSource1.SelectMethod = "GetList_Pub_Exam_For_Department";
            ObjectDataSource1.SelectParameters.Add("pi_department_id", (Session["User"] as User).Department_id.ToString());
        }
    }
}
