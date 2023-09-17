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
                        Exam_TemplateList cont_Exam_TemplateList = Exam_TemplateManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        if (cont_Exam_TemplateList == null)
                        {                            
                            Exam_Template MyExam_Template = null;
                            Exam_Question_Template MyExam_Question_Template = null;
                            Question_Option_Template MyQuestion_Option_Template = null;
                            Exam_QuestionList MyExam_QuestionList = null;
                            Question MyQuestion = null;
                            Question_OptionList MyQuestion_OptionList = null;
                            Int32 cycle_count,que_order, que_order_control, opt_order, opt_order_control, rec_stat_exam_temp, rec_stat_exam_que_temp = -1;
                            Random autoRand = null;
                            bool rand_succeeded = false;
                            Exam_GroupList MyExam_GroupList = Exam_GroupManager.GetList();                            
                            if (MyExam_GroupList != null)
                            {
                                if (MyExam_GroupList.Count>3)
                                {
                                    cycle_count = 4;
                                }
                                else
                                {
                                    cycle_count = MyExam_GroupList.Count;
                                }                                
                                for (int i = 0; i < cycle_count; i++)
                                {
                                    try
                                    {
                                        MyExam_Template = new Exam_Template();
                                        MyExam_Template.Created_date = DateTime.Now;
                                        MyExam_Template.Exam_group_id = MyExam_GroupList[i].Exam_group_id;
                                        MyExam_Template.Exam_id = Convert.ToInt32(Request.QueryString["pi_exam_id"]);
                                        rec_stat_exam_temp = Exam_TemplateManager.Insert(MyExam_Template);
                                        if (rec_stat_exam_temp > 0)
                                        {
                                            MyExam_QuestionList = Exam_QuestionManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                                            if (MyExam_QuestionList != null)
                                            {
                                                foreach (Exam_Question MyExam_Question in MyExam_QuestionList)
                                                {
                                                    autoRand = new Random();
                                                    rand_succeeded = false;
                                                    do
                                                    {
                                                        que_order = autoRand.Next(1, MyExam_QuestionList.Count + 1);
                                                        que_order_control = Exam_Question_TemplateManager.AskQuestion_Order_In_Exam_Group(Convert.ToInt32(Request.QueryString["pi_exam_id"]), MyExam_GroupList[i].Exam_group_id, que_order);
                                                        if (que_order_control == 0)
                                                        {
                                                            rand_succeeded = true;
                                                        }

                                                    } while (rand_succeeded == false);
                                                    try
                                                    {
                                                        MyExam_Question_Template = new Exam_Question_Template();
                                                        MyExam_Question_Template.Exam_question_id = MyExam_Question.Exam_question_id;
                                                        MyExam_Question_Template.Exam_question_order = que_order;
                                                        MyExam_Question_Template.Exam_template_id = rec_stat_exam_temp;
                                                        rec_stat_exam_que_temp = Exam_Question_TemplateManager.Insert(MyExam_Question_Template);
                                                        MyQuestion = QuestionManager.GetItem(MyExam_Question.Question_id);
                                                        if (MyQuestion.Question_type_id == 1)
                                                        {
                                                            MyQuestion_OptionList = Question_OptionManager.GetList(MyExam_Question.Question_id);
                                                            foreach (Question_Option MyQuestion_Option in MyQuestion_OptionList)
                                                            {
                                                                rand_succeeded = false;
                                                                autoRand = new Random();
                                                                do
                                                                {
                                                                    opt_order = autoRand.Next(1, MyQuestion_OptionList.Count+1);
                                                                    opt_order_control = Question_Option_TemplateManager.AskQuestion_Option_Order_In_Exam(Convert.ToInt32(Request.QueryString["pi_exam_id"]), MyExam_GroupList[i].Exam_group_id, MyExam_Question.Exam_question_id, opt_order);
                                                                    if (opt_order_control == 0)
                                                                    {
                                                                        rand_succeeded = true;
                                                                    }

                                                                } while (rand_succeeded == false);
                                                                try
                                                                {
                                                                    MyQuestion_Option_Template = new Question_Option_Template();
                                                                    MyQuestion_Option_Template.Question_option_id = MyQuestion_Option.Question_option_id;
                                                                    MyQuestion_Option_Template.Exam_question_template_id = rec_stat_exam_que_temp;
                                                                    MyQuestion_Option_Template.Question_option_order = opt_order;
                                                                    Question_Option_TemplateManager.Insert(MyQuestion_Option_Template);
                                                                }
                                                                catch (Exception exc3)
                                                                {
                                                                    Response.Write("<font color='red'>There has been a problem while recording exam question option for exam question. The exception message is: " + exc3.Message + "</font>");
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    catch (Exception exc2)
                                                    {
                                                        Response.Write("<font color='red'>There has been a problem while recording exam question for exam group. The exception message is: " + exc2.Message + "</font>");
                                                        return;
                                                    }
                                                }
                                            }                                            
                                        }
                                    }
                                    catch (Exception exc1)
                                    {
                                        Response.Write("<font color='red'>There has been a problem while recording exam for publishing. The exception message is: " + exc1.Message + "</font>");
                                        return;
                                    }
                                }
                                try
                                {
                                    Log user_log = new Log();
                                    user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                                    user_log.User_id = (Session["User"] as User).User_id;
                                    user_log.Log_date = DateTime.Now;
                                    user_log.Log_content = "User has published exam. Published Exam's ID is " + Request.QueryString["pi_exam_id"];
                                    LogManager.Insert(user_log);
                                }
                                catch (Exception exc1)
                                {
                                    Response.Write("<font color='red'>There has been a problem while recording log which is about publishing exam. The exception message is: " + exc1.Message + "</font>");
                                    return;
                                }
                                Response.Redirect("pub_exam_book_lst.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
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
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}
