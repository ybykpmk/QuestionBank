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
                        Exam_Sub_Top_Que_CountList Exam_Que_Count_list = Exam_Sub_Top_Que_CountManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        if (Exam_Que_Count_list != null)
                        {
                            upd_pnl.Visible = true;
                            ObjectDataSource1.SelectParameters.Add("pi_exam_id", Request.QueryString["pi_exam_id"]);
                        }
                        else
                        {
                            upd_pnl.Visible = false;
                        }
                        Exam_QuestionList MyExam_QuestionList = Exam_QuestionManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        if (MyExam_QuestionList == null)
                        {
                            btn_view_que.Visible = false;
                        }
                        Exam MyExam=ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
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
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void btn_turn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("del_exam.aspx");
    }

    protected void btn_view_que_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_exam_que.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
    }

    protected void btn_del_exam_Click(object sender, EventArgs e)
    {
        Exam_TemplateList MyExam_TemplateList = Exam_TemplateManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
        if (MyExam_TemplateList==null)
        {
            bool del_stat = false;
            try
            {
                del_stat = ExamManager.Delete(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                if (del_stat == true)
                {
                    try
                    {
                        del_stat = Exam_QuestionManager.Delete_All_Question(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        if (del_stat == true)
                        {
                            try
                            {
                                del_stat = Exam_Sub_Top_Que_CountManager.Delete_All_Questions(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                                if (del_stat == true)
                                {
                                    try
                                    {
                                        Log user_log = new Log();
                                        user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                                        user_log.User_id = (Session["User"] as User).User_id;
                                        user_log.Log_date = DateTime.Now;
                                        user_log.Log_content = "User has deleted Exam. Deleted Exam's ID is " + Request.QueryString["pi_exam_id"];
                                        LogManager.Insert(user_log);
                                    }
                                    catch (Exception exc)
                                    {
                                        Response.Write("<font color='red'>There has been a problem while recording log which is about deleting exam. The exception message is: " + exc.Message + "</font>");
                                        return;
                                    }
                                }
                            }
                            catch (Exception exc)
                            {
                                Response.Write("<font color='red'>There has been a problem while deleting exam. The exception message is: " + exc.Message + "</font>");
                                return;
                            }
                        }    
                    }
                    catch (Exception exc)
                    {
                        Response.Write("<font color='red'>There has been a problem while deleting exam. The exception message is: " + exc.Message + "</font>");
                        return;
                    }
                }                
            }
            catch (Exception exc1)
            {
                Response.Write("<font color='red'>There has been a problem while deleting exam. The exception message is: " + exc1.Message + "</font>");
                return;
            }
            if (del_stat == true)
            {
                Response.Redirect("del_exam.aspx?process=exam_deleted");
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>There has been a problem while deleting exam.</font>";
            }
        }
        else
        {
            Response.Redirect("del_exam.aspx?process=exam_canc_it_has_be_pub");
        }
    }
}
