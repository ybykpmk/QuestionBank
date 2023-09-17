<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="view_pub_exam.aspx.cs" Inherits="_Default" %>

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
<asp:UpdatePanel ID="upd_pnl" runat="server">
<ContentTemplate>
<center>
<asp:Label ID="Lbl_Header" Font-Bold="true" Font-Size="Large" runat="server">EXAM LIST (PUBLISHED)</asp:Label>
<br /><br />
<asp:Label ID="Lbl_les_name" runat="server">Select Lesson :</asp:Label>&nbsp;&nbsp;
<asp:DropDownList ID="DDL_les_name" runat="server" dir="rtl" 
        onselectedindexchanged="DDL_les_name_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br /><br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#660066" BorderStyle="Ridge" BorderWidth="3px" 
        CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Both" 
        AllowPaging="True" HorizontalAlign="Center" Width="100%">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:TemplateField HeaderText="Action">
        <ItemTemplate>
        <asp:Label runat="server"><%# (string) Check_Pub_Exam(Eval("Exam_id").ToString())%></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Lesson_name" HeaderText="Lesson Name" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Lesson_name" />
        <asp:BoundField DataField="Exam_name" HeaderText="Exam Name" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Exam_name" />
        <asp:BoundField DataField="User_name" HeaderText="Created By" ItemStyle-HorizontalAlign="Right" 
            SortExpression="User_name" />
        <asp:BoundField DataField="Asked_year" HeaderText="Asked Year" ItemStyle-HorizontalAlign="Right" 
            SortExpression="Asked_year" />
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
        DataObjectTypeName="Ybyk.QBank.BO.Exam" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetList_Pub_Exam_For_Department" TypeName="Ybyk.QBank.Bll.ExamManager" 
        UpdateMethod="Update"></asp:ObjectDataSource>

        </ContentTemplate>
        <Triggers>
        
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>