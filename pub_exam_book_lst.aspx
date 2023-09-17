<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="pub_exam_book_lst.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:ValidationSummary ID="Validation_page" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_qb_Group"/>

 <asp:Table ID="Table1" runat="server" Width="100%" HorizontalAlign="Center" BorderStyle="Ridge" BorderColor="#666666">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="4" HorizontalAlign="Center">
 <asp:Label ID="Lbl_Heading" runat="server"><h2>PUBLISHED EXAM</h2></asp:Label><br>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell Width="10%">
  <asp:Label ID="Lbl_que" runat="server">Exam Name : </asp:Label>
 </asp:TableCell>
 <asp:TableCell Width="50%">
 <asp:TextBox ID="Txt_exam_name" runat="server" dir="rtl" Width="90%" Enabled="false"></asp:TextBox>
 </asp:TableCell>
 <asp:TableCell Width="13%">
 <asp:Label ID="Lbl_les_name" runat="server">Lesson Name : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:TextBox ID="Txt_les_name" runat="server" dir="rtl" Width="90%" Enabled="false"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell ColumnSpan="4" HorizontalAlign="Center">
 <asp:Table ID="Tbl_exam_books" runat="server">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="4" HorizontalAlign="Center">
 <asp:Label ID="Lbl_exam_books" runat="server">Exam Books</asp:Label>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell Width="25%" HorizontalAlign="Center">
 <asp:Label ID="Lbl_goup_a" runat="server"></asp:Label>
 </asp:TableCell>
 <asp:TableCell Width="25%" HorizontalAlign="Center">
 <asp:Label ID="Lbl_goup_b" runat="server"></asp:Label>
 </asp:TableCell>
 <asp:TableCell Width="25%" HorizontalAlign="Center">
 <asp:Label ID="Lbl_goup_c" runat="server"></asp:Label>
 </asp:TableCell>
 <asp:TableCell Width="25%" HorizontalAlign="Center">
 <asp:Label ID="Lbl_goup_d" runat="server"></asp:Label>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 </asp:TableRow>
</asp:Table>
</asp:Content>