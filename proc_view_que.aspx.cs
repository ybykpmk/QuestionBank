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
                    if (myuserauthority.Authority_id == 4)
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
}
