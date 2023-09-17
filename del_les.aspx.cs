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
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["process"]=="delete_canceled")
                {
                    Lbl_record_stat.Text = "<font color='red'>Deleting Lesson has been Canceled.</font>";
                }
                else if (Request.QueryString["process"] == "lesson_deleted")
                {
                    Lbl_record_stat.Text = "<font color='navy'>Lesson has been Deleted.</font>";
                }
                else if (Request.QueryString["process"] == "lesson_in_exams")
                {
                    Lbl_record_stat.Text = "<font color='red'>There is (are) " + Request.QueryString["les_count"] + " exam(s) about this lesson. If you want to delete this lesson, you must delete exam(s) which is(are) about this lesson.</font>";
                }
                User_AuthorityList myuserauthoritylist = User_AuthorityManager.GetList((Session["User"] as User).User_id);
                bool auth_cont = false;
                foreach (User_Authority myuserauthority in myuserauthoritylist)
                {
                    if (myuserauthority.Authority_id == 2)
                    {
                        auth_cont = true;
                        break;
                    }
                }
                if (auth_cont == false)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    ObjectDataSource1.SelectParameters.Add("pi_department_id", (Session["User"] as User).Department_id.ToString());
                }
            }
        }
    }
    public string Check_Delete_Lesson(string pi_lesson_id)
    {
        string myurl = "proc_del_les.aspx?pi_lesson_id=" + pi_lesson_id;
        return myurl;
    }
}
