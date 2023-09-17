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
                        Exam_TemplateList MyExam_TemplateList = Exam_TemplateManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        Exam_Question_TemplateList MyExam_Question_TemplateList = null;
                        Question_Option_TemplateList MyQuestion_Option_TemplateList = null;
                        if (MyExam_TemplateList!=null)
                        {
                            foreach (Exam_Template MyExam_Template in MyExam_TemplateList)
                            {
                                try
                                {
                                    MyExam_Question_TemplateList = Exam_Question_TemplateManager.GetList(MyExam_Template.Exam_template_id);
                                    foreach (Exam_Question_Template MyExam_Question_Template in MyExam_Question_TemplateList)
                                    {
                                        try
                                        {
                                            MyQuestion_Option_TemplateList = Question_Option_TemplateManager.GetList(MyExam_Question_Template.Exam_question_template_id);
                                            if (MyQuestion_Option_TemplateList != null)
                                            {
                                                foreach (Question_Option_Template MyQuestion_Option_Template in MyQuestion_Option_TemplateList)
                                                {
                                                    try
                                                    {
                                                        Question_Option_TemplateManager.Delete(MyQuestion_Option_Template.Question_option_template_id);
                                                    }
                                                    catch (Exception exc1)
                                                    {
                                                        Response.Write("<font color='red'>There has been a problem while canceling published exam question options. The exception message is: " + exc1.Message + "</font>");
                                                        return;
                                                    }
                                                }
                                            }
                                            Exam_Question_TemplateManager.Delete(MyExam_Question_Template.Exam_question_template_id);
                                        }
                                        catch (Exception exc2)
                                        {
                                            Response.Write("<font color='red'>There has been a problem while canceling published exam questions. The exception message is: " + exc2.Message + "</font>");
                                            return;
                                        }
                                    }
                                    Exam_TemplateManager.Delete(MyExam_Template.Exam_template_id);
                                }
                                catch (Exception exc3)
                                {
                                    Response.Write("<font color='red'>There has been a problem while canceling published exams. The exception message is: " + exc3.Message + "</font>");
                                    return;
                                }
                            }
                            try
                            {
                                Log user_log = new Log();
                                user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                                user_log.User_id = (Session["User"] as User).User_id;
                                user_log.Log_date = DateTime.Now;
                                user_log.Log_content = "User has canceled publishing exam. Publishing Canceled Exam's ID is " + Request.QueryString["pi_exam_id"];
                                LogManager.Insert(user_log);
                            }
                            catch (Exception exc1)
                            {
                                Response.Write("<font color='red'>There has been a problem while recording log which is about updating question. The exception message is: " + exc1.Message + "</font>");
                                return;
                            }
                            Response.Redirect("view_pub_exam.aspx?process=canceled_publishing_exam");
                        }
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}
