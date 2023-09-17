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

    protected void btn_rec_les_sub_Click(object sender, EventArgs e)
    {
        Int32 rec_stat = -1;
        Lesson_Subject control_lesson_subject = Lesson_SubjectManager.GetItem(Txt_les_sub_name.Text, Convert.ToInt32(DDL_les_name.SelectedValue));
        if (control_lesson_subject == null)
        {
            try
            {
                Lesson_Subject MyLesson_Subject = new Lesson_Subject();
                MyLesson_Subject.Created_date = DateTime.Now;
                MyLesson_Subject.Lesson_id = Convert.ToInt32(DDL_les_name.SelectedValue);
                MyLesson_Subject.Lesson_subject_code= Txt_les_sub_code.Text;
                MyLesson_Subject.Lesson_subject_name= Txt_les_sub_name.Text;
                rec_stat = Lesson_SubjectManager.Insert(MyLesson_Subject);
                if (rec_stat > 0)
                {
                    try
                    {
                        Log user_log = new Log();
                        user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                        user_log.User_id = (Session["User"] as User).User_id;
                        user_log.Log_date = DateTime.Now;
                        user_log.Log_content = "User has recorded a new lesson subject. Recorded new Lesson subject's ID is " + rec_stat;
                        LogManager.Insert(user_log);
                    }
                    catch (Exception exc)
                    {
                        Response.Write("<font color='red'>There has been a problem while recording log which is about new lesson subject. The exception message is: " + exc.Message + "</font>");
                        return;
                    }
                }
            }
            catch (Exception exc1)
            {
                Response.Write("<font color='red'>There has been a problem while recording new lesson subject. The exception message is: " + exc1.Message + "</font>");
                return;
            }
            if (rec_stat > 0)
            {
                Lbl_record_stat.Text = "<font color='navy'>Recording new lesson subject has been performed.</font>";
                ClearFields(sender, e);
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>There has been a problem while recording new lesson subject.</font>";
            }
        }
        else
        {
            Lbl_record_stat.Text = "<font color='red'>Lesson Subject Name you have written was recorded before. Please change the Lesson Subject Name and try to record again!</font>";
        }
    }

    protected void btn_rec_cancel_Click(object sender, EventArgs e)
    {
        ClearFields(sender, e);
        Lbl_record_stat.Text = "<font color='red'>Recording new lesson subject has been canceled.</font>";
    }

    protected void ClearFields(object sender, EventArgs e)
    {
        Txt_les_sub_code.Text = "";
        Txt_les_sub_name.Text = "";
        DDL_les_name.SelectedIndex = 0;
    }
}
