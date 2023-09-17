<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <div class="page">
        <div class="header">
        <asp:Table ID="Tb_flags" runat="server" Width="100%">
        <asp:TableRow>
        <asp:TableCell HorizontalAlign="Left">
        <asp:Image ID="Image_Turkey" Width="48" Height="35" runat="server" ImageUrl="~/icons/Turkey.png" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="Right">        
        <asp:Image ID="Image_Afghanistan" Width="48" Height="35" runat="server" ImageUrl="~/icons/Afghanistan.png" />
        </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
            <div class="title">
                <h1>
                    QUESTION BANK APPLICATION
                </h1>
            </div>
            <div class="clear hideSkiplink">
            </div>
        </div>
        <div class="main">
            <h2>
                LOGIN PAGE
            </h2>
            <p>
                Please enter your username and password for logging on to application.
            </p>
            <span class="failureNotification">
                <asp:Label ID="Lbl_login_stat" runat="server"></asp:Label>
            </span><span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="LoginUserValidationGroup" />
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>User Account Information</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">UserName:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" dir="rtl" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            CssClass="failureNotification" ErrorMessage="UserName is required." ToolTip="UserName is required."
                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" dir="rtl" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btn_change_password" runat="server" Text="Change Password" OnClick="btn_change_password_Click" />&nbsp;&nbsp;
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log in" ValidationGroup="LoginUserValidationGroup"
                        OnClick="LoginButton_Click" />
                </p>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="footer">
<asp:Label ID="Lbl_software_content" runat="server">©2014 This software is developed by Turkish Adviser Team</asp:Label>
<asp:Image ID="Image_Turkish_Flag" runat="server" ImageUrl="~/icons/dalgalanan_bayrak.gif" Width="32" Height="32" />
    </div>
    </div>
    </form>
</body>
</html>