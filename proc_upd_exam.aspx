<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="proc_upd_exam.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<asp:ValidationSummary ID="Validation_page" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_qb_Group"/>

<br />
<asp:Label ID="Lbl_record_stat" runat="server"></asp:Label>      
<br /><br />

 <asp:Table ID="Table1" runat="server" Width="100%" HorizontalAlign="Center" BorderStyle="Ridge" BorderColor="#666666">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="4" HorizontalAlign="Center">
 <asp:Label ID="Lbl_Heading" runat="server"><h2>CREATING EXAM</h2></asp:Label><br>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
  <asp:Label ID="Lbl_que" runat="server">Exam Name : </asp:Label>
 </asp:TableCell>
 <asp:TableCell Width="60%">
 <asp:TextBox ID="Txt_exam_name" runat="server" dir="rtl" MaxLength="100" Width="90%"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_exam_nameRequired" runat="server" ControlToValidate="Txt_exam_name" 
                             CssClass="failureNotification" ErrorMessage="Exam Name is required." ToolTip="Exam Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell Width="13%">
 <asp:Label ID="Lbl_les_name" runat="server">Lesson Name : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
<asp:TextBox ID="Txt_les_name" runat="server" dir="rtl" Enabled="false"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow>
 <asp:TableCell ColumnSpan="4" HorizontalAlign="Center"><br />
 <asp:Button ID="btn_go_on_without_upd" runat="server" Text="Go On without Update" OnClick="btn_go_on_without_upd_Click"/>&nbsp;&nbsp;
 <asp:Button ID="btn_upd_exam_que_dub_top_cou" runat="server" ValidationGroup="Validation_qb_Group" Text="Record" OnClick="btn_upd_exam_que_dub_top_cou_Click"/>&nbsp;&nbsp;
  <asp:Button ID="btn_upd_cancel" runat="server" Text="Cancel" OnClick="btn_upd_cancel_Click"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
</asp:Content>