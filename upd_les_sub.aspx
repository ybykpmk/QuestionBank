<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="upd_les_sub.aspx.cs" Inherits="_Default" %>

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
<asp:Label ID="Lbl_Header" Font-Bold="true" Font-Size="Large" runat="server">LESSON SUBJECT LIST (FOR UPDATING)</asp:Label>
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
        <a href="<%# (string) Check_Update_Lesson_Subject(Eval("Lesson_subject_id").ToString())%>">Update Lesson Subject</a>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="lesson_name" HeaderText="Lesson Name" ItemStyle-HorizontalAlign="Right" 
            SortExpression="lesson_name" />
        <asp:BoundField DataField="lesson_subject_name" HeaderText="Lesson Subject Name" ItemStyle-HorizontalAlign="Right" 
            SortExpression="lesson_subject_name" />
        <asp:BoundField DataField="lesson_subject_code" HeaderText="Lesson Subject Code" ItemStyle-HorizontalAlign="Right" 
            SortExpression="lesson_subject_code" />
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
        DataObjectTypeName="Ybyk.QBank.BO.Lesson_Subject" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetList" TypeName="Ybyk.QBank.Bll.Lesson_SubjectManager" 
        UpdateMethod="Update"></asp:ObjectDataSource>

        </ContentTemplate>
        <Triggers>
        
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>