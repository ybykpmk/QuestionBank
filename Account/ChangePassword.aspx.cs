using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ybyk.QBank.BO;
using Ybyk.QBank.Bll;
using Ybyk.QBank.Dal;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        if (CurrentPassword.Text.Trim()!=NewPassword.Text.Trim())
        {
            User MyUser = UserManager.GetItem((Txt_UserName.Text).Trim(), Enc_Dec_Manager.EncodePasswordToBase64((CurrentPassword.Text).Trim()));
            if (MyUser != null)
            {
                try
                {
                    MyUser.User_password = Enc_Dec_Manager.EncodePasswordToBase64(ConfirmNewPassword.Text.Trim());
                    MyUser.Password_changed = "Y";
                    Int32 rec_result = UserManager.Update(MyUser);
                    if (rec_result > 0)
                    {
                        try
                        {
                            Log user_log = new Log();
                            user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                            user_log.User_id = MyUser.User_id;
                            user_log.Log_date = DateTime.Now;
                            user_log.Log_content = "User has changed his\\her password and logged on to application.";
                            LogManager.Insert(user_log);
                            Session.Add("User", MyUser);
                        }
                        catch (Exception exc1)
                        {
                            Response.Write("<font color='red'>There has been a problem while recording user's changing his\\her password. The exception message is: " + exc1.Message + "</font>");
                            return;
                        }
                    }
                }
                catch (Exception exc)
                {
                    Response.Write("<font color='red'>There has been a problem while user is changing his\\her password. The exception message is: " + exc.Message + "</font>");
                    return;
                }
                Response.Redirect("../ChangePasswordSuccess.aspx");
            }
            else
            {
                Lbl_login_stat.Text = "<font color='red'>Your UserName or Old Password is incorrect. Please try again with your correct UserName and Old Password!</font>";
            }
        }
        else
        {
            Lbl_login_stat.Text = "<font color='red'>Your Old Password and New Password must be different. Please enter New Password different from your Old Password!</font>";
        }
    }
    protected void CancelPushButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}
