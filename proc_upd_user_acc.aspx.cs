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
        if ((Request.QueryString["pi_user_id"] != null) & (Request.QueryString["pi_user_id"] != "") & (Request.QueryString["process"] != null) & (Request.QueryString["process"] != ""))
        {
            if (Session["User"] != null)
            {
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
                if (auth_cont == true)
                {
                    if (!Page.IsPostBack)
                    {
                        RankList MyRankList = RankManager.GetList();
                        Int32 i = 0;
                        DDL_rank.Items.Clear();
                        DDL_rank.Items.Add("");
                        DDL_rank.Items[i].Value = null;
                        i++;
                        foreach (Rank MyRank in MyRankList)
                        {
                            DDL_rank.Items.Add(MyRank.Rank_name);
                            DDL_rank.Items[i].Value = MyRank.Rank_id.ToString();
                            i++;
                        }
                        DepartmentList MyDepartmentList = DepartmentManager.GetList();
                        i = 0;
                        DDL_department.Items.Clear();
                        DDL_department.Items.Add("");
                        DDL_department.Items[i].Value = null;
                        i++;
                        foreach (Department MyDepartment in MyDepartmentList)
                        {
                            DDL_department.Items.Add(MyDepartment.Department_name);
                            DDL_department.Items[i].Value = MyDepartment.Department_id.ToString();
                            i++;
                        }
                        AuthorityList MyAuthorityList = AuthorityManager.GetList();
                        i = 0;
                        LB_authority.Items.Clear();
                        foreach (Authority MyAuthority in MyAuthorityList)
                        {
                            LB_authority.Items.Add(MyAuthority.Authority_name);
                            LB_authority.Items[i].Value = MyAuthority.Authority_id.ToString();
                            i++;
                        }
                        User MyUser = UserManager.GetItem(Convert.ToInt32(Request.QueryString["pi_user_id"]));
                        Txt_host_ip.Text = MyUser.Host_ip;
                        Txt_name.Text = MyUser.Real_name;
                        txt_conf_password.Text = Enc_Dec_Manager.DecodeFrom64(MyUser.User_password);
                        txt_password.Text = Enc_Dec_Manager.DecodeFrom64(MyUser.User_password);
                        Txt_task.Text = MyUser.User_task;
                        Txt_username.Text = MyUser.User_name;
                        DDL_department.SelectedValue = MyUser.Department_id.ToString();
                        DDL_rank.SelectedValue = MyUser.Rank_id.ToString();
                        if (MyUser.Active=="Y")
                        {
                            RBL_active.Items[0].Selected=true;
                        }
                        else
                        {
                            RBL_active.Items[1].Selected = true;
                        }

                        User_AuthorityList MyUser_AuthorityList = User_AuthorityManager.GetList(Convert.ToInt32(Request.QueryString["pi_user_id"]));
                        foreach (User_Authority MyUser_Authority in MyUser_AuthorityList)
                        {
                            LB_authority.SelectedValue = MyUser_Authority.Authority_id.ToString();
                            LB_userauthority.Items.Add(LB_authority.SelectedItem);
                            LB_authority.Items.Remove(LB_authority.SelectedItem);
                        }

                        if (Request.QueryString["process"] == "update_account")
                        {
                            txt_conf_password.Enabled = false;
                            txt_password.Enabled = false;
                            Txt_username.Enabled = false;                            
                            txt_passwordRequired.Enabled = false;                            
                            txt_conf_passwordRequired.Enabled = false;
                            CompareNewPassword.Enabled = false;
                        }
                        if (Request.QueryString["process"] == "update_password")
                        {
                            Txt_host_ip.Enabled = false;
                            Txt_host_ipRequired.Enabled = false;
                            Txt_name.Enabled = false;
                            Txt_nameRequired.Enabled = false;
                            Txt_task.Enabled = false;
                            DDL_department.Enabled = false;
                            DDL_departmentRequired.Enabled = false;
                            DDL_rank.Enabled = false;
                            DDL_rankRequired.Enabled = false;
                            RBL_active.Enabled = false;
                            RBL_activeRequired.Enabled = false;
                            LB_authority.Enabled = false;
                            LB_userauthority.Enabled = false;
                            LB_userauthorityRequired.Enabled = false;
                            ImageButton1.Enabled = false;
                            ImageButton2.Enabled = false;
                            Txt_username.Enabled = false;                            
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

    protected void btn_upd_user_Click(object sender, EventArgs e)
    {
        Int32 rec_stat, rec_user_id = -1;
        User MyUser = UserManager.GetItem(Convert.ToInt32(Request.QueryString["pi_user_id"]));
        if (Request.QueryString["process"] == "update_account")
        {
            try
            {
                MyUser.Active = RBL_active.SelectedValue;
                MyUser.Department_id = Convert.ToInt32(DDL_department.SelectedValue);
                MyUser.Host_ip = Txt_host_ip.Text;
                MyUser.Rank_id = Convert.ToInt32(DDL_rank.SelectedValue);
                MyUser.Real_name = Txt_name.Text;
                MyUser.User_name = Txt_username.Text;
                MyUser.User_task = Txt_task.Text;
                rec_stat = UserManager.Update(MyUser);
                if (rec_stat > 0)
                {
                    rec_user_id = rec_stat;
                    try
                    {
                        try
                        {
                            bool del_stat=User_AuthorityManager.Delete(Convert.ToInt32(Request.QueryString["pi_user_id"]));
                        }
                        catch (Exception exc3)
                        {
                            Response.Write("<font color='red'>There has been a problem while deleting user authority before updating it/them. The exception message is: " + exc3.Message + "</font>");
                            throw;
                        }
                        User_Authority MyUser_Authority = null;
                        for (int j = 0; j < LB_userauthority.Items.Count; j++)
                        {
                            MyUser_Authority = new User_Authority();
                            MyUser_Authority.Authority_id = Convert.ToInt32(LB_userauthority.Items[j].Value);
                            MyUser_Authority.User_id = Convert.ToInt32(Request.QueryString["pi_user_id"]);
                            rec_stat = User_AuthorityManager.Insert(MyUser_Authority);
                            MyUser_Authority = null;
                        }
                    }
                    catch (Exception exc2)
                    {
                        Response.Write("<font color='red'>There has been a problem while updating user authority. The exception message is: " + exc2.Message + "</font>");
                        return;
                    }
                    if (rec_stat > 0)
                    {
                        try
                        {
                            Log user_log = new Log();
                            user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                            user_log.User_id = (Session["User"] as User).User_id;
                            user_log.Log_date = DateTime.Now;
                            user_log.Log_content = "User has updated user account. Updated User's ID is " + Request.QueryString["pi_user_id"];
                            LogManager.Insert(user_log);
                        }
                        catch (Exception exc)
                        {
                            Response.Write("<font color='red'>There has been a problem while recording log which is about updating user account. The exception message is: " + exc.Message + "</font>");
                            return;
                        }
                    }
                }
            }
            catch (Exception exc1)
            {
                Response.Write("<font color='red'>There has been a problem while updating user account. The exception message is: " + exc1.Message + "</font>");
                return;
            }
            if (rec_stat > 0)
            {
                Response.Redirect("upd_user_acc.aspx?process=account_updated");
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>There has been a problem while updating user account.</font>";
            }
        }
        else if (Request.QueryString["process"] == "update_password")
        {
            try
            {
                MyUser.User_password = Enc_Dec_Manager.EncodePasswordToBase64(txt_password.Text);
                MyUser.Password_changed = "N";
                rec_stat = UserManager.Update(MyUser);
                if (rec_stat > 0)
                {
                    try
                    {
                        Log user_log = new Log();
                        user_log.Host_ip = HttpContext.Current.Request.UserHostAddress;
                        user_log.User_id = (Session["User"] as User).User_id;
                        user_log.Log_date = DateTime.Now;
                        user_log.Log_content = "User has updated user password. Updated User's ID is " + Request.QueryString["pi_user_id"];
                        LogManager.Insert(user_log);
                    }
                    catch (Exception exc)
                    {
                        Response.Write("<font color='red'>There has been a problem while recording log which is about updating user password. The exception message is: " + exc.Message + "</font>");
                        return;
                    }
                }
            }
            catch (Exception exc1)
            {
                Response.Write("<font color='red'>There has been a problem while updating user password. The exception message is: " + exc1.Message + "</font>");
                return;
            }
            if (rec_stat > 0)
            {
                Response.Redirect("upd_user_acc.aspx?process=password_updated");
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>There has been a problem while updating user password.</font>";
            }
        }
    }

    protected void btn_upd_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("upd_user_acc.aspx?process=update_canceled");
    }

    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        if (LB_authority.SelectedIndex > -1)
        {
            for (int i = 0; i < LB_authority.Items.Count; i++)
            {
                if (LB_authority.Items[i].Selected)
                {
                    LB_userauthority.Items.Add(LB_authority.SelectedItem);
                    LB_authority.Items.Remove(LB_authority.SelectedItem);
                }
            }
        }
    }

    protected void ImageButton2_Click(object sender, EventArgs e)
    {
        if (LB_userauthority.SelectedIndex > -1)
        {
            for (int i = 0; i < LB_userauthority.Items.Count; i++)
            {
                if (LB_userauthority.Items[i].Selected)
                {
                    LB_authority.Items.Add(LB_userauthority.SelectedItem);
                    LB_userauthority.Items.Remove(LB_userauthority.SelectedItem);
                }
            }
        }
    }
}
