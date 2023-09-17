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
                        try
                        {
                            Exam_QuestionManager.Delete_All_Question(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        }
                        catch (Exception exc_del_que)
                        {
                            Response.Write("<font color='red'>There has been a problem while recording question to t_exam_question table. The exception message is: " + exc_del_que.Message + "</font>");
                            return;
                        }
                        Exam_Sub_Top_Que_CountList MyExam_Sub_Top_Que_CountList = Exam_Sub_Top_Que_CountManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        if (MyExam_Sub_Top_Que_CountList!=null)
                        {
                            Table MyTable = new Table();
                            MyTable.ID = "Tbl_Exam";
                            MyTable.BorderStyle = BorderStyle.Ridge;
                            MyTable.Width = 930;
                            Lbl_exam_que.Controls.Add(MyTable);
                            TableRow MyTableRow = new TableRow();
                            MyTable.Controls.Add(MyTableRow);
                            TableCell MyTableCell = new TableCell();
                            MyTableCell.ColumnSpan = 3;
                            MyTableCell.HorizontalAlign = HorizontalAlign.Center;
                            MyTableRow.Controls.Add(MyTableCell);
                            Label MyLabel = new Label();
                            MyLabel.ID = "Lbl_header";
                            MyLabel.Font.Size = FontUnit.Large;
                            MyLabel.ForeColor = System.Drawing.Color.Red;
                            MyLabel.Text=ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"])).Exam_name;
                            MyTableCell.Controls.Add(MyLabel);
                            Question MyQuestion = null;
                            Exam_Question MyExam_Question = null;
                            Question_OptionList MyQuestion_OptionList = null;
                            RadioButton MyRadioButton = null;
                            Image MyImage = null;
                            Int32 que_id = -1;
                            Int32 que_seq_num = 0;
                            foreach (Exam_Sub_Top_Que_Count MyExam_Sub_Top_Que_Count in MyExam_Sub_Top_Que_CountList)
                            {
                                for (int i = 0; i < MyExam_Sub_Top_Que_Count.Question_count; i++)
                                {
                                    que_id = QuestionManager.Get_Exam_Que(MyExam_Sub_Top_Que_Count.Lesson_sub_topic_id, MyExam_Sub_Top_Que_Count.Question_type_id, MyExam_Sub_Top_Que_Count.Question_difficulty_id);
                                    MyQuestion = QuestionManager.GetItem(que_id);
                                    MyTableRow = new TableRow();
                                    MyTable.Controls.Add(MyTableRow);
                                    MyTableCell = new TableCell();
                                    MyTableCell.Width = 100;
                                    MyTableCell.VerticalAlign = VerticalAlign.Top;
                                    MyTableRow.Controls.Add(MyTableCell);
                                    MyLabel = new Label();
                                    MyLabel.Text = "<a href='cha_que.aspx?pi_cha_exam_question_id=" + que_id + "&pi_exam_id=" + Request.QueryString["pi_exam_id"] + "'>Change Question</a>";
                                    MyTableCell.Controls.Add(MyLabel);
                                    MyTableCell = new TableCell();
                                    MyTableCell.HorizontalAlign = HorizontalAlign.Center;
                                    MyTableCell.VerticalAlign = VerticalAlign.Top;
                                    MyTableCell.Width = 10;
                                    MyTableRow.Controls.Add(MyTableCell);
                                    MyLabel = new Label();
                                    MyLabel.Text = (++que_seq_num).ToString() + ".";
                                    MyTableCell.Controls.Add(MyLabel);
                                    MyTableCell = new TableCell();
                                    MyTableCell.VerticalAlign = VerticalAlign.Top;
                                    MyTableRow.Controls.Add(MyTableCell);
                                    MyLabel = new Label();
                                    if ((MyQuestion.Question_photo != null) & (MyQuestion.Question_photo != ""))
                                    {
                                        MyImage = new Image();
                                        MyImage.Height = 50;
                                        MyImage.Width = 50;
                                        MyImage.ImageUrl = MyQuestion.Question_photo;
                                        MyTableCell.Controls.Add(MyImage);
                                        MyLabel.Text = "  ";
                                    }
                                    MyLabel.Text = MyLabel.Text + MyQuestion.Question_content;
                                    MyTableCell.Controls.Add(MyLabel);
                                    if (MyQuestion.Question_type_id==1)
                                    {
                                        MyQuestion_OptionList = Question_OptionManager.GetList(que_id);
                                        foreach (Question_Option MyQuestion_Option in MyQuestion_OptionList)
                                        {
                                            MyTableRow = new TableRow();
                                            MyTable.Controls.Add(MyTableRow);
                                            MyTableCell = new TableCell();
                                            MyTableRow.Controls.Add(MyTableCell);
                                            MyLabel = new Label();
                                            MyLabel.Text = "&nbsp;";
                                            MyTableCell.Controls.Add(MyLabel);
                                            MyTableCell = new TableCell();
                                            MyTableCell.VerticalAlign = VerticalAlign.Top;
                                            MyTableRow.Controls.Add(MyTableCell);
                                            MyRadioButton = new RadioButton();
                                            MyRadioButton.Enabled = false;
                                            if (MyQuestion_Option.Question_option_true=="Y")
                                            {
                                                MyRadioButton.Checked = true;
                                            }
                                            MyTableCell.Controls.Add(MyRadioButton);
                                            MyTableCell = new TableCell();
                                            MyTableCell.VerticalAlign = VerticalAlign.Top;
                                            MyTableRow.Controls.Add(MyTableCell);
                                            if ((MyQuestion_Option.Question_option_photo != null) & (MyQuestion_Option.Question_option_photo != ""))
                                            {
                                                MyImage = new Image();
                                                MyImage.ImageUrl = MyQuestion_Option.Question_option_photo;
                                                MyImage.Height = 50;
                                                MyImage.Width = 50;
                                                MyTableCell.Controls.Add(MyImage);
                                                MyLabel.Text = "  ";
                                            }
                                            MyLabel = new Label();
                                            MyLabel.Text = MyLabel.Text + MyQuestion_Option.Question_option_content;
                                            MyTableCell.Controls.Add(MyLabel);
                                        }
                                    }
                                    try
                                    {
                                        MyExam_Question = new Exam_Question();
                                        MyExam_Question.Exam_id = Convert.ToInt32(Request.QueryString["pi_exam_id"]);
                                        MyExam_Question.Question_id = que_id;
                                        Exam_QuestionManager.Insert(MyExam_Question);
                                    }
                                    catch (Exception exc1)
                                    {
                                        Response.Write("<font color='red'>There has been a problem while recording question to t_exam_question table. The exception message is: " + exc1.Message + "</font>");
                                        return;
                                    }
                                }
                            }
                            try
                            {
                                Exam MyExam = ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                                MyExam.Exam_question_finished = "Y";
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
                                user_log.Log_content = "User has generated exam questions. Question generated Exam's ID is " + Request.QueryString["pi_exam_id"];
                                LogManager.Insert(user_log);
                            }
                            catch (Exception exc1)
                            {
                                Response.Write("<font color='red'>There has been a problem while recording log which is about generating exam questions. The exception message is: " + exc1.Message + "</font>");
                                return;
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
    }

    protected void btn_turn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("ins_exam_que_cou.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
    }
}
