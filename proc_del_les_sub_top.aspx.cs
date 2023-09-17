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
        if ((Request.QueryString["pi_lesson_sub_topic_id"] != null) & (Request.QueryString["pi_lesson_sub_topic_id"] != ""))
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
                        Lesson_Sub_Topic MyLesson_Sub_Topic = Lesson_Sub_TopicManager.GetItem(Convert.ToInt32(Request.QueryString["pi_lesson_sub_topic_id"]));
                        Txt_les_name.Text = MyLesson_Sub_Topic.Lesson_name;
                        Txt_les_sub_name.Text = MyLesson_Sub_Topic.Lesson_subject_name;
                        Txt_les_sub_top_name.Text = MyLesson_Sub_Topic.Lesson_sub_topic_name;
                        Txt_les_sub_top_code.Text = MyLesson_Sub_Topic.Lesson_sub_topic_code;
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

    protected void btn_del_les_sub_top_Click(object sender, EventArgs e)
    {
        Int32 exam_count_about_les_sub_top = Lesson_Sub_TopicManager.GetExam_Count_About_Les_Sub_Topic(Convert.ToInt32(Request.QueryString["pi_lesson_sub_topic_id"]));
        if (exam_count_about_les_sub_top > 0)
        {
            Response.Redirect("del_les_sub_top.aspx?process=exams_about_les_sub_top&exam_count=" + exam_count_about_les_sub_top);
        }
        else
        {
            bool rec_stat = false;
            Lesson_Sub_Topic MyLesson_Subject = Lesson_Sub_TopicManager.GetItem(Convert.ToInt32(Request.QueryString["pi_lesson_sub_topic_id"]));
            try
            {
                rec_stat = Lesson_Sub_TopicManager.Delete(MyLesson_Subject.Lesson_sub_topic_id);
                if (rec_stat == true)
                {
                    try
                    {
                        Log user_log = new Log();
                        user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                        user_log.User_id = (Session["User"] as User).User_id;
                        user_log.Log_date = DateTime.Now;
                        user_log.Log_content = "User has deleted Lesson Sub-Topic. Deleted Lesson Sub-Topic's ID is " + Request.QueryString["pi_lesson_sub_topic_id"];
                        LogManager.Insert(user_log);
                    }
                    catch (Exception exc)
                    {
                        Response.Write("<font color='red'>There has been a problem while recording log which is about deleting lesson sub-topic. The exception message is: " + exc.Message + "</font>");
                        return;
                    }
                }
            }
            catch (Exception exc1)
            {
                Response.Write("<font color='red'>There has been a problem while deleting lesson sub-topic. The exception message is: " + exc1.Message + "</font>");
                return;
            }
            if (rec_stat == true)
            {
                Response.Redirect("del_les_sub_top.aspx?process=lesson_sub_topic_deleted");
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>There has been a problem while deleting lesson sub-topic.</font>";
            }
        }
    }

    protected void btn_del_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("del_les_sub_top.aspx?process=delete_canceled");
    }
}
