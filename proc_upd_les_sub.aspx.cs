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
        if ((Request.QueryString["pi_lesson_subject_id"] != null) & (Request.QueryString["pi_lesson_subject_id"] != ""))
        {
            if (Session["User"] != null)
            {
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
                if (auth_cont == true)
                {
                    if (!Page.IsPostBack)
                    {
                        Lesson_Subject MyLesson_Subject = Lesson_SubjectManager.GetItem(Convert.ToInt32(Request.QueryString["pi_lesson_subject_id"]));
                        Txt_les_name.Text = MyLesson_Subject.Lesson_name;
                        Txt_les_sub_name.Text = MyLesson_Subject.Lesson_subject_name;
                        Txt_les_sub_code.Text = MyLesson_Subject.Lesson_subject_code;
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }            
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void btn_upd_les_sub_Click(object sender, EventArgs e)
    {
        Int32 rec_stat = -1;
        Lesson_Subject MyLesson_Subject = Lesson_SubjectManager.GetItem(Convert.ToInt32(Request.QueryString["pi_lesson_subject_id"]));
        try
        {            
            MyLesson_Subject.Lesson_subject_code= Txt_les_sub_code.Text;
            rec_stat = Lesson_SubjectManager.Update(MyLesson_Subject);
            if (rec_stat > 0)
            {
                try
                {
                    Log user_log = new Log();
                    user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                    user_log.User_id = (Session["User"] as User).User_id;
                    user_log.Log_date = DateTime.Now;
                    user_log.Log_content = "User has updated Lesson Subject. Updated Lesson Subject's ID is " + Request.QueryString["pi_lesson_subject_id"];
                    LogManager.Insert(user_log);
                }
                catch (Exception exc)
                {
                    Response.Write("<font color='red'>There has been a problem while recording log which is about updating lesson subject. The exception message is: " + exc.Message + "</font>");
                    return;
                }
            }
        }
        catch (Exception exc1)
        {
            Response.Write("<font color='red'>There has been a problem while updating lesson subject. The exception message is: " + exc1.Message + "</font>");
            return;
        }
        if (rec_stat > 0)
        {
            Response.Redirect("upd_les_sub.aspx?process=lesson_subject_updated");
        }
        else
        {
            Lbl_record_stat.Text = "<font color='red'>There has been a problem while updating lesson subject.</font>";
        }
    }

    protected void btn_upd_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("upd_les_sub.aspx?process=update_canceled");
    }
}
