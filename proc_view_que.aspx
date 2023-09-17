<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="proc_view_que.aspx.cs" Inherits="_Default" %>

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
 <asp:TableCell ColumnSpan="6" HorizontalAlign="Center">
 <asp:Label ID="Lbl_Heading" runat="server"><h2>VIEWING QUESTION</h2></asp:Label><br>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell Width="13%">
 <asp:Label ID="Lbl_les_name" runat="server">Lesson Name : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:TextBox ID="Txt_les_name" runat="server" dir="rtl" Enabled="false"></asp:TextBox> 
 </asp:TableCell>
  <asp:TableCell Width="15%">
 <asp:Label ID="Lbl_les_sub_name" runat="server">Lesson Subject Name : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
<asp:TextBox ID="Txt_les_sub_name" runat="server" dir="rtl" Enabled="false"></asp:TextBox> 
 </asp:TableCell>
 <asp:TableCell Width="18%">
 <asp:Label ID="Lbl_les_sub_top_name" runat="server">Lesson Sub-Topic Name : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
<asp:TextBox ID="Txt_les_sub_top_name" runat="server" dir="rtl" Enabled="false"></asp:TextBox> 
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_que_type" runat="server">Question Type : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:TextBox ID="txt_que_type" runat="server" Enabled="false"></asp:TextBox>
 </asp:TableCell>
  <asp:TableCell>
 <asp:Label ID="Lbl_que_diff" runat="server">Question Difficulty : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:TextBox ID="txt_que_diff" runat="server" dir="rtl" Enabled="false"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
  <asp:Label ID="Lbl_que" runat="server">Question Content : </asp:Label>
 </asp:TableCell>
 <asp:TableCell ColumnSpan="5" VerticalAlign="Middle">
 <asp:Table ID="Tbl_que" runat="server" Width="100%">
 <asp:TableRow>
 <asp:TableCell Width="97%">
 <asp:TextBox ID="Txt_que" runat="server" dir="rtl" Height="80" Width="96%" TextMode="MultiLine" Enabled="false"></asp:TextBox>
 </asp:TableCell>
 <asp:TableCell Width="10%">
   <asp:Image ID="Image_que" runat="server" Width="80" Height="80" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell ColumnSpan="6">
 <asp:Table ID="Tbl_options" runat="server" Visible="false" Width="100%">
 <asp:TableRow>
  <asp:TableCell HorizontalAlign="Center" Width="5%">
  <asp:Label ID="Lbl_letter" runat="server">Letter</asp:Label>
 </asp:TableCell>
 <asp:TableCell HorizontalAlign="Center" Width="70%">
 <asp:Table ID="Tbl_head_opt" runat="server" Width="100%">
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center" Width="90%">
 <asp:Label ID="Lbl_option" runat="server">Options</asp:Label> 
 </asp:TableCell>
 <asp:TableCell HorizontalAlign="Center" Width="10%">
 <asp:Label ID="Lbl_recorded_image" runat="server">Recorded Image</asp:Label> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 
 </asp:TableCell>
 <asp:TableCell HorizontalAlign="Center" Width="5%">
  <asp:Label ID="Lbl_cor_ans" runat="server">Correct Answer</asp:Label>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
  <asp:Label ID="Lbl_opt_a" runat="server">a.</asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:Table ID="Tbl_op_a" runat="server" Width="100%">
 <asp:TableRow>
 <asp:TableCell Width="92%">
 <asp:TextBox ID="Txt_opt_a" runat="server" dir="rtl" Width="97%" Height="40" TextMode="MultiLine" Enabled="false"></asp:TextBox>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Image ID="Image_opt_a" runat="server" Width="40" Height="40" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
 <asp:RadioButton ID="RB_ans_a" runat="server" GroupName="Gr_que_ans" Enabled="false"/>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
  <asp:Label ID="Lbl_opt_b" runat="server">b.</asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:Table ID="Tbl_opt_b" runat="server" Width="100%">
 <asp:TableRow>
 <asp:TableCell Width="92%">
<asp:TextBox ID="Txt_opt_b" runat="server" dir="rtl" Width="97%" Height="40" TextMode="MultiLine" Enabled="false"></asp:TextBox>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Image ID="Image_opt_b" runat="server" Width="40" Height="40" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table> 
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
 <asp:RadioButton ID="RB_ans_b" runat="server" GroupName="Gr_que_ans" Enabled="false" />
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
  <asp:Label ID="Lbl_opt_c" runat="server">c.</asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:Table ID="Tbl_opt_c" runat="server" Width="100%">
 <asp:TableRow>
<asp:TableCell Width="92%">
<asp:TextBox ID="Txt_opt_c" runat="server" dir="rtl" Width="97%" Height="40" TextMode="MultiLine" Enabled="false"></asp:TextBox>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Image ID="Image_opt_c" runat="server" Width="40" Height="40" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
 <asp:RadioButton ID="RB_ans_c" runat="server" GroupName="Gr_que_ans" Enabled="false" />
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
  <asp:Label ID="Lbl_opt_d" runat="server">d.</asp:Label>
 </asp:TableCell>
 <asp:TableCell>
  <asp:Table ID="Tbl_opt_d" runat="server" Width="100%">
<asp:TableRow>
<asp:TableCell Width="92%">
<asp:TextBox ID="Txt_opt_d" runat="server" dir="rtl" Width="97%" Height="40" TextMode="MultiLine" Enabled="false"></asp:TextBox>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Image ID="Image_opt_d" runat="server" Width="40" Height="40" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
  <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
 <asp:RadioButton ID="RB_ans_d" runat="server" GroupName="Gr_que_ans" Enabled="false" />
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow VerticalAlign="Middle">
 <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
  <asp:Label ID="Lbl_opt_e" runat="server">e.</asp:Label>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle">
   <asp:Table ID="Tbl_opt_e" runat="server" Width="100%">
<asp:TableRow>
<asp:TableCell Width="92%">
<asp:TextBox ID="Txt_opt_e" runat="server" dir="rtl" Width="97%" Height="40" TextMode="MultiLine" Enabled="false"></asp:TextBox>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Image ID="Image_opt_e" runat="server" Width="40" Height="40" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
 <asp:RadioButton ID="RB_ans_e" runat="server" GroupName="Gr_que_ans" Enabled="false" />
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell ColumnSpan="6" HorizontalAlign="Center"><br />
 <asp:Button ID="btn_turn_back" runat="server" Text="Turn back" OnClientClick="javascript:history.back();return false;"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
</asp:Content>