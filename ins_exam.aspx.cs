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
            if (auth_cont == true)
            {
                if (!Page.IsPostBack)
                {
                    LessonList MyLessonList = LessonManager.GetList((Session["User"] as User).Department_id);
                    if (MyLessonList != null)
                    {
                        Int32 i = 0;
                        DDL_les_name.Items.Clear();
                        DDL_les_name.Items.Add("");
                        DDL_les_name.Items[i].Value = null;
                        i++;
                        foreach (Lesson MyLesson in MyLessonList)
                        {
                            DDL_les_name.Items.Add(MyLesson.Lesson_name);
                            DDL_les_name.Items[i].Value = MyLesson.Lesson_id.ToString();
                            i++;
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void btn_rec_exam_que_dub_top_cou_Click(object sender, EventArgs e)
    {
        Int32 rec_stat = -1;
        Exam MyExam_cont = ExamManager.GetItem(Txt_exam_name.Text);
        if (MyExam_cont == null)
        {
             try
             {
                 Exam MyExam = new Exam();
                 MyExam.Asked_year = DateTime.Now.Year.ToString();
                 MyExam.Created_date = DateTime.Now;
                 MyExam.Exam_name = Txt_exam_name.Text;
                 MyExam.Lesson_id = Convert.ToInt32(DDL_les_name.SelectedValue);
                 MyExam.User_id = (Session["User"] as User).User_id;
                 rec_stat = ExamManager.Insert(MyExam);
                 if (rec_stat > 0)
                 {
                     try
                     {
                         Log user_log = new Log();
                         user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                         user_log.User_id = (Session["User"] as User).User_id;
                         user_log.Log_date = DateTime.Now;
                         user_log.Log_content = "User has recorded a new exam. Recorded new Exam's ID is " + rec_stat;
                         LogManager.Insert(user_log);
                     }
                     catch (Exception exc1)
                     {
                         Response.Write("<font color='red'>There has been a problem while recording log which is about new exam. The exception message is: " + exc1.Message + "</font>");
                         return;
                     }
                 }
             }
             catch (Exception exc5)
             {
                 Response.Write("<font color='red'>There has been a problem while recording new exam. The exception message is: " + exc5.Message + "</font>");
                 return;
             }
             if (rec_stat > 0)
             {
                 Response.Redirect("ins_exam_que_cou.aspx?pi_exam_id=" + rec_stat);
             }
             else
             {
                 Lbl_record_stat.Text = "<font color='red'>There has been a problem while recording new exam.</font>";
             }
         }
         else
         {
             Lbl_record_stat.Text = "<font color='red'>Exam Name you have written was recorded before. Please change the Exam Name try to record again!</font>";
         }
    }

    protected void btn_rec_cancel_Click(object sender, EventArgs e)
    {
        ClearFields(sender, e);
        Lbl_record_stat.Text = "<font color='red'>Recording new exam has been canceled.</font>";
    }

    protected void ClearFields(object sender, EventArgs e)
    {
        Txt_exam_name.Text = "";
        DDL_les_name.SelectedIndex = 0;
    }
}
