<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="upd_que.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:ValidationSummary ID="Validation_page" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_qb_Group"/>

<asp:Label ID="Lbl_record_stat" runat="server"></asp:Label><br /><br />      
<asp:UpdatePanel ID="upd_pnl" runat="server">
<ContentTemplate>
<center>
<asp:Label ID="Lbl_Header" Font-Bold="true" Font-Size="Large" runat="server">QUESTION LIST (FOR UPDATING)</asp:Label>
<br /><br />
<asp:Label ID="Lbl_les_name" runat="server">Select Lesson :</asp:Label>&nbsp;&nbsp;
<asp:DropDownList ID="DDL_les_name" runat="server" dir="rtl" onselectedindexchanged="DDL_les_name_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&nbsp;&nbsp;
<asp:Label ID="Lbl_les_sub_name" runat="server">Select Lesson Subject :</asp:Label>&nbsp;&nbsp;
<asp:DropDownList ID="DDL_les_sub_name" runat="server" dir="rtl" onselectedindexchanged="DDL_les_sub_name_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>&nbsp;&nbsp;
<asp:Label ID="Lbl_les_sub_top_name" runat="server">Select Lesson Sub-Topic :</asp:Label>&nbsp;&nbsp;  
<asp:DropDownList ID="DDL_les_sub_top_name" runat="server" dir="rtl" onselectedindexchanged="DDL_les_sub_top_name_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
<br /><br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#660066" BorderStyle="Ridge" BorderWidth="3px" 
        CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Both" 
        AllowPaging="True" HorizontalAlign="Center" Width="100%">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
        <a href="<%# (string) Check_Update_Question(Eval("Question_id").ToString())%>">Update Question</a>
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
        SelectMethod="GetList_For_Upd_Del_Question" TypeName="Ybyk.QBank.Bll.QuestionManager" 
        UpdateMethod="Update"></asp:ObjectDataSource>

        </ContentTemplate>
        <Triggers>
        
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>