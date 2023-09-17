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

    protected void btn_del_les_Click(object sender, EventArgs e)
    {
        Int32 les_count_in_exams = LessonManager.GetLesson_Count_In_Exams(Convert.ToInt32(Request.QueryString["pi_lesson_id"]));
        if (les_count_in_exams > 0)
        {
            Response.Redirect("del_les.aspx?process=lesson_in_exams&les_count=" + les_count_in_exams);
        }
        else
        {
            bool rec_stat = false;
            Lesson MyLesson = LessonManager.GetItem(Convert.ToInt32(Request.QueryString["pi_lesson_id"]));
            try
            {
                rec_stat = Lesson_Sub_TopicManager.Delete_For_Lesson(MyLesson.Lesson_id);
                if (rec_stat == true)
                {
                    try
                    {
                        rec_stat = Lesson_SubjectManager.Delete_For_Lesson(MyLesson.Lesson_id);
                        if (rec_stat == true)
                        {
                            try
                            {
                                rec_stat = LessonManager.Delete(MyLesson.Lesson_id);
                                if (rec_stat == true)
                                {
                                    try
                                    {
                                        Log user_log = new Log();
                                        user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                                        user_log.User_id = (Session["User"] as User).User_id;
                                        user_log.Log_date = DateTime.Now;
                                        user_log.Log_content = "User has deleted Lesson. Deleted Lesson's ID is " + Request.QueryString["pi_lesson_id"];
                                        LogManager.Insert(user_log);
                                    }
                                    catch (Exception exc)
                                    {
                                        Response.Write("<font color='red'>There has been a problem while recording log which is about deleting lesson. The exception message is: " + exc.Message + "</font>");
                                        return;
                                    }
                                }
                            }
                            catch (Exception exc1)
                            {
                                Response.Write("<font color='red'>There has been a problem while deleting lesson. The exception message is: " + exc1.Message + "</font>");
                                return;
                            }
                        }
                    }
                    catch (Exception exc2)
                    {
                        Response.Write("<font color='red'>There has been a problem while deleting lesson subjects related to lesson. The exception message is: " + exc2.Message + "</font>");
                        return;
                    }
                }
            }
            catch (Exception exc3)
            {
                Response.Write("<font color='red'>There has been a problem while deleting lesson sub_topics related to lesson subject that is related to lesson. The exception message is: " + exc3.Message + "</font>");
                return;
            }
            if (rec_stat == true)
            {
                Response.Redirect("del_les.aspx?process=lesson_deleted");
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>There has been a problem while deleting lesson.</font>";
            }
        }
    }

    protected void btn_del_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("del_les.aspx?process=delete_canceled");
    }
}
