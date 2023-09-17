<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ins_exam.aspx.cs" Inherits="_Default" %>

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
 <asp:DropDownList ID="DDL_les_name" dir="rtl" runat="server"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_les_nameRequired" runat="server" ControlToValidate="DDL_les_name" 
                             CssClass="failureNotification" ErrorMessage="Lesson Name is required." ToolTip="Lesson Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow>
 <asp:TableCell ColumnSpan="4" HorizontalAlign="Center"><br />
 <asp:Button ID="btn_rec_exam_que_dub_top_cou" runat="server" ValidationGroup="Validation_qb_Group" Text="Record" OnClick="btn_rec_exam_que_dub_top_cou_Click"/>&nbsp;&nbsp;
  <asp:Button ID="btn_rec_cancel" runat="server" Text="Cancel" OnClick="btn_rec_cancel_Click"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
</asp:Content>