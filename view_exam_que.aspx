﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="view_exam_que.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<asp:ValidationSummary ID="Validation_page" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_qb_Group"/>

<br />
<asp:Label ID="Lbl_exam_que" dir="rtl" runat="server"></asp:Label>      
<br />
<center>
<asp:Button ID="btn_turn_back" runat="server" Text="Turn Back" OnClientClick="javascript:history.back();return false;"/>
</center>
</asp:Content>