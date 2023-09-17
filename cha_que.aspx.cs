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
            if (auth_cont == true)
            {
                if (!Page.IsPostBack)
                {
                    if ((Request.QueryString["pi_cha_exam_question_id"] != null) & (Request.QueryString["pi_cha_exam_question_id"] != "") & (Request.QueryString["pi_exam_id"] != "") & (Request.QueryString["pi_exam_id"] != ""))
                    {
                        ObjectDataSource1.SelectParameters.Add("pi_exam_id", Request.QueryString["pi_exam_id"]);
                        ObjectDataSource1.SelectParameters.Add("pi_question_id", Request.QueryString["pi_cha_exam_question_id"]);
                        ObjectDataSource1.SelectParameters.Add("pi_lesson_sub_topic_id", QuestionManager.GetItem(Convert.ToInt32(Request.QueryString["pi_cha_exam_question_id"])).Lesson_sub_topic_id.ToString());
                        ObjectDataSource1.SelectParameters.Add("pi_question_type_id", QuestionManager.GetItem(Convert.ToInt32(Request.QueryString["pi_cha_exam_question_id"])).Question_type_id.ToString());
                        ObjectDataSource1.SelectParameters.Add("pi_question_difficulty_id", QuestionManager.GetItem(Convert.ToInt32(Request.QueryString["pi_cha_exam_question_id"])).Question_difficulty_id.ToString());
                        if ((Request.QueryString["process"] == "view_for_cha_que") & (Request.QueryString["pi_question_id"] != null) & (Request.QueryString["pi_question_id"] != ""))
                        {
                            Tbl_que_info.Visible = true;
                            Question MyQuestion = QuestionManager.GetItem(Convert.ToInt32(Request.QueryString["pi_question_id"]));
                            Lesson_Sub_Topic MyLesson_Sub_Topic = Lesson_Sub_TopicManager.GetItem(MyQuestion.Lesson_sub_topic_id);
                            Txt_les_name.Text = MyLesson_Sub_Topic.Lesson_name;
                            Txt_les_sub_name.Text = MyLesson_Sub_Topic.Lesson_subject_name;
                            Txt_les_sub_top_name.Text = MyLesson_Sub_Topic.Lesson_sub_topic_name;
                            txt_que_diff.Text = MyQuestion.Question_difficulty_degree;
                            txt_que_type.Text = MyQuestion.Question_type_name;
                            Txt_que.Text = MyQuestion.Question_content;
                            if ((MyQuestion.Question_photo != null) & (MyQuestion.Question_photo != ""))
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
                    }//if ((Request.QueryString["pi_question_id"] != null)                    
                }//Postback
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }        
    }

    public string Check_View_Question(string pi_question_id)
    {
        string myurl = "cha_que.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"] + "&pi_question_id=" + pi_question_id + "&pi_cha_exam_question_id=" + Request.QueryString["pi_cha_exam_question_id"] + "&process=view_for_cha_que";
        return myurl;
    }

    protected void btn_cha_que_Click(object sender, EventArgs e)
    {
        Int32 rec_stat = -1;
        try
        {
            Exam_Question MyExam_Question = Exam_QuestionManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]), Convert.ToInt32(Request.QueryString["pi_cha_exam_question_id"]));
            MyExam_Question.Question_id = Convert.ToInt32(Request.QueryString["pi_question_id"]);
            rec_stat = Exam_QuestionManager.Update(MyExam_Question);
            if (rec_stat > 0)
            {
                try
                {
                    Log user_log = new Log();
                    user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                    user_log.User_id = (Session["User"] as User).User_id;
                    user_log.Log_date = DateTime.Now;
                    user_log.Log_content = "User has changed Exam Question. Changed Exam's ID is " + Request.QueryString["pi_exam_id"] + " and old exam question's ID is " + Request.QueryString["pi_cha_exam_question_id"] + " and new exam question's ID is " + Request.QueryString["pi_question_id"];
                    LogManager.Insert(user_log);
                }
                catch (Exception exc)
                {
                    Response.Write("<font color='red'>There has been a problem while recording log which is about changing exam question. The exception message is: " + exc.Message + "</font>");
                    return;
                }                   
            }
        }
        catch (Exception exc1)
        {
            Response.Write("<font color='red'>There has been a problem while changing exam question. The exception message is: " + exc1.Message + "</font>");
            return;
        }
        if (rec_stat > 0)
        {
            Response.Redirect("view_cha_exam_que.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
        }
        else
        {
            Lbl_record_stat.Text = "<font color='red'>There has been a problem while changing exam question.</font>";
        }
    }

    protected void btn_cha_cancel_Click(object sender, EventArgs e)
    {
        Tbl_que_info.Visible = false;
    }

    protected void btn_view_que_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_cha_exam_que.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
    }
}
