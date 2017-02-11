<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
 <asp:Panel runat="server" ID="AuthenticatedMessagePanel">
 <asp:Label runat="server" ID="WelcomeBackMessage"></asp:Label>
 </asp:Panel>
 <asp:Panel runat="Server" ID="AnonymousMessagePanel">
 <asp:HyperLink runat="server" ID="lnkLogin" Text="Log In" NavigateUrl="~/Login.aspx"></asp:HyperLink>
 </asp:Panel>
</asp:Content>