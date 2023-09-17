<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ins_les_sub_top.aspx.cs" Inherits="_Default" %>

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
 <asp:Label ID="Lbl_Heading" runat="server"><h2>CREATING LESSON SUB-TOPIC</h2></asp:Label><br>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_les_name" runat="server">Lesson Name : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:DropDownList ID="DDL_les_name" runat="server" dir="rtl" onselectedindexchanged="DDL_les_name_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_les_nameRequired" runat="server" ControlToValidate="DDL_les_name" 
                             CssClass="failureNotification" ErrorMessage="Lesson Name is required." ToolTip="Lesson Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  <asp:TableCell>
 <asp:Label ID="Lbl_les_sub_name" runat="server">Lesson Subject Name : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:DropDownList ID="DDL_les_sub_name" dir="rtl" runat="server"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_les_sub_nameRequired" runat="server" ControlToValidate="DDL_les_sub_name" 
                             CssClass="failureNotification" ErrorMessage="Lesson Subject Name is required." ToolTip="Lesson Subject Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_les_sub_top_name" runat="server">Lesson Sub-Topic Name : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_les_sub_top_name" runat="server" dir="rtl" Width="280" MaxLength="50"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_les_sub_top_nameRequired" runat="server" ControlToValidate="Txt_les_sub_top_name" 
                             CssClass="failureNotification" ErrorMessage="Lesson Sub-Topic Name is required." ToolTip="Lesson Sub-Topic Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  <asp:TableCell>
 <asp:Label ID="Lbl_les_sub_top_code" runat="server">Lesson Sub_Topic Code : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_les_sub_top_code" runat="server" dir="rtl" Width="100" MaxLength="20"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_les_sub_top_codeRequired" runat="server" ControlToValidate="Txt_les_sub_top_code" 
                             CssClass="failureNotification" ErrorMessage="Lesson Sub-Topic Code is required." ToolTip="Lesson Sub-Topic Code is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell ColumnSpan="4" HorizontalAlign="Center"><br />
 <asp:Button ID="btn_rec_les_sub_top" runat="server" ValidationGroup="Validation_qb_Group" Text="Record" OnClick="btn_rec_les_sub_top_Click"/>&nbsp;&nbsp;
  <asp:Button ID="btn_rec_cancel" runat="server" Text="Cancel" OnClick="btn_rec_cancel_Click"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
</asp:Content>