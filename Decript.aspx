<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Decript.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Let's Decode Password!
    </h2>
    <p>
    <asp:Label ID="Lbl_Encoded" runat="server">Encoded Password :</asp:Label>&nbsp;&nbsp;
<asp:TextBox ID="Txt_Encoded" runat="server"></asp:TextBox>&nbsp;&nbsp;
<asp:Button ID="Button1" runat="server" Text="Click to Decode" 
            onclick="Button1_Click" />&nbsp;&nbsp;
    <asp:Label ID="Lbl_Decoded" runat="server">Decoded Password :</asp:Label>&nbsp;&nbsp;
<asp:TextBox ID="Txt_Decoded" runat="server"></asp:TextBox><br />
    </p>
</asp:Content>
 