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
        if ((Request.QueryString["pi_exam_id"] != null) & (Request.QueryString["pi_exam_id"] != ""))
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
                        Exam MyExam = ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        Txt_exam_name.Text = MyExam.Exam_name;
                        Txt_les_name.Text = MyExam.Lesson_name;
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }

    protected void btn_upd_exam_que_dub_top_cou_Click(object sender, EventArgs e)
    {
        Int32 rec_stat = -1;
        Exam MyExam_cont = ExamManager.GetItem(Txt_exam_name.Text);
        if (MyExam_cont == null)
        {
             try
             {
                 Exam MyExam = ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                 MyExam.Exam_name = Txt_exam_name.Text;
                 MyExam.User_id = (Session["User"] as User).User_id;
                 rec_stat = ExamManager.Update(MyExam);
                 if (rec_stat > 0)
                 {
                     try
                     {
                         Log user_log = new Log();
                         user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                         user_log.User_id = (Session["User"] as User).User_id;
                         user_log.Log_date = DateTime.Now;
                         user_log.Log_content = "User has updated an exam. Updated Exam's ID is " + rec_stat;
                         LogManager.Insert(user_log);
                     }
                     catch (Exception exc1)
                     {
                         Response.Write("<font color='red'>There has been a problem while recording log which is about updating an exam. The exception message is: " + exc1.Message + "</font>");
                         return;
                     }
                 }
             }
             catch (Exception exc5)
             {
                 Response.Write("<font color='red'>There has been a problem while updating exam. The exception message is: " + exc5.Message + "</font>");
                 return;
             }
             if (rec_stat > 0)
             {
                 Response.Redirect("ins_exam_que_cou.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
             }
             else
             {
                 Lbl_record_stat.Text = "<font color='red'>There has been a problem while updating an exam.</font>";
             }
         }
         else
         {
             Lbl_record_stat.Text = "<font color='red'>Exam Name you have written was recorded before. Please change the Exam Name try to record again!</font>";
         }
    }

    protected void btn_upd_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("upd_exam.aspx?process=update_canceled");      
    }

    protected void btn_go_on_without_upd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ins_exam_que_cou.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
    }
}
