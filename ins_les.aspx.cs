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
        }
    }

    protected void btn_rec_les_Click(object sender, EventArgs e)
    {
        Int32 rec_stat = -1;
        Lesson control_lesson = LessonManager.GetItem(Txt_les_name.Text,(Session["User"] as User).Department_id);
        if (control_lesson == null)
        {
            try
            {
                Lesson MyLesson = new Lesson();
                MyLesson.Created_date = DateTime.Now;
                MyLesson.Department_id = (Session["User"] as User).Department_id;
                MyLesson.Lesson_class = Txt_les_class.Text;
                MyLesson.Lesson_code = Txt_les_code.Text;
                MyLesson.Lesson_name = Txt_les_name.Text;
                MyLesson.Lesson_term = Txt_les_term.Text;
                rec_stat = LessonManager.Insert(MyLesson);
                if (rec_stat > 0)
                {
                    try
                    {
                        Log user_log = new Log();
                        user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                        user_log.User_id = (Session["User"] as User).User_id;
                        user_log.Log_date = DateTime.Now;
                        user_log.Log_content = "User has recorded a new lesson. Recorded new Lesson's ID is " + rec_stat;
                        LogManager.Insert(user_log);
                    }
                    catch (Exception exc)
                    {
                        Response.Write("<font color='red'>There has been a problem while recording log which is about new lesson. The exception message is: " + exc.Message + "</font>");
                        return;
                    }
                }
            }
            catch (Exception exc1)
            {
                Response.Write("<font color='red'>There has been a problem while recording new lesson. The exception message is: " + exc1.Message + "</font>");
                return;
            }
            if (rec_stat > 0)
            {
                Lbl_record_stat.Text = "<font color='navy'>Recording new lesson has been performed.</font>";
                ClearFields(sender, e);
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>There has been a problem while recording new lesson.</font>";
            }
        }
        else
        {
            Lbl_record_stat.Text = "<font color='red'>Lesson Name you have written was recorded before. Please change the Lesson Name and try to record again!</font>";
        }
    }

    protected void btn_rec_cancel_Click(object sender, EventArgs e)
    {
        ClearFields(sender, e);
        Lbl_record_stat.Text = "<font color='red'>Recording new lesson has been canceled.</font>";
    }

    protected void ClearFields(object sender, EventArgs e)
    {
        Txt_les_class.Text = "";
        Txt_les_code.Text = "";
        Txt_les_name.Text = "";
        Txt_les_term.Text = "";
    }
}
