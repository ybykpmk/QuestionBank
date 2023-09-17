<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="proc_upd_que.aspx.cs" Inherits="_Default" %>

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
 <asp:Label ID="Lbl_Heading" runat="server"><h2>UPDATING QUESTION</h2></asp:Label><br>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell Width="13%">
 <asp:Label ID="Lbl_les_name" runat="server">Lesson Name : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:DropDownList ID="DDL_les_name" runat="server" dir="rtl" onselectedindexchanged="DDL_les_name_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_les_nameRequired" runat="server" ControlToValidate="DDL_les_name" 
                             CssClass="failureNotification" ErrorMessage="Lesson Name is required." ToolTip="Lesson Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  <asp:TableCell Width="15%">
 <asp:Label ID="Lbl_les_sub_name" runat="server">Lesson Subject Name : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:DropDownList ID="DDL_les_sub_name" runat="server" dir="rtl" onselectedindexchanged="DDL_les_sub_name_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_les_sub_nameRequired" runat="server" ControlToValidate="DDL_les_sub_name" 
                             CssClass="failureNotification" ErrorMessage="Lesson Subject Name is required." ToolTip="Lesson Subject Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell Width="18%">
 <asp:Label ID="Lbl_les_sub_top_name" runat="server">Lesson Sub-Topic Name : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:DropDownList ID="DDL_les_sub_top_name" dir="rtl" runat="server"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_les_sub_top_nameRequired" runat="server" ControlToValidate="DDL_les_sub_top_name" 
                             CssClass="failureNotification" ErrorMessage="Lesson Sub-Topic Name is required." ToolTip="Lesson Sub-Topic Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_que_type" runat="server">Question Type : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:DropDownList ID="DDL_que_type" runat="server" OnSelectedIndexChanged="DDL_que_type_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_que_typeRequired" runat="server" ControlToValidate="DDL_que_type" 
                             CssClass="failureNotification" ErrorMessage="Question Type is required." ToolTip="Question Type is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  <asp:TableCell>
 <asp:Label ID="Lbl_que_diff" runat="server">Question Difficulty : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:DropDownList ID="DDL_que_diff" dir="rtl" runat="server"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_que_diffRequired" runat="server" ControlToValidate="DDL_que_diff" 
                             CssClass="failureNotification" ErrorMessage="Question Difficulty is required." ToolTip="Question Difficulty is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  <asp:TableCell>
 <asp:Label ID="Lbl_que_photo_upl" runat="server">Question Image Upload : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
  <asp:FileUpload ID="FileUpl_que_photo" runat="server" Width="180"/>
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
 <asp:TextBox ID="Txt_que" runat="server" dir="rtl" Height="80" Width="96%" TextMode="MultiLine" MaxLength="500"></asp:TextBox>&nbsp;&nbsp;
 <asp:RequiredFieldValidator ID="Txt_queRequired" runat="server" ControlToValidate="Txt_que" 
                             CssClass="failureNotification" ErrorMessage="Question Content is required." ToolTip="Question Content is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
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
 <asp:TableCell HorizontalAlign="Center" Width="40%">
  <asp:Label ID="Lbl_File_Upl" runat="server">Option Image Upload</asp:Label>
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
 <asp:TableCell Width="90%">
 <asp:TextBox ID="Txt_opt_a" runat="server" dir="rtl" Width="97%" Height="40" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_opt_aRequired" runat="server" ControlToValidate="Txt_opt_a" 
                             CssClass="failureNotification" ErrorMessage="Question Option (a) is required." ToolTip="Question Option (a) is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Image ID="Image_opt_a" runat="server" Width="40" Height="40" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle">
  <asp:FileUpload ID="File_Upl_opt_a" runat="server" Width="220"/>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
 <asp:RadioButton ID="RB_ans_a" runat="server" GroupName="Gr_que_ans" />
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
  <asp:Label ID="Lbl_opt_b" runat="server">b.</asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:Table ID="Tbl_opt_b" runat="server" Width="100%">
 <asp:TableRow>
 <asp:TableCell Width="90%">
<asp:TextBox ID="Txt_opt_b" runat="server" dir="rtl" Width="97%" Height="40" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
<asp:RequiredFieldValidator ID="Txt_opt_bRequired" runat="server" ControlToValidate="Txt_opt_b" 
                             CssClass="failureNotification" ErrorMessage="Question Option (b) is required." ToolTip="Question Option (b) is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Image ID="Image_opt_b" runat="server" Width="40" Height="40" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table> 
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle">
  <asp:FileUpload ID="File_Upl_opt_b" runat="server" Width="220"/>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
 <asp:RadioButton ID="RB_ans_b" runat="server" GroupName="Gr_que_ans" />
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
  <asp:Label ID="Lbl_opt_c" runat="server">c.</asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:Table ID="Tbl_opt_c" runat="server" Width="100%">
 <asp:TableRow>
<asp:TableCell Width="90%">
<asp:TextBox ID="Txt_opt_c" runat="server" dir="rtl" Width="97%" Height="40" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_opt_cRequired" runat="server" ControlToValidate="Txt_opt_c" 
                             CssClass="failureNotification" ErrorMessage="Question Option (c) is required." ToolTip="Question Option (c) is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Image ID="Image_opt_c" runat="server" Width="40" Height="40" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle">
  <asp:FileUpload ID="File_Upl_opt_c" runat="server" Width="220"/>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
 <asp:RadioButton ID="RB_ans_c" runat="server" GroupName="Gr_que_ans" />
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
  <asp:Label ID="Lbl_opt_d" runat="server">d.</asp:Label>
 </asp:TableCell>
 <asp:TableCell>
  <asp:Table ID="Tbl_opt_d" runat="server" Width="100%">
<asp:TableRow>
<asp:TableCell Width="90%">
<asp:TextBox ID="Txt_opt_d" runat="server" dir="rtl" Width="97%" Height="40" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
<asp:RequiredFieldValidator ID="Txt_opt_dRequired" runat="server" ControlToValidate="Txt_opt_d" 
                             CssClass="failureNotification" ErrorMessage="Question Option (d) is required." ToolTip="Question Option (d) is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Image ID="Image_opt_d" runat="server" Width="40" Height="40" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle">
  <asp:FileUpload ID="File_Upl_opt_d" runat="server" Width="220"/>
 </asp:TableCell>
  <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
 <asp:RadioButton ID="RB_ans_d" runat="server" GroupName="Gr_que_ans" />
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow VerticalAlign="Middle">
 <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
  <asp:Label ID="Lbl_opt_e" runat="server">e.</asp:Label>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle">
   <asp:Table ID="Tbl_opt_e" runat="server" Width="100%">
<asp:TableRow>
<asp:TableCell Width="90%">
<asp:TextBox ID="Txt_opt_e" runat="server" dir="rtl" Width="97%" Height="40" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
<asp:RequiredFieldValidator ID="Txt_opt_eRequired" runat="server" ControlToValidate="Txt_opt_e" 
                             CssClass="failureNotification" ErrorMessage="Question Option (e) is required." ToolTip="Question Option (e) is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell Width="10%">
 <asp:Image ID="Image_opt_e" runat="server" Width="40" Height="40" BorderStyle="Solid" BorderWidth="3"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle">
  <asp:FileUpload ID="File_Upl_opt_e" runat="server" Width="220"/>
 </asp:TableCell>
 <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
 <asp:RadioButton ID="RB_ans_e" runat="server" GroupName="Gr_que_ans" />
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell ColumnSpan="6" HorizontalAlign="Center"><br />
 <asp:Button ID="btn_upd_que" runat="server" ValidationGroup="Validation_qb_Group" Text="Update" OnClick="btn_upd_que_Click"/>&nbsp;&nbsp;
  <asp:Button ID="btn_rec_cancel" runat="server" Text="Cancel" OnClick="btn_rec_cancel_Click"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
</asp:Content>