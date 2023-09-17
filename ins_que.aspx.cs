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
                    LessonList MyLessonList = LessonManager.GetList((Session["User"] as User).Department_id);
                    Int32 i = 0;
                    if (MyLessonList != null)
                    {
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

                    Question_TypeList MyQuestion_TypeList = Question_TypeManager.GetList();                    
                    i = 0;
                    DDL_que_type.Items.Clear();
                    DDL_que_type.Items.Add("");
                    DDL_que_type.Items[i].Value = null;
                    i++;
                    foreach (Question_Type MyQuestion_Type in MyQuestion_TypeList)
                    {
                        DDL_que_type.Items.Add(MyQuestion_Type.Question_type_name);
                        DDL_que_type.Items[i].Value = MyQuestion_Type.Question_type_id.ToString();
                        i++;
                    }

                    Question_DifficultyList MyQuestion_DifficultyList = Question_DifficultyManager.GetList();
                    i = 0;
                    DDL_que_diff.Items.Clear();
                    DDL_que_diff.Items.Add("");
                    DDL_que_diff.Items[i].Value = null;
                    i++;
                    foreach (Question_Difficulty MyQuestion_Difficulty in MyQuestion_DifficultyList)
                    {
                        DDL_que_diff.Items.Add(MyQuestion_Difficulty.Question_difficulty_degree);
                        DDL_que_diff.Items[i].Value = MyQuestion_Difficulty.Question_difficulty_id.ToString();
                        i++;
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void btn_rec_que_Click(object sender, EventArgs e)
    {
        RadioButton[] RadioButton_Array = { RB_ans_a, RB_ans_b, RB_ans_c, RB_ans_d, RB_ans_e };
        bool rb_checked = false;
        for (int j = 0; j < 5; j++)
        {
            if (RadioButton_Array[j].Checked)
            {
                rb_checked = true;
                break;
            }            
        }
        if ((rb_checked==true) | (Tbl_options.Visible==false))
        {
            Int32 rec_stat_que = -1;
            Int32 rec_stat_que_opt = -1;
            Int32 que_id = -1;
            Int32 que_opt_id = -1;
            try
            {
                Question MyQuestion = new Question();
                MyQuestion.Created_date = DateTime.Now;
                MyQuestion.Lesson_sub_topic_id = Convert.ToInt32(DDL_les_sub_top_name.SelectedValue);
                MyQuestion.Question_content = Txt_que.Text;
                MyQuestion.Question_difficulty_id = Convert.ToInt32(DDL_que_diff.SelectedValue);
                MyQuestion.Question_type_id = Convert.ToInt32(DDL_que_type.SelectedValue);
                MyQuestion.User_id = (Session["User"] as User).User_id;
                rec_stat_que = QuestionManager.Insert(MyQuestion);
                if (rec_stat_que > 0)
                {
                    que_id = rec_stat_que;
                    try
                    {
                        Log user_log = new Log();
                        user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                        user_log.User_id = (Session["User"] as User).User_id;
                        user_log.Log_date = DateTime.Now;
                        user_log.Log_content = "User has recorded a new question. Recorded new Question's ID is " + que_id;
                        LogManager.Insert(user_log);
                    }
                    catch (Exception exc1)
                    {
                        Response.Write("<font color='red'>There has been a problem while recording log which is about new question. The exception message is: " + exc1.Message + "</font>");
                        return;
                    }
                }
                if (FileUpl_que_photo.HasFile)
                {
                    try
                    {
                        FileUpl_que_photo.SaveAs(Server.MapPath(@"images\que_") + que_id.ToString() + FileUpl_que_photo.FileName);
                        Question Upd_Question = QuestionManager.GetItem(que_id);
                        Upd_Question.Question_photo = @"images\que_" + que_id.ToString() + FileUpl_que_photo.FileName;
                        rec_stat_que = -1;
                        rec_stat_que = QuestionManager.Update(Upd_Question);
                    }
                    catch (Exception exc2)
                    {
                        Response.Write("<font color='red'>There has been a problem while uploading new question's image. The exception message is: " + exc2.Message + "</font>");
                        return;
                    }
                }
                if (Tbl_options.Visible)
                {
                    Question_Option MyQuestion_Option = new Question_Option();
                    FileUpload[] FileUpload_Array = { File_Upl_opt_a, File_Upl_opt_b, File_Upl_opt_c, File_Upl_opt_d, File_Upl_opt_e };
                    TextBox[] TextBox_Array = { Txt_opt_a, Txt_opt_b, Txt_opt_c, Txt_opt_d, Txt_opt_e };
                    //RadioButton[] RadioButton_Array = { RB_ans_a, RB_ans_b, RB_ans_c, RB_ans_d, RB_ans_e };
                    for (int j = 0; j < 5; j++)
                    {
                        try
                        {
                            MyQuestion_Option.Question_id = que_id;
                            MyQuestion_Option.Question_option_content = TextBox_Array[j].Text;
                            if (RadioButton_Array[j].Checked)
                            {
                                MyQuestion_Option.Question_option_true = "Y";
                            }
                            else
                            {
                                MyQuestion_Option.Question_option_true = "N";
                            }
                            rec_stat_que_opt = -1;
                            rec_stat_que_opt = Question_OptionManager.Insert(MyQuestion_Option);
                            que_opt_id = rec_stat_que_opt;
                            if (rec_stat_que_opt > 0)
                            {
                                if (FileUpload_Array[j].HasFile)
                                {
                                    try
                                    {
                                        FileUpload_Array[j].SaveAs(Server.MapPath(@"images\que_opt_") + que_opt_id.ToString() + FileUpload_Array[j].FileName);
                                        Question_Option Upd_Question_Option = Question_OptionManager.GetItem(que_opt_id);
                                        Upd_Question_Option.Question_option_photo = @"images\que_opt_" + que_opt_id.ToString() + FileUpload_Array[j].FileName;
                                        rec_stat_que_opt = Question_OptionManager.Update(Upd_Question_Option);
                                    }
                                    catch (Exception exc3)
                                    {
                                        Response.Write("<font color='red'>There has been a problem while uploading new question option's image. The exception message is: " + exc3.Message + "</font>");
                                        return;
                                    }
                                }
                            }
                        }
                        catch (Exception exc4)
                        {
                            Response.Write("<font color='red'>There has been a problem while recording new question option. The exception message is: " + exc4.Message + "</font>");
                            return;
                        }
                    }
                }
            }
            catch (Exception exc5)
            {
                Response.Write("<font color='red'>There has been a problem while recording new question. The exception message is: " + exc5.Message + "</font>");
                return;
            }
            if (rec_stat_que > 0)
            {
                Lbl_record_stat.Text = "<font color='navy'>Recording new question has been performed.</font>";
                ClearFields(sender, e);
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>There has been a problem while recording new question.</font>";
            }
        }
        else
        {
            Lbl_record_stat.Text = "<font color='red'>The correct answer must be checked.</font>";
        }
    }

    protected void btn_rec_cancel_Click(object sender, EventArgs e)
    {
        ClearFields(sender, e);
        Lbl_record_stat.Text = "<font color='red'>Recording new question has been canceled.</font>";
    }

    protected void ClearFields(object sender, EventArgs e)
    {
        Txt_que.Text = "";       
        DDL_les_name.SelectedIndex = 0;
        DDL_que_diff.SelectedIndex = 0;
        DDL_que_type.SelectedIndex = 0;
        Txt_opt_a.Text = "";
        Txt_opt_b.Text = "";
        Txt_opt_c.Text = "";
        Txt_opt_d.Text = "";
        Txt_opt_e.Text = "";
        Tbl_options.Visible = false;        
        DDL_les_sub_name.Items.Clear();
        DDL_les_sub_top_name.Items.Clear();
        RadioButton[] RadioButton_Array = { RB_ans_a, RB_ans_b, RB_ans_c, RB_ans_d, RB_ans_e };
        for (int k = 0; k < 5; k++)
        {
            RadioButton_Array[k].Checked = false;
        }
    }

    protected void DDL_les_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_les_name.SelectedIndex != 0)
        {
            DDL_les_sub_name.Items.Clear();
            DDL_les_sub_top_name.Items.Clear();
            Lesson_SubjectList MyLesson_SubjectList = Lesson_SubjectManager.GetList((Session["User"] as User).Department_id, Convert.ToInt32(DDL_les_name.SelectedValue));
            Int32 i = 0;
            if (MyLesson_SubjectList != null)
            {
                foreach (Lesson_Subject MyLesson_Subject in MyLesson_SubjectList)
                {
                    DDL_les_sub_name.Items.Add(MyLesson_Subject.Lesson_subject_name);
                    DDL_les_sub_name.Items[i].Value = MyLesson_Subject.Lesson_subject_id.ToString();
                    i++;
                }
                DDL_les_sub_name_SelectedIndexChanged(sender, e);
            }
            else
            {
                DDL_les_sub_name.Items.Clear();
                DDL_les_sub_name.Items.Add("");
                DDL_les_name.Items[0].Value = null;
            }
        }
        else
        {
            DDL_les_sub_name.Items.Clear();
            DDL_les_sub_name.Items.Add("");
            DDL_les_name.Items[0].Value = null;
        }
    }
    protected void DDL_les_sub_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDL_les_sub_top_name.Items.Clear();
        Lesson_Sub_TopicList MyLesson_Sub_TopicList = Lesson_Sub_TopicManager.GetList((Session["User"] as User).Department_id, Convert.ToInt32(DDL_les_name.SelectedValue), Convert.ToInt32(DDL_les_sub_name.SelectedValue));
        Int32 i = 0;
        if (MyLesson_Sub_TopicList != null)
        {
            foreach (Lesson_Sub_Topic MyLesson_Sub_Topic in MyLesson_Sub_TopicList)
            {
                DDL_les_sub_top_name.Items.Add(MyLesson_Sub_Topic.Lesson_sub_topic_name);
                DDL_les_sub_top_name.Items[i].Value = MyLesson_Sub_Topic.Lesson_sub_topic_id.ToString();
                i++;
            }
        }
        else
        {
            DDL_les_sub_top_name.Items.Clear();
            DDL_les_sub_top_name.Items.Add("");
            DDL_les_sub_top_name.Items[0].Value = null;
        }
    }

    protected void DDL_que_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_que_type.SelectedValue=="1")
        {
            Tbl_options.Visible = true;
        }
        else if (DDL_que_type.SelectedValue == "2")
        {
            Tbl_options.Visible = false;
        }
    }
}
