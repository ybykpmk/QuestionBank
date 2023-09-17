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
                if (Request.QueryString["process"] == "exam_deleted")
                {
                    Lbl_record_stat.Text = "<font color='red'>Exam has been Deleted.</font>";
                }
                else if (Request.QueryString["process"] == "exam_canc_it_has_be_pub")
                {
                    Lbl_record_stat.Text = "<font color='red'>Exam has been published before. So Deleting process has been Canceled.</font>";
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
    public string Check_Delete_Exam(string pi_exam_id)
    {
        string myurl = "";
        Exam_TemplateList MyExam_TemplateList = Exam_TemplateManager.GetList(Convert.ToInt32(pi_exam_id));
        if (MyExam_TemplateList != null)
        {
            myurl = "Published";
        }
        else
        {
            myurl = "<a href='proc_del_exam.aspx?pi_exam_id=" + pi_exam_id + "'>Delete Exam</a>";
        }        
        return myurl;
    }
    protected void DDL_les_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjectDataSource1.SelectParameters.Clear();
        if (DDL_les_name.SelectedItem.Text != "All Lessons")
        {
            ObjectDataSource1.SelectMethod = "GetList";
            ObjectDataSource1.SelectParameters.Add("pi_lesson_id", DDL_les_name.SelectedValue);
        }
        else
        {
            ObjectDataSource1.SelectMethod = "GetList_For_Department";
            ObjectDataSource1.SelectParameters.Add("pi_department_id", (Session["User"] as User).Department_id.ToString());
        }
    }
}
