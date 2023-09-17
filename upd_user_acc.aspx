<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="upd_user_acc.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:ValidationSummary ID="Validation_page" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_qb_Group"/>

<br />
<asp:Label ID="Lbl_record_stat" runat="server"></asp:Label>      
<asp:UpdatePanel ID="upd_pnl" runat="server">
<ContentTemplate>
<center>
<asp:Label ID="Lbl_Header" Font-Bold="true" Font-Size="Large" runat="server">APPLICATION USER LIST (FOR UPDATING)</asp:Label>
<br /><br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#660066" BorderStyle="Ridge" BorderWidth="3px" 
        CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Both" 
        AllowPaging="True" HorizontalAlign="Center">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
        <a href="<%# (string) Check_Update_Account(Eval("User_id").ToString())%>">Update Account</a>&nbsp;&nbsp;
        <a href="<%# (string) Check_Update_Password(Eval("User_id").ToString())%>" style="color: #FF0000">Update Password</a>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="User_name" HeaderText="UserName" ItemStyle-HorizontalAlign="Right" 
            SortExpression="User_name" />
        <asp:BoundField DataField="Real_name" HeaderText="Name" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Real_name" />
        <asp:BoundField DataField="Rank_name" HeaderText="Rank" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Rank_name" />
        <asp:BoundField DataField="Department_name" HeaderText="Department Name" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Department_name" />
        <asp:BoundField DataField="User_task" HeaderText="Task" ItemStyle-HorizontalAlign="Right" 
            SortExpression="User_task" />
        <asp:BoundField DataField="Host_ip" HeaderText="Host IP" 
            SortExpression="Host_ip" />
         <asp:BoundField DataField="Created_date" 
            HeaderText="Created Date" SortExpression="Created_date" />
        <asp:BoundField DataField="Active" HeaderText="Enabled Account?" ItemStyle-HorizontalAlign="Center" 
            SortExpression="Active" />
        <asp:BoundField DataField="Password_changed" HeaderText="Password is Changed?" ItemStyle-HorizontalAlign="Center" 
            SortExpression="Password_changed" />
    </Columns>
    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center"/>
    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    <SortedAscendingCellStyle BackColor="#F4F4FD" />
    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
    <SortedDescendingCellStyle BackColor="#D8D8F0" />
    <SortedDescendingHeaderStyle BackColor="#3E3277" />
</asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="Ybyk.QBank.BO.User" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetList" TypeName="Ybyk.QBank.Bll.UserManager" 
        UpdateMethod="Update"></asp:ObjectDataSource>

        </ContentTemplate>
        <Triggers>
        
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>