<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="proc_upd_les_sub_top.aspx.cs" Inherits="_Default" %>

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
<br /><br />
<asp:Table ID="Table1" runat="server" Width="100%" HorizontalAlign="Center" BorderStyle="Ridge" BorderColor="#666666">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="8" HorizontalAlign="Center">
 <asp:Label ID="Lbl_Heading" runat="server"><h2>UPDATING LESSON SUB-TOPIC</h2></asp:Label><br>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_les_name" runat="server">Lesson Name : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_les_name" runat="server" dir="rtl" Width="200" Enabled="false"></asp:TextBox>
 </asp:TableCell>
  <asp:TableCell>
 <asp:Label ID="Lbl_les_sub_name" runat="server">Lesson Subject Name : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_les_sub_name" runat="server" dir="rtl" Width="200" Enabled="false"></asp:TextBox>
 </asp:TableCell>
  </asp:TableRow>
 <asp:TableRow>
  <asp:TableCell>
 <asp:Label ID="Lbl_les_sub_top_name" runat="server">Lesson Sub-Topic Name : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_les_sub_top_name" dir="rtl" runat="server" Width="200" Enabled="false"></asp:TextBox>
 </asp:TableCell>
  <asp:TableCell>
 <asp:Label ID="Llb_les_sub_top_code" runat="server">Lesson Sub-Topic Code : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_les_sub_top_code" dir="rtl" runat="server" Width="200" MaxLength="20"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_les_sub_top_codeRequired" runat="server" ControlToValidate="Txt_les_sub_top_code" 
                             CssClass="failureNotification" ErrorMessage="Lesson Sub-Topic Code is required." ToolTip="Lesson Sub-Topic Code is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell ColumnSpan="8" HorizontalAlign="Center"><br />
 <asp:Button ID="btn_upd_les_sub_top" runat="server" ValidationGroup="Validation_qb_Group" Text="Update" OnClick="btn_upd_les_sub_top_Click"/>&nbsp;&nbsp;
  <asp:Button ID="btn_upd_cancel" runat="server" Text="Cancel" OnClick="btn_upd_cancel_Click"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table> 
</asp:Content>