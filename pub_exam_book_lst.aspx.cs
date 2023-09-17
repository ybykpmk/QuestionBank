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
                        if (cont_Exam_TemplateList != null)
                        {
                            Exam MyExam = ExamManager.GetItem(Convert.ToInt32(Request.QueryString["pi_exam_id"]));
                            Txt_exam_name.Text = MyExam.Exam_name;
                            Txt_les_name.Text = MyExam.Lesson_name;
                            Label[] Label_Array = { Lbl_goup_a, Lbl_goup_b, Lbl_goup_c, Lbl_goup_d };
                            string[] GroupName_Array = { "Group A", "Group B", "Group C", "Group D" };
                            Int32 i = 0;
                            foreach (Exam_Template MyExam_Template in cont_Exam_TemplateList)
                            {
                                Label_Array[i].Text = "<a href='view_exam_book.aspx?pi_exam_template_id=" + MyExam_Template.Exam_template_id + "'>" + GroupName_Array[i] + "</a>";
                                i = i + 1;
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
