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
                }            
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void btn_rec_user_Click(object sender, EventArgs e)
    {
        Int32 rec_stat,rec_user_id = -1;
        User control_user = UserManager.GetItem(Txt_username.Text);
        if (control_user == null)
        {
            try
            {
                User MyUser = new User();
                MyUser.Active = RBL_active.SelectedValue;
                MyUser.Created_date = DateTime.Now;
                MyUser.Department_id = Convert.ToInt32(DDL_department.SelectedValue);
                MyUser.Host_ip = Txt_host_ip.Text;
                MyUser.Rank_id = Convert.ToInt32(DDL_rank.SelectedValue);
                MyUser.Real_name = Txt_name.Text;
                MyUser.User_name = Txt_username.Text;
                MyUser.User_password = Enc_Dec_Manager.EncodePasswordToBase64(txt_password.Text);
                MyUser.Password_changed = "N";
                MyUser.User_task = Txt_task.Text;
                rec_stat = UserManager.Insert(MyUser);
                if (rec_stat > 0)
                {
                    rec_user_id = rec_stat;
                    try
                    {
                        User_Authority MyUser_Authority = null;
                        for (int j = 0; j < LB_userauthority.Items.Count; j++)
                        {
                            MyUser_Authority = new User_Authority();
                            MyUser_Authority.Authority_id = Convert.ToInt32(LB_userauthority.Items[j].Value);
                            MyUser_Authority.User_id = rec_user_id;
                            rec_stat = User_AuthorityManager.Insert(MyUser_Authority);
                            MyUser_Authority = null;
                        }
                    }
                    catch (Exception exc2)
                    {
                        Response.Write("<font color='red'>There has been a problem while recording new user authority. The exception message is: " + exc2.Message + "</font>");
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
                            user_log.Log_content = "User has recorded a new user account. Recorded new User's ID is " + rec_user_id;
                            LogManager.Insert(user_log);
                        }
                        catch (Exception exc)
                        {
                            Response.Write("<font color='red'>There has been a problem while recording log which is about new user account record. The exception message is: " + exc.Message + "</font>");
                            return;
                        }
                    }
                }
            }
            catch (Exception exc1)
            {
                Response.Write("<font color='red'>There has been a problem while recording new user account. The exception message is: " + exc1.Message + "</font>");
                return;
            }
            if (rec_stat > 0)
            {
                Lbl_record_stat.Text = "<font color='navy'>Recording new user account has been performed.</font>";
                ClearFields(sender, e);
            }
            else
            {
                Lbl_record_stat.Text = "<font color='red'>There has been a problem while recording new user account.</font>";
            }
        }
        else
        {
            Lbl_record_stat.Text = "<font color='red'>UserName you have written was recorded before. Please change the UserName try to record again!</font>";
        }
    }

    protected void btn_rec_cancel_Click(object sender, EventArgs e)
    {
        ClearFields(sender, e);
        Lbl_record_stat.Text = "<font color='red'>Recording new user account has been canceled.</font>";
    }

    protected void ClearFields(object sender, EventArgs e)
    {
        DDL_department.SelectedIndex = 0;
        DDL_rank.SelectedIndex = 0;
        RBL_active.Items[0].Selected = false;
        RBL_active.Items[1].Selected = false;
        Txt_host_ip.Text = "";
        Txt_name.Text = "";
        txt_password.Text = "";
        txt_conf_password.Text = "";
        Txt_task.Text = "";
        Txt_username.Text = "";
        LB_userauthority.Items.Clear();
        AuthorityList MyAuthorityList = AuthorityManager.GetList();
        Int32 i = 0;
        LB_authority.Items.Clear();
        foreach (Authority MyAuthority in MyAuthorityList)
        {
            LB_authority.Items.Add(MyAuthority.Authority_name);
            LB_authority.Items[i].Value = MyAuthority.Authority_id.ToString();
            i++;
        }
    }

    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        if (LB_authority.SelectedIndex>-1)
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
