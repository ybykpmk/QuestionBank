using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ybyk.QBank.BO;
using Ybyk.QBank.Bll;
using Ybyk.QBank.Dal;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null && Request.QueryString["event"] == "logout")
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    Log user_log = new Log();
                    user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                    user_log.User_id = (Session["User"] as User).User_id;
                    user_log.Log_date = DateTime.Now;
                    user_log.Log_content = "User has logged off.";
                    LogManager.Insert(user_log);
                    Session["User"] = null;
                }
                catch (Exception exc)
                {
                    Response.Write("<font color='red'>There has been a problem while recording user's logging off. The exception message is: " + exc.Message + "</font>");
                    return;
                }
            }
        }
    }

    protected void btn_change_password_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (((UserName.Text).Trim() != null) & ((Password.Text).Trim() != null))
            {
                try
                {
                    User login_user = UserManager.GetItem((UserName.Text).Trim(),Enc_Dec_Manager.EncodePasswordToBase64((Password.Text).Trim()));
                    if (login_user != null)
                    {
                        if (login_user.Active == "Y")
                        {
                            if (login_user.Password_changed == "Y")
                            {
                                Session.Add("User", login_user);
                                try
                                {
                                    Log user_log = new Log();
                                    user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                                    user_log.User_id = login_user.User_id;
                                    user_log.Log_date = DateTime.Now;
                                    user_log.Log_content = "User has logged on.";
                                    LogManager.Insert(user_log);
                                }
                                catch (Exception exc)
                                {
                                    Response.Write("<font color='red'>There has been a problem while recording user's logging on. The exception message is:  " + exc.Message + "</font>");
                                    return;
                                }
                                Response.Redirect("../Default.aspx");
                            }
                            else
                            {
                                Response.Redirect("ChangePassword.aspx");
                            }
                        }
                        else
                        {
                            Lbl_login_stat.Text = "<font color='red'>Your user account has been disabled. Please contact to application administrator!</font>";                            
                        }
                    }
                    else
                    {
                        Lbl_login_stat.Text = "<font color='red'>Your UserName or Password is incorrect. Please try again with your correct UserName and Password!</font>";
                    }
                }
                catch (Exception exc)
                {
                    Response.Write("<font color='red'>There has been a problem about login. Exception! " + exc.Message + "</font>");
                    return;
                }
            }
        }
    }
}
