<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="cha_que.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<br />
<asp:Label ID="Lbl_record_stat" runat="server"></asp:Label>      
<br /><br />

 <asp:Table ID="Table1" runat="server" Width="100%" HorizontalAlign="Center" BorderStyle="Ridge" BorderColor="#666666">
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center">
 <asp:Table ID="Tbl_que_info" runat="server" Width="100%" HorizontalAlign="Center" Visible="false">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="6" HorizontalAlign="Center">
 <asp:Label ID="Lbl_Heading" runat="server"><h2>CHANGING EXAM QUESTION</h2></asp:Label><br/>
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
 <asp:TableCell ColumnSpan="6" HorizontalAlign="Center">
  <asp:Button ID="btn_cha_que" runat="server" Text="Change Question" OnClick="btn_cha_que_Click"/>&nbsp;&nbsp;
  <asp:Button ID="btn_cha_cancel" runat="server" Text="Cancel" OnClick="btn_cha_cancel_Click"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center">
 <asp:UpdatePanel ID="upd_pnl" runat="server">
<ContentTemplate>
<center>
<asp:Label ID="Lbl_Header" Font-Bold="true" Font-Size="Large" runat="server">QUESTION LIST (FOR CHANGING)</asp:Label>
<br /><br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#660066" BorderStyle="Ridge" BorderWidth="3px" 
        CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Both" 
        AllowPaging="True" HorizontalAlign="Center" Width="100%">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
        <a href="<%# (string) Check_View_Question(Eval("Question_id").ToString())%>">View Question</a>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Question_type_name" HeaderText="Question Type" 
            SortExpression="Question_type_name" />
        <asp:BoundField DataField="Question_difficulty_degree" HeaderText="Question Difficulty" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Question_difficulty_degree" />
        <asp:BoundField DataField="Question_content" HeaderText="Question" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Question_content" />
         <asp:BoundField DataField="Created_date" 
            HeaderText="Created Date" SortExpression="Created_date" />
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
        DataObjectTypeName="Ybyk.QBank.BO.Question" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetList_For_Another_Questions" TypeName="Ybyk.QBank.Bll.QuestionManager" 
        UpdateMethod="Update"></asp:ObjectDataSource>

        </ContentTemplate>
        <Triggers>
        
        </Triggers>
        </asp:UpdatePanel>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell HorizontalAlign="Center"><br />
  <asp:Button ID="btn_view_que" runat="server" Text="Go to View Exam Questions" OnClick="btn_view_que_Click"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
</asp:Content>