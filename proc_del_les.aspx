<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="proc_del_les.aspx.cs" Inherits="_Default" %>

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
<br />
<asp:Table ID="Table1" runat="server" Width="100%" HorizontalAlign="Center" BorderStyle="Ridge" BorderColor="#666666">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="8" HorizontalAlign="Center">
 <asp:Label ID="Lbl_Heading" runat="server"><h2>DELETING LESSON</h2></asp:Label><br>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_les_name" runat="server">Lesson Name : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_les_name" runat="server" Width="280" dir="rtl" Enabled="false"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_les_nameRequired" runat="server" ControlToValidate="Txt_les_name" 
                             CssClass="failureNotification" ErrorMessage="Lesson Name is required." ToolTip="Lesson Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_les_code" runat="server">Lesson Code : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_les_code" runat="server" Width="60" dir="rtl" Enabled="false"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_les_codeRequired" runat="server" ControlToValidate="Txt_les_code" 
                             CssClass="failureNotification" ErrorMessage="Lesson Code is required." ToolTip="Lesson Code is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  <asp:TableCell Width="10%">
 <asp:Label ID="Llb_les_class" runat="server">Lesson Class : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_les_class" runat="server" Width="60" dir="rtl" Enabled="false"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_les_classRequired" runat="server" ControlToValidate="Txt_les_class" 
                             CssClass="failureNotification" ErrorMessage="Lesson Class is required." ToolTip="Lesson Class is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_les_term" runat="server">Lesson Term : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_les_term" runat="server" Width="60" dir="rtl" Enabled="false"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_les_termRequired" runat="server" ControlToValidate="Txt_les_term" 
                             CssClass="failureNotification" ErrorMessage="Lesson Term is required." ToolTip="Lesson Term is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell ColumnSpan="8" HorizontalAlign="Center"><br />
 <asp:Button ID="btn_del_les" runat="server" ValidationGroup="Validation_qb_Group" Text="Delete" OnClick="btn_del_les_Click" OnClientClick="return delete_cont('lesson');"/>&nbsp;&nbsp;
  <asp:Button ID="btn_del_cancel" runat="server" Text="Cancel" OnClick="btn_del_cancel_Click"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table> 
</asp:Content>