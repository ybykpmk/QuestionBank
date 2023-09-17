<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="proc_view_exam.aspx.cs" Inherits="_Default" %>

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
 <asp:TableCell ColumnSpan="4" HorizontalAlign="Center">
 <asp:Label ID="Lbl_Heading" runat="server"><h2>VIEWING EXAM</h2></asp:Label><br>
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
 <br /><br />
 <asp:UpdatePanel ID="upd_pnl" runat="server">
<ContentTemplate>
<center>
<asp:Label ID="Lbl_Exam_Header" Font-Bold="true" Font-Size="Large" runat="server">EXAM QUESTION COUNT LIST</asp:Label>
<br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#660066" BorderStyle="Ridge" BorderWidth="3px" 
        CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Both" 
        AllowPaging="True" HorizontalAlign="Center" Width="100%">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:BoundField DataField="Lesson_subject_name" HeaderText="Lesson Subject Name" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Lesson_subject_name" />
        <asp:BoundField DataField="Lesson_sub_topic_name" HeaderText="Lesson Sub-Topic Name" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Lesson_sub_topic_name" />
        <asp:BoundField DataField="Question_difficulty_degree" HeaderText="Question Difficulty" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Question_difficulty_degree" />
        <asp:BoundField DataField="Question_type_name" HeaderText="Question Type" 
            SortExpression="Question_type_name" />
        <asp:BoundField DataField="Question_count" HeaderText="Question Count" ItemStyle-HorizontalAlign="Center" 
            SortExpression="Question_count" />
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
        DataObjectTypeName="Ybyk.QBank.BO.Exam_Sub_Top_Que_Count" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetList" TypeName="Ybyk.QBank.Bll.Exam_Sub_Top_Que_CountManager" 
        UpdateMethod="Update"></asp:ObjectDataSource>

        </ContentTemplate>
        <Triggers>
        
        </Triggers>
        </asp:UpdatePanel>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="4" HorizontalAlign="Center">
 <br /><br />
 <asp:Button ID="btn_turn_back" runat="server" Text="Turn Back" OnClick="btn_turn_back_Click"/>&nbsp;&nbsp;
 <asp:Button ID="btn_view_que" runat="server" Text="View Questions" OnClick="btn_view_que_Click"/>&nbsp;&nbsp;
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</asp:Content>