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
                    Lbl_record_stat.Text = "<font color='red'>Updating Exam has been Canceled.</font>";
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
    public string Check_Exam(string pi_exam_id)
    {
        string myurl = "";
        Exam_TemplateList MyExam_TemplateList = Exam_TemplateManager.GetList(Convert.ToInt32(pi_exam_id));
        if (MyExam_TemplateList!=null)
        {
            myurl = "Published";
        }
        else
        {
            Exam MyExam = ExamManager.GetItem(Convert.ToInt32(pi_exam_id));
            if (MyExam!=null)
            {
                if (MyExam.Exam_question_finished=="Y")
                {
                    myurl = "<a href='proc_pub_exam.aspx?pi_exam_id=" + pi_exam_id + "'>Publish Exam</a>";
                }
                else
                {
                    myurl = "Questions aren't generated";
                }                
            }
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
