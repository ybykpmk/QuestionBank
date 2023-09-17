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
            if (auth_cont == false)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if ((Request.QueryString["pi_exam_sub_top_que_count_id"] != null) & (Request.QueryString["pi_exam_sub_top_que_count_id"] != ""))
                {
                    try
                    {
                        bool rec_stat = Exam_Sub_Top_Que_CountManager.Delete(Convert.ToInt32(Request.QueryString["pi_exam_sub_top_que_count_id"]));
                        if (rec_stat)
                        {
                            try
                            {
                                Exam MyExam = ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                                MyExam.Exam_question_finished = "N";
                                ExamManager.Update(MyExam);
                            }
                            catch (Exception exc11)
                            {
                                Response.Write("<font color='red'>There has been a problem while recording exam_question_finished item which is in the t_exam table. The exception message is: " + exc11.Message + "</font>");
                                return;
                            }
                            try
                            {
                                Log user_log = new Log();
                                user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                                user_log.User_id = (Session["User"] as User).User_id;
                                user_log.Log_date = DateTime.Now;
                                user_log.Log_content = "User has deleted exam question count. Deleted Question Count of Exam's ID is " + Request.QueryString["pi_exam_sub_top_que_count_id"];
                                LogManager.Insert(user_log);
                            }
                            catch (Exception exc1)
                            {
                                Response.Write("<font color='red'>There has been a problem while recording log which is about deleting exam question count. The exception message is: " + exc1.Message + "</font>");
                                return;
                            }
                            Response.Redirect("ins_exam_que_cou.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
                        }
                    }
                    catch (Exception exc2)
                    {
                        Response.Write("<font color='red'>There has been a problem while deleting exam question count. The exception message is: " + exc2.Message + "</font>");
                        return;
                    }
                }
            }
        }
    }
}