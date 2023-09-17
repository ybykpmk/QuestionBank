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
                Tbl_options.Visible = true;
                Exam_Sub_Top_Que_CountList Exam_Que_Count_list = Exam_Sub_Top_Que_CountManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                if (Exam_Que_Count_list!=null)
                {
                    upd_pnl.Visible = true;
                    ObjectDataSource1.SelectParameters.Add("pi_exam_id", Request.QueryString["pi_exam_id"]);
                    Exam MyExam = ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                    if (MyExam!=null)
                    {
                        if (MyExam.Exam_question_finished=="Y")
                        {
                            btn_view_cha_que.Visible = true;
                            btn_gen_que.Visible = false;
                        }
                        else
                        {
                            btn_view_cha_que.Visible = false;
                            btn_gen_que.Visible = true;
                        }
                    }
                    
                }
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
                        Question_DifficultyList MyQuestion_DifficultyList = Question_DifficultyManager.GetList();
                        Int32 i = 0; 
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

                        i = 0;
                        Lesson_SubjectList MyLesson_SubjectList = Lesson_SubjectManager.GetList((Session["User"] as User).Department_id, ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"])).Lesson_id);
                        if (MyLesson_SubjectList != null)
                        {
                            DDL_les_sub_name.Items.Add("All Lesson Subjects");
                            DDL_les_sub_name.Items[i].Value = null;
                            i++;
                            foreach (Lesson_Subject MyLesson_Subject in MyLesson_SubjectList)
                            {
                                DDL_les_sub_name.Items.Add(MyLesson_Subject.Lesson_subject_name);
                                DDL_les_sub_name.Items[i].Value = MyLesson_Subject.Lesson_subject_id.ToString();
                                i++;
                            }
                        }
                        else
                        {
                            Lbl_record_stat.Text = "<font color='red'>Lesson subject must be created for your action.</font>";
                        }
                        Exam MyExam=ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        Txt_exam_name.Text = MyExam.Exam_name;
                        Txt_les_name.Text = MyExam.Lesson_name;
                        if ((Request.QueryString["pi_exam_sub_top_que_count_id"] != null) & (Request.QueryString["pi_exam_sub_top_que_count_id"] != ""))
                        {
                            Exam_Sub_Top_Que_Count MyExam_Sub_Top_Que_Count = Exam_Sub_Top_Que_CountManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_sub_top_que_count_id"]));
                            DDL_les_sub_name.SelectedValue = MyExam_Sub_Top_Que_Count.Lesson_subject_id.ToString();
                            DDL_les_sub_name_SelectedIndexChanged(sender, e);
                            DDL_les_sub_top_name.SelectedValue = MyExam_Sub_Top_Que_Count.Lesson_sub_topic_id.ToString();
                            DDL_que_diff.SelectedValue = MyExam_Sub_Top_Que_Count.Question_difficulty_id.ToString();
                            DDL_que_type.SelectedValue = MyExam_Sub_Top_Que_Count.Question_type_id.ToString();
                            Txt_que_count.Text = MyExam_Sub_Top_Que_Count.Question_count.ToString();
                            btn_rec_que_count.Text = "Update Question Count";
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

    protected void btn_view_cha_que_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_cha_exam_que.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
    }

    protected void btn_gen_que_Click(object sender, EventArgs e)
    {
        Response.Redirect("gen_exam_que.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
    }

    protected void btn_rec_que_count_Click(object sender, EventArgs e)
    {
        if ((Request.QueryString["pi_exam_sub_top_que_count_id"] != null) & (Request.QueryString["pi_exam_sub_top_que_count_id"] != ""))
        {
            try
            {
                Exam_Sub_Top_Que_CountManager.Delete(Convert.ToInt32(Request.QueryString["pi_exam_sub_top_que_count_id"]));
            }
            catch (Exception exc_del)
            {
                Response.Write("<font color='red'>There has been a problem while deleting exam question count for updating. The exception message is: " + exc_del.Message + "</font>");
                return;
            }
        }
        Exam_Sub_Top_Que_Count MyExam_Sub_Top_Que_Count_cont = Exam_Sub_Top_Que_CountManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]), Convert.ToInt32(DDL_les_sub_top_name.SelectedValue), Convert.ToInt32(DDL_que_diff.SelectedValue), Convert.ToInt32(DDL_que_type.SelectedValue));
        if (MyExam_Sub_Top_Que_Count_cont == null)
        {
            Int32 que_count = QuestionManager.Get_Que_Count(Convert.ToInt32(DDL_les_sub_top_name.SelectedValue), Convert.ToInt32(DDL_que_type.SelectedValue), Convert.ToInt32(DDL_que_diff.SelectedValue));
            if (que_count >= Convert.ToInt32(Txt_que_count.Text))
            {
                Int32 rec_stat, rec_nu = -1;
                try
                {
                    Exam_Sub_Top_Que_Count MyExam_Sub_Top_Que_Count = new Exam_Sub_Top_Que_Count();
                    MyExam_Sub_Top_Que_Count.Exam_id = Convert.ToInt32(Request.QueryString["pi_exam_id"]);
                    MyExam_Sub_Top_Que_Count.Lesson_sub_topic_id = Convert.ToInt32(DDL_les_sub_top_name.SelectedValue);
                    MyExam_Sub_Top_Que_Count.Question_count = Convert.ToInt32(Txt_que_count.Text);
                    MyExam_Sub_Top_Que_Count.Question_difficulty_id = Convert.ToInt32(DDL_que_diff.SelectedValue);
                    MyExam_Sub_Top_Que_Count.Question_type_id = Convert.ToInt32(DDL_que_type.SelectedValue);
                    rec_stat = Exam_Sub_Top_Que_CountManager.Insert(MyExam_Sub_Top_Que_Count);
                    rec_nu = rec_stat;
                    
                    if (rec_stat > 0)
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
                            if ((Request.QueryString["pi_exam_sub_top_que_count_id"] != null) & (Request.QueryString["pi_exam_sub_top_que_count_id"] != ""))
                            {
                                user_log.Log_content = "User has updated new exam question count. Updated new Exam Question Count's ID is " + rec_nu;
                            }
                            else
                            {
                                user_log.Log_content = "User has recorded new exam question count. Recorded new Exam Question Count's ID is " + rec_nu;
                            }
                            LogManager.Insert(user_log);
                        }
                        catch (Exception exc1)
                        {
                            Response.Write("<font color='red'>There has been a problem while recording log which is about new exam question count. The exception message is: " + exc1.Message + "</font>");
                            return;
                        }
                    }
                }
                catch (Exception exc5)
                {
                    Response.Write("<font color='red'>There has been a problem while recording new exam question count. The exception message is: " + exc5.Message + "</font>");
                    return;
                }
                if (rec_stat > 0)
                {
                    Response.Redirect("ins_exam_que_cou.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
                    //Lbl_record_stat.Text = "<font color='navy'>Recording new exam question count has been performed.</font>";
                    //ClearFields(sender, e);
                }
                else
                {
                    Lbl_record_stat.Text = "<font color='red'>There has been a problem while recording new exam question count.</font>";
                }
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>Question count about Sub-Topic you have written is more then recorded question count (There is " + que_count +" question recorded about lesson sub-topic). Please reduce the question count about Sub-Topic and try to record again!</font>";
            }
        }
        else
        {
            Lbl_record_stat.Text = "<font color='red'>Question count about Sub-Topic you have written was recorded before. Please change the Sub-Topic or Question Difficulty and try to record again!</font>";
        }
    }

    protected void btn_rec_cancel_Click(object sender, EventArgs e)
    {
        ClearFields(sender, e);
        Lbl_record_stat.Text = "<font color='red'>Recording new question has been canceled.</font>";
    }

    protected void ClearFields(object sender, EventArgs e)
    {
        Txt_que_count.Text = "";       
        DDL_les_sub_name.SelectedIndex = 0;
        DDL_les_sub_top_name.Items.Clear();
        DDL_que_diff.SelectedIndex = 0;
        Tbl_options.Visible = false;
        upd_pnl.Visible = false;   
    }

    protected void DDL_les_sub_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDL_les_sub_name.SelectedIndex != 0)
        {
            DDL_les_sub_top_name.Items.Clear();
            Lesson_Sub_TopicList MyLesson_Sub_TopicList = Lesson_Sub_TopicManager.GetList((Session["User"] as User).Department_id, ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"])).Lesson_id, Convert.ToInt32(DDL_les_sub_name.SelectedValue));
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
        else
        {
            DDL_les_sub_top_name.Items.Clear();
            DDL_les_sub_top_name.Items.Add("");
            DDL_les_sub_top_name.Items[0].Value = null;
        }
    }
    public string Check_Delete_Question(string pi_exam_sub_top_que_count_id)
    {
        string myurl = "del_exam_que_cou.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"] + "&pi_exam_sub_top_que_count_id=" + pi_exam_sub_top_que_count_id;
        return myurl;
    }

    public string Check_Recount_Question(string pi_exam_sub_top_que_count_id)
    {
        string myurl = "ins_exam_que_cou.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"] + "&pi_exam_sub_top_que_count_id=" + pi_exam_sub_top_que_count_id;
        return myurl;
    }
}
