<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MyConfigBuilders.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>ServiceID: <%= ServiceID %></p>
    <p>ServiceKey: <%= ServiceKey %></p>
    <p>ConString: <%= ConString %></p>

</asp:Content>
