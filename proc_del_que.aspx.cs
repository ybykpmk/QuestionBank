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
        if ((Request.QueryString["pi_question_id"] != null) & (Request.QueryString["pi_question_id"] != ""))
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
                        Question MyQuestion = QuestionManager.GetItem(Convert.ToInt32(Request.QueryString["pi_question_id"]));
                        Lesson_Sub_Topic MyLesson_Sub_Topic = Lesson_Sub_TopicManager.GetItem(MyQuestion.Lesson_sub_topic_id);
                        Txt_les_name.Text= MyLesson_Sub_Topic.Lesson_name;
                        Txt_les_sub_name.Text= MyLesson_Sub_Topic.Lesson_subject_name;
                        Txt_les_sub_top_name.Text = MyLesson_Sub_Topic.Lesson_sub_topic_name;
                        txt_que_diff.Text = MyQuestion.Question_difficulty_degree;
                        txt_que_type.Text = MyQuestion.Question_type_name;
                        Txt_que.Text = MyQuestion.Question_content;
                        if ((MyQuestion.Question_photo!=null) & (MyQuestion.Question_photo!=""))
                        {
                            Image_que.ImageUrl = MyQuestion.Question_photo;
                        }
                        if (MyQuestion.Question_type_id == 1)
                        {
                            Tbl_options.Visible = true;
                            Question_OptionList MyQuestion_OptionList = Question_OptionManager.GetList(Convert.ToInt32(Request.QueryString["pi_question_id"]));
                            if (MyQuestion_OptionList != null)
                            {
                                Image[] Image_Array = { Image_opt_a, Image_opt_b, Image_opt_c, Image_opt_d, Image_opt_e };
                                TextBox[] TextBox_Array = { Txt_opt_a, Txt_opt_b, Txt_opt_c, Txt_opt_d, Txt_opt_e };
                                RadioButton[] RadioButton_Array = { RB_ans_a, RB_ans_b, RB_ans_c, RB_ans_d, RB_ans_e };
                                Int32 i = 0;
                                foreach (Question_Option MyQuestion_Option in MyQuestion_OptionList)
                                {
                                    TextBox_Array[i].Text = MyQuestion_Option.Question_option_content;
                                    if ((MyQuestion_Option.Question_option_photo != null) & (MyQuestion_Option.Question_option_photo != ""))
                                    {
                                        Image_Array[i].ImageUrl = MyQuestion_Option.Question_option_photo;
                                    }
                                    if (MyQuestion_Option.Question_option_true == "Y")
                                    {
                                        RadioButton_Array[i].Checked = true;
                                    }
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            Tbl_options.Visible = false;
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

    protected void btn_del_que_Click(object sender, EventArgs e)
    {
        bool rec_stat = false;
        Int32 que_count_in_exams = QuestionManager.GetQuestion_Count_In_Exams(Convert.ToInt32(Request.QueryString["pi_question_id"]));
        if (que_count_in_exams > 0)
        {
            Response.Redirect("del_que.aspx?process=question_asked_in_exam&que_count=" + que_count_in_exams);
        }
        else
        {
            try
            {
                rec_stat = QuestionManager.Delete(Convert.ToInt32(Request.QueryString["pi_question_id"]));
                if (rec_stat == true)
                {
                    try
                    {
                        rec_stat = Question_OptionManager.Delete_Que_Opts(Convert.ToInt32(Request.QueryString["pi_question_id"]));
                        if (rec_stat == true)
                        {
                            try
                            {
                                Log user_log = new Log();
                                user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                                user_log.User_id = (Session["User"] as User).User_id;
                                user_log.Log_date = DateTime.Now;
                                user_log.Log_content = "User has deleted Question. Deleted question's ID is " + Request.QueryString["pi_question_id"];
                                LogManager.Insert(user_log);
                            }
                            catch (Exception exc)
                            {
                                Response.Write("<font color='red'>There has been a problem while recording log which is about deleting question. The exception message is: " + exc.Message + "</font>");
                                return;
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        Response.Write("<font color='red'>There has been a problem while deleting question options. The exception message is: " + exc.Message + "</font>");
                        return;
                    }
                }
            }
            catch (Exception exc1)
            {
                Response.Write("<font color='red'>There has been a problem while deleting question. The exception message is: " + exc1.Message + "</font>");
                return;
            }
            if (rec_stat == true)
            {
                Response.Redirect("del_que.aspx?process=question_deleted");
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>There has been a problem while deleting question.</font>";
            }
        }
    }

    protected void btn_del_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("del_que.aspx?process=delete_canceled");
    }
}
