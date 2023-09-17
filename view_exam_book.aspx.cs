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
        if ((Request.QueryString["pi_exam_template_id"] != null) & (Request.QueryString["pi_exam_template_id"] != ""))
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
                        Exam_Question_TemplateList MyExam_Question_TemplateList = Exam_Question_TemplateManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_template_id"]));
                        if (MyExam_Question_TemplateList != null)
                        {
                            Table MyTable = new Table();
                            MyTable.ID = "Tbl_Exam";                            
                            MyTable.Width = 620;
                            Lbl_exam_que.Controls.Add(MyTable);
                            TableRow MyTableRow = new TableRow();
                            MyTable.Controls.Add(MyTableRow);
                            TableCell MyTableCell = new TableCell();
                            MyTableCell.ColumnSpan = 2;
                            MyTableCell.HorizontalAlign = HorizontalAlign.Center;
                            MyTableRow.Controls.Add(MyTableCell);
                            Label MyLabel = new Label();
                            MyLabel.ID = "Lbl_header";
                            MyLabel.Font.Size = FontUnit.Large;
                            MyLabel.ForeColor = System.Drawing.Color.Red;
                            MyLabel.Text = ExamManager.GetItem(Exam_TemplateManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_template_id"])).Exam_id).Exam_name + "<br><br>";
                            MyTableCell.Controls.Add(MyLabel);
                            string[] order_letter_array = { "a", "b", "c", "d", "e" };
                            Int32 array_index = 0;
                            Image MyImage = null;
                            Question_Option_TemplateList MyQuestion_Option_TemplateList = null;
                            foreach (Exam_Question_Template MyExam_Question_Template in MyExam_Question_TemplateList)
                            {                                
                                MyTableRow = new TableRow();
                                MyTable.Controls.Add(MyTableRow);                                                                                              
                                
                                MyTableCell = new TableCell();
                                MyTableCell.VerticalAlign = VerticalAlign.Top;
                                MyTableCell.HorizontalAlign = HorizontalAlign.Right;
                                MyTableRow.Controls.Add(MyTableCell);
                                MyLabel = new Label();
                                MyLabel.Attributes.Add("dir", "rtl");
                                MyLabel.Text = QuestionManager.GetItem(Exam_QuestionManager.GetItem(MyExam_Question_Template.Exam_question_id).Question_id).Question_content+ "  ";
                                MyTableCell.Controls.Add(MyLabel);
                                if ((QuestionManager.GetItem(Exam_QuestionManager.GetItem(MyExam_Question_Template.Exam_question_id).Question_id).Question_photo != null) & (QuestionManager.GetItem(Exam_QuestionManager.GetItem(MyExam_Question_Template.Exam_question_id).Question_id).Question_photo != ""))
                                {
                                    MyImage = new Image();
                                    MyImage.Height = 50;
                                    MyImage.Width = 50;
                                    MyImage.ImageUrl = QuestionManager.GetItem(Exam_QuestionManager.GetItem(MyExam_Question_Template.Exam_question_id).Question_id).Question_photo;
                                    MyTableCell.Controls.Add(MyImage);
                                }                                

                                MyTableCell = new TableCell();
                                MyTableCell.HorizontalAlign = HorizontalAlign.Center;
                                MyTableCell.VerticalAlign = VerticalAlign.Top;
                                MyTableCell.Width = 10;
                                MyTableRow.Controls.Add(MyTableCell);
                                MyLabel = new Label();
                                MyLabel.Text = "." + MyExam_Question_Template.Exam_question_order.ToString();
                                MyTableCell.Controls.Add(MyLabel);
                                if (QuestionManager.GetItem(Exam_QuestionManager.GetItem(MyExam_Question_Template.Exam_question_id).Question_id).Question_type_id == 1)
                                {
                                    MyQuestion_Option_TemplateList = Question_Option_TemplateManager.GetList(MyExam_Question_Template.Exam_question_template_id);
                                    array_index = 0;
                                    foreach (Question_Option_Template MyQuestion_Option_Template in MyQuestion_Option_TemplateList)
                                    {
                                        MyTableRow = new TableRow();
                                        MyTable.Controls.Add(MyTableRow);
                                                                                
                                        MyTableCell = new TableCell();
                                        MyTableCell.VerticalAlign = VerticalAlign.Top;
                                        MyTableRow.Controls.Add(MyTableCell);
                                        MyLabel = new Label();
                                        MyLabel.Attributes.Add("dir", "rtl");
                                        MyLabel.Text = Question_OptionManager.GetItem(MyQuestion_Option_Template.Question_option_id).Question_option_content + "  ";
                                        MyTableCell.Controls.Add(MyLabel);
                                        if ((Question_OptionManager.GetItem(MyQuestion_Option_Template.Question_option_id).Question_option_photo != null) & (Question_OptionManager.GetItem(MyQuestion_Option_Template.Question_option_id).Question_option_photo != ""))
                                        {
                                            MyImage = new Image();
                                            MyImage.ImageUrl = Question_OptionManager.GetItem(MyQuestion_Option_Template.Question_option_id).Question_option_photo;
                                            MyImage.Height = 50;
                                            MyImage.Width = 50;
                                            MyTableCell.Controls.Add(MyImage);
                                        }

                                        MyTableCell = new TableCell();
                                        MyTableCell.HorizontalAlign = HorizontalAlign.Center;
                                        MyTableCell.VerticalAlign = VerticalAlign.Top;
                                        MyTableCell.Width = 10;
                                        MyTableRow.Controls.Add(MyTableCell);
                                        MyLabel = new Label();
                                        MyLabel.Text = "." + order_letter_array[array_index++];
                                        MyTableCell.Controls.Add(MyLabel);                                        
                                    }
                                }
                                else
                                {
                                    MyLabel.Text = MyLabel.Text + "<br><br><br><br><br><br><br><br><br><br>";
                                }
                            }                           
                        }
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.ClearHeaders();
                        HttpContext.Current.Response.ClearContent();
                        HttpContext.Current.Response.ContentEncoding = System.Text.UnicodeEncoding.UTF8;
                        HttpContext.Current.Response.Charset = "UTF-8";
                        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Output.doc");
                        HttpContext.Current.Response.ContentType = "application/msword";
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
