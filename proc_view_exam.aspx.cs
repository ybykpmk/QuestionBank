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
                        Exam_Sub_Top_Que_CountList Exam_Que_Count_list = Exam_Sub_Top_Que_CountManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        if (Exam_Que_Count_list != null)
                        {
                            upd_pnl.Visible = true;
                            ObjectDataSource1.SelectParameters.Add("pi_exam_id", Request.QueryString["pi_exam_id"]);
                        }
                        else
                        {
                            upd_pnl.Visible = false;
                        }
                        Exam_QuestionList MyExam_QuestionList = Exam_QuestionManager.GetList(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        if (MyExam_QuestionList == null)
                        {
                            btn_view_que.Visible = false;
                        }
                        Exam MyExam=ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                        Txt_exam_name.Text = MyExam.Exam_name;
                        Txt_les_name.Text = MyExam.Lesson_name;
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

    protected void btn_turn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_exam.aspx");
    }

    protected void btn_view_que_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_exam_que.aspx?pi_exam_id=" + Request.QueryString["pi_exam_id"]);
    }
}
