<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Account_ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head id="Head2" runat="server">
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
                Change Password
            </h2>
            <p>
                Use the form below to change your password.
            </p>
            <p>
                New passwords are required to be between
                <%= Membership.MinRequiredPasswordLength %>
                and 10 characters in length.
            </p>
            <span class="failureNotification">
                <asp:Label ID="Lbl_login_stat" runat="server"></asp:Label>
            </span><span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="ChangeUserPasswordValidationGroup" />
            <div class="accountInfo">
                <fieldset class="changePassword">
                    <legend>Account Information</legend>
                    <p>
                        <asp:Label ID="Lbl_UserName" runat="server">UserName :</asp:Label>
                        <asp:TextBox ID="Txt_UserName" runat="server" dir="rtl" Height="19px" Width="313px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Txt_UserNameRequired" runat="server" ControlToValidate="Txt_UserName"
                            CssClass="failureNotification" ErrorMessage="UserName is required." ToolTip="UserName is required."
                            ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Old Password :</asp:Label>
                        <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" dir="rtl" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Old Password is required."
                            ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password :</asp:Label>
                        <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" dir="rtl" TextMode="Password"></asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                            CssClass="failureNotification" ErrorMessage="New Password is required." ToolTip="New Password is required."
                            ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="NewPasswordRegularExpressionValidator" runat="server" ValidationGroup="ChangeUserPasswordValidationGroup"    
                                    ErrorMessage="Password must be between 8 and 10 characters, contain at least one digit and one alphabetic character, and must not contain special characters." 
                                    ControlToValidate="NewPassword" ForeColor="Red" ValidationExpression="([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{8,10})+" Display="Dynamic"></asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword"
                            Width="157px">Confirm New Password :</asp:Label>
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" dir="rtl" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>                       
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                            ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="ConfirmNewPasswordRegularExpressionValidator" runat="server"     
                                    ErrorMessage="Password must be between 8 and 10 characters, contain at least one digit and one alphabetic character, and must not contain special characters." 
                                    ControlToValidate="ConfirmNewPassword"  ForeColor="Red" ValidationGroup="ChangeUserPasswordValidationGroup"   
                                    ValidationExpression="([^~`!@#$%\^&\*\(\)\-+=\\\|\}\]\{\['&quot;:?.>,</]{8,10})+" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                            ControlToValidate="ConfirmNewPassword" CssClass="failureNotification" Display="Dynamic"
                            ErrorMessage="The Confirm New Password must match the New Password entry." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" Text="Cancel"
                        OnClick="CancelPushButton_Click" />
                    &nbsp;<asp:Button ID="ChangePasswordPushButton" runat="server" Text="Change Password"
                        ValidationGroup="ChangeUserPasswordValidationGroup" OnClick="ChangePasswordPushButton_Click" />
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