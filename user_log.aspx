<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="user_log.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:ValidationSummary ID="Validation_qb" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_qb_Group"/>
 <asp:UpdatePanel ID="upd_pnl" runat="server">
<ContentTemplate>
<center>
    <asp:DropDownList ID="DDL_User" dir="rtl" runat="server">
    </asp:DropDownList>&nbsp;&nbsp;&nbsp;
     <asp:RequiredFieldValidator ID="DDL_UserRequired" runat="server" ControlToValidate="DDL_User" 
                             CssClass="failureNotification" ErrorMessage="UserName is required." ToolTip="UserName is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
   <asp:TextBox ID="Txt_start_date" runat="server" Width="80"></asp:TextBox>
  <asp:ImageButton ID="MyImagebutton" runat="server" ImageUrl="~/icons/Calendar_scheduleHS.png" />      
     <asp:CalendarExtender  ID="CalendarExtender1" runat="server" Enabled="True" PopupButtonID="MyImagebutton" TargetControlID="Txt_start_date" Format="dd.MM.yyyy">
     </asp:CalendarExtender>
     <asp:MaskedEditExtender TargetControlID="Txt_start_date" ErrorTooltipEnabled="true" MessageValidatorTip="true" MaskType="Date" Mask="99/99/9999" ID="Mee_txt_start_date" runat="server" CultureName="tr-TR"></asp:MaskedEditExtender>
     <asp:MaskedEditValidator ID="Mev_txt_start_date" runat="server"  ControlToValidate="Txt_start_date" ControlExtender="Mee_txt_start_date"
     InvalidValueMessage="Date format is not valid." ValidationGroup="Validation_qb_Group" >*</asp:MaskedEditValidator>&nbsp;&nbsp;
          <asp:RequiredFieldValidator ID="Txt_start_dateRequired" runat="server" ControlToValidate="Txt_start_date" 
                             CssClass="failureNotification" ErrorMessage="Start Date is required." ToolTip="Start Date is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
<asp:Label ID="Lbl_betw" runat="server"> between </asp:Label>&nbsp;&nbsp;
   <asp:TextBox ID="Txt_finish_date" runat="server" Width="80"></asp:TextBox>
  <asp:ImageButton ID="MyImagebutton2" runat="server" ImageUrl="~/icons/Calendar_scheduleHS.png" />      
     <asp:CalendarExtender  ID="CalendarExtender2" runat="server" Enabled="True" PopupButtonID="MyImagebutton2" TargetControlID="Txt_finish_date" Format="dd.MM.yyyy">
     </asp:CalendarExtender>
     <asp:MaskedEditExtender TargetControlID="Txt_finish_date" ErrorTooltipEnabled="true" MessageValidatorTip="true" MaskType="Date" Mask="99/99/9999" ID="Mee_Txt_finish_date" runat="server" CultureName="tr-TR"></asp:MaskedEditExtender>
     <asp:MaskedEditValidator ID="Mev_Txt_finish_date" runat="server"  ControlToValidate="Txt_finish_date" ControlExtender="Mee_Txt_finish_date"
     InvalidValueMessage="Date format is not valid." ValidationGroup="Validation_qb_Group" >*</asp:MaskedEditValidator>&nbsp;&nbsp;
&nbsp;&nbsp;
          <asp:RequiredFieldValidator ID="Txt_finish_dateRequired" runat="server" ControlToValidate="Txt_finish_date" 
                             CssClass="failureNotification" ErrorMessage="Finish Date is required." ToolTip="Finish Date is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
<asp:Button ID="btn_query" runat="server" ValidationGroup="Validation_qb_Group" OnClick="btn_query_Click" Text="Query" />
</center>
<br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#660066" BorderStyle="Ridge" BorderWidth="1px" 
        CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Both" 
        AllowPaging="True" Width="100%">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:BoundField DataField="Log_id" HeaderText="Log Id" 
            SortExpression="Log_id" />
        <asp:BoundField DataField="User_name" HeaderText="UserName" 
            SortExpression="User_name" />
                    <asp:BoundField DataField="Log_content" HeaderText="Log Content" 
            SortExpression="Log_content" />
        <asp:BoundField DataField="Log_date" HeaderText="Log Date" 
            SortExpression="Log_date" />
        <asp:BoundField DataField="Host_ip" HeaderText="Host IP" 
            SortExpression="Host_ip" />
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
        DataObjectTypeName="Ybyk.QBank.BO.Log"
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetList" TypeName="Ybyk.QBank.Bll.LogManager"></asp:ObjectDataSource>
        </ContentTemplate>
        <Triggers>
        
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>
 