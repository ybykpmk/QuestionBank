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
                    UserList MyuserList = UserManager.GetList();
                    Int32 i = 0;
                    DDL_User.Items.Clear();
                    DDL_User.Items.Add("");
                    DDL_User.Items[i].Value = null;
                    i++;
                    foreach (User MyUser in MyuserList)
                    {
                        DDL_User.Items.Add(MyUser.User_name);
                        DDL_User.Items[i].Value = MyUser.User_id.ToString();
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
    protected void btn_query_Click(object sender, EventArgs e)
    {
        if (((Txt_start_date.Text != null) & (Txt_start_date.Text != "")) & ((Txt_finish_date.Text != null) & (Txt_finish_date.Text != "")) & (DDL_User.SelectedIndex != 0))
        {
            ObjectDataSource1.SelectParameters.Clear();
            ObjectDataSource1.SelectParameters.Add("pi_user_id", DDL_User.SelectedValue);
            ObjectDataSource1.SelectParameters.Add("pi_start_date", Convert.ToDateTime(Txt_start_date.Text).ToString("yyyy-MM-dd"));
            ObjectDataSource1.SelectParameters.Add("pi_finish_date", Convert.ToDateTime(Txt_finish_date.Text).ToString("yyyy-MM-dd"));
            GridView1.DataBind();
        }
    }
}
