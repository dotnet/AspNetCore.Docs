<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <h2>
 Sign In</h2>
 <p>
 <asp:Login ID="Login1" runat="server" TitleText="">
 </asp:Login>
 </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="QuickLoginUI" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LeftColumnContent" Runat="Server">
 <h3>Sign In Tasks</h3>
 <ul>
 <li>Create a New Account</li>
 <li>Recover Forgotten Password</li>
 </ul>
 <p>TODO: Turn the above text into links...</p>
</asp:Content>