<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ins_user_acc.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<asp:ValidationSummary ID="Validation_page" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_qb_Group"/>
<asp:Label ID="Lbl_record_stat" runat="server"></asp:Label>      
<br />

 <asp:Table ID="Table1" runat="server" Width="100%" HorizontalAlign="Center" BorderStyle="Ridge" BorderColor="#666666">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="6" HorizontalAlign="Center">
 <asp:Label ID="Lbl_Heading" runat="server"><h2>CREATING USER ACCOUNT</h2></asp:Label><br />
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_name" runat="server">Name : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_name" runat="server" dir="rtl" MaxLength="50"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_nameRequired" runat="server" ControlToValidate="Txt_name" 
                             CssClass="failureNotification" ErrorMessage="Name is required." ToolTip="Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_rank" runat="server">Rank : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
  <asp:DropDownList ID="DDL_rank" runat="server" dir="rtl"></asp:DropDownList>
   <asp:RequiredFieldValidator ID="DDL_rankRequired" runat="server" ControlToValidate="DDL_rank" 
                             CssClass="failureNotification" ErrorMessage="Rank is required." ToolTip="Rank is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_task" runat="server">Task : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_task" runat="server" dir="rtl" MaxLength="50"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_taskRequired" runat="server" ControlToValidate="Txt_task" 
                             CssClass="failureNotification" ErrorMessage="Task is required." ToolTip="Task is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_department" runat="server">Department : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
  <asp:DropDownList ID="DDL_department" dir="rtl" runat="server"></asp:DropDownList>
   <asp:RequiredFieldValidator ID="DDL_departmentRequired" runat="server" ControlToValidate="DDL_department" 
                             CssClass="failureNotification" ErrorMessage="Department is required." ToolTip="Department is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  <asp:TableCell Width="10%">
 <asp:Label ID="Llb_host_ip" runat="server">Host IP : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_host_ip" runat="server" MaxLength="15"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_host_ipRequired" runat="server" ControlToValidate="Txt_host_ip" 
                             CssClass="failureNotification" ErrorMessage="Host IP is required." ToolTip="Host IP is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
   <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_active" runat="server">Active : </asp:Label>
  </asp:TableCell>
   <asp:TableCell HorizontalAlign="Left" VerticalAlign="Middle">
       <asp:RadioButtonList ID="RBL_active" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
       <asp:ListItem Selected="False" Value="Y">Yes</asp:ListItem>
       <asp:ListItem Selected="False" Value="N">No</asp:ListItem>
       </asp:RadioButtonList>
 <asp:RequiredFieldValidator ID="RBL_activeRequired" runat="server" ControlToValidate="RBL_active" 
                             CssClass="failureNotification" ErrorMessage="Yes or no is required." ToolTip="Yes or no is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
   </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow>
 <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_username" runat="server">UserName : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_username" runat="server" dir="rtl" MaxLength="20"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_usernameRequired" runat="server" ControlToValidate="Txt_username" 
                             CssClass="failureNotification" ErrorMessage="UserName is required." ToolTip="UserName is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell ColumnSpan="2" RowSpan="3" HorizontalAlign="Center">
 <asp:Table ID="Tbl_authority" runat="server">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
 <asp:Label ID="Lbl_authoritylist" runat="server">Authority List</asp:Label>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:ListBox ID="LB_authority" runat="server" SelectionMode="Multiple" Width="230"></asp:ListBox>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle">
 <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/icons/rnext.gif" OnClick="ImageButton1_Click"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 <asp:TableCell ColumnSpan="2" RowSpan="3">
 <asp:Table ID="Tbl_userauthoritylist" runat="server">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
 <asp:Label ID="Lbl_userauthoritylist" runat="server">User Authority List</asp:Label>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell VerticalAlign="Middle"> 
 <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/icons/rprevious.gif" OnClick="ImageButton2_Click"/> 
 </asp:TableCell>
 <asp:TableCell>
<asp:ListBox ID="LB_userauthority" runat="server" SelectionMode="Multiple" Width="230"></asp:ListBox>
 <asp:RequiredFieldValidator ID="LB_userauthorityRequired" runat="server" ControlToValidate="LB_userauthority" 
                             CssClass="failureNotification" ErrorMessage="At least one authority is required." ToolTip="At least one authority is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_password" runat="server">Password : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="txt_password" runat="server" dir="rtl" TextMode="Password"></asp:TextBox>
 <asp:RequiredFieldValidator ID="txt_passwordRequired" runat="server" ControlToValidate="txt_password" 
                             CssClass="failureNotification" ErrorMessage="Passsword is required." ToolTip="Passsword is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="txt_passwordRegularExpressionValidator" runat="server"     
                                    ErrorMessage="Password must be between 8 and 10 characters, contain at least one digit and one alphabetic character, and must not contain special characters." 
                                    ControlToValidate="txt_password"  ForeColor="Red" ValidationGroup="Validation_qb_Group"   
                                    ValidationExpression="([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{8,10})+" Display="Dynamic"></asp:RegularExpressionValidator>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_conf_password" runat="server">Confirm Password : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="txt_conf_password" runat="server" dir="rtl" TextMode="Password">
 </asp:TextBox>
 <asp:RequiredFieldValidator ID="txt_re_passwordRequired" runat="server" ControlToValidate="txt_conf_password" 
                             CssClass="failureNotification" ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="txt_conf_passwordRegularExpressionValidator" runat="server"     
                                    ErrorMessage="Password must be between 8 and 10 characters, contain at least one digit and one alphabetic character, and must not contain special characters." 
                                    ControlToValidate="txt_conf_password"  ForeColor="Red" ValidationGroup="Validation_qb_Group"   
                                    ValidationExpression="([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{8,10})+" Display="Dynamic"></asp:RegularExpressionValidator>
<asp:CompareValidator ID="CompareNewPassword" runat="server" ControlToCompare="txt_password" ControlToValidate="txt_conf_password" 
                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Confirm Password must match the Password entry."
                             ValidationGroup="Validation_qb_Group">*</asp:CompareValidator>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell ColumnSpan="6" HorizontalAlign="Center"><br />
 <asp:Button ID="btn_rec_user" runat="server" ValidationGroup="Validation_qb_Group" Text="Record" OnClick="btn_rec_user_Click"/>&nbsp;&nbsp;
  <asp:Button ID="btn_rec_cancel" runat="server" Text="Cancel" OnClick="btn_rec_cancel_Click"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
</asp:Content>