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
        if ((Request.QueryString["pi_lesson_id"] != null) & (Request.QueryString["pi_lesson_id"] != ""))
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
                        Lesson MyLesson = LessonManager.GetItem(Convert.ToInt32(Request.QueryString["pi_lesson_id"]));
                        Txt_les_class.Text = MyLesson.Lesson_class;
                        Txt_les_code.Text = MyLesson.Lesson_code;
                        Txt_les_name.Text = MyLesson.Lesson_name;
                        Txt_les_term.Text = MyLesson.Lesson_term;
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

    protected void btn_upd_les_Click(object sender, EventArgs e)
    {
        Int32 rec_stat = -1;
        Lesson MyLesson = LessonManager.GetItem(Convert.ToInt32(Request.QueryString["pi_lesson_id"]));
        try
        {            
            MyLesson.Lesson_class = Txt_les_class.Text;
            MyLesson.Lesson_code = Txt_les_code.Text;
            MyLesson.Lesson_term = Txt_les_term.Text;
            rec_stat = LessonManager.Update(MyLesson);
            if (rec_stat > 0)
            {
                try
                {
                    Log user_log = new Log();
                    user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                    user_log.User_id = (Session["User"] as User).User_id;
                    user_log.Log_date = DateTime.Now;
                    user_log.Log_content = "User has updated Lesson. Updated Lesson's ID is " + Request.QueryString["pi_lesson_id"];
                    LogManager.Insert(user_log);
                }
                catch (Exception exc)
                {
                    Response.Write("<font color='red'>There has been a problem while recording log which is about updating lesson. The exception message is: " + exc.Message + "</font>");
                    return;
                }
            }
        }
        catch (Exception exc1)
        {
            Response.Write("<font color='red'>There has been a problem while updating lesson. The exception message is: " + exc1.Message + "</font>");
            return;
        }
        if (rec_stat > 0)
        {
            Response.Redirect("upd_les.aspx?process=lesson_updated");
        }
        else
        {
            Lbl_record_stat.Text = "<font color='red'>There has been a problem while updating lesson.</font>";
        }
    }

    protected void btn_upd_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("upd_les.aspx?process=update_canceled");
    }
}
