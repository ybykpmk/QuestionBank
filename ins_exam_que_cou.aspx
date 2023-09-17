<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ins_exam_que_cou.aspx.cs" Inherits="_Default" %>

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
 <asp:Label ID="Lbl_Heading" runat="server"><h2>CREATING EXAM</h2></asp:Label><br>
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
 <asp:TableCell ColumnSpan="4">
 <asp:Table ID="Tbl_options" runat="server" Visible="false" Width="100%">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="6" HorizontalAlign="Center"><br />
 <asp:Label ID="Lbl_que_cou" runat="server">DETERMINE THE NUMBER OF QUESTIONS ACCORDING TO SUB-TOPIC</asp:Label><br /><br />
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
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
 <asp:DropDownList ID="DDL_les_sub_top_name" runat="server" dir="rtl" Width="150"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_les_sub_top_nameRequired" runat="server" ControlToValidate="DDL_les_sub_top_name" 
                             CssClass="failureNotification" ErrorMessage="Lesson Sub-Topic Name is required." ToolTip="Lesson Sub-Topic Name is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
  </asp:TableRow>
 <asp:TableRow>
   <asp:TableCell>
 <asp:Label ID="Lbl_que_diff" runat="server">Question Difficulty : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:DropDownList ID="DDL_que_diff" runat="server" dir="rtl" Width="80"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_que_diffRequired" runat="server" ControlToValidate="DDL_que_diff" 
                             CssClass="failureNotification" ErrorMessage="Question Difficulty is required." ToolTip="Question Difficulty is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell>
 <asp:Label ID="Lbl_que_type" runat="server">Question Type : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
  <asp:DropDownList ID="DDL_que_type" runat="server" Width="80"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDL_que_type" 
                             CssClass="failureNotification" ErrorMessage="Question Type is required." ToolTip="Question Type is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 <asp:TableCell Width="15%">
 <asp:Label ID="Lbl_que_count" runat="server">Question Count : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:TextBox ID="Txt_que_count" runat="server" dir="rtl" Width="30"></asp:TextBox>
   <asp:RequiredFieldValidator ID="Txt_que_countRequired" runat="server" ControlToValidate="Txt_que_count" 
                             CssClass="failureNotification" ErrorMessage="Question Count is required." ToolTip="Question Count is required." 
                             ValidationGroup="Validation_qb_Group">*</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="Txt_que_countRegularExpressionValidator" runat="server"     
                                    ErrorMessage="Question count must be non-negative number." 
                                    ControlToValidate="Txt_que_count"  ForeColor="Red" ValidationGroup="Validation_qb_Group"   
                                    ValidationExpression="^\d+$" Display="Dynamic"></asp:RegularExpressionValidator>
<asp:CompareValidator ID="Txt_que_countCompare" runat="server" ControlToValidate="Txt_que_count" ValidationGroup="Validation_qb_Group"
Type="Integer" Operator="DataTypeCheck" ErrorMessage="Question count value must be number">*</asp:CompareValidator>

 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell ColumnSpan="6" HorizontalAlign="Center">
 <asp:Button ID="btn_rec_que_count" runat="server" Text="Record Question Count" OnClick="btn_rec_que_count_Click" ValidationGroup="Validation_qb_Group"/>
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
<asp:TableCell ColumnSpan="4" HorizontalAlign="Center">
 <br /><br />
 <asp:UpdatePanel ID="upd_pnl" runat="server" Visible="false">
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
        <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
        <a href="<%# (string) Check_Recount_Question(Eval("Exam_sub_top_que_count_id").ToString())%>">Re-count Question</a>&nbsp;&nbsp;
        <a href="<%# (string) Check_Delete_Question(Eval("Exam_sub_top_que_count_id").ToString())%>">Delete Question Count</a>
        </ItemTemplate>
        </asp:TemplateField>
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
<asp:Button ID="btn_view_cha_que" runat="server" Text="View Exam Questions" OnClick="btn_view_cha_que_Click" Visible="false"/>
 <asp:Button ID="btn_gen_que" runat="server" Text="Generate Exam Questions" OnClick="btn_gen_que_Click" Visible="false"/>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</asp:Content>