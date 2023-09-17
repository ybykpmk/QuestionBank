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
                if (Request.QueryString["process"]=="update_canceled")
                {
                    Lbl_record_stat.Text = "<font color='red'>Updating user account has been canceled.</font>";
                }
                else if (Request.QueryString["process"] == "account_updated")
                {
                    Lbl_record_stat.Text = "<font color='navy'>User account has been Updated.</font>";
                }
                else if (Request.QueryString["process"] == "password_updated")
                {
                    Lbl_record_stat.Text = "<font color='navy'>User password has been Updated.</font>";
                }
                User_AuthorityList myuserauthoritylist = User_AuthorityManager.GetList((Session["User"] as User).User_id);
                bool auth_cont = false;
                foreach (User_Authority myuserauthority in myuserauthoritylist)
                {
                    if (myuserauthority.Authority_id == 1)
                    {
                        auth_cont = true;
                        break;
                    }
                }
                if (auth_cont == false)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
    public string Check_Update_Account(string pi_user_id)
    {
        string myurl = "proc_upd_user_acc.aspx?pi_user_id=" + pi_user_id + "&process=update_account";
        return myurl;
    }
    public string Check_Update_Password(string pi_user_id)
    {
        string myurl = "proc_upd_user_acc.aspx?pi_user_id=" + pi_user_id + "&process=update_password";
        return myurl;
    }
}
