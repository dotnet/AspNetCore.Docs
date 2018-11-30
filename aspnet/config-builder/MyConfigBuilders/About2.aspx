<%@ Page Title="About2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About2.aspx.cs" Inherits="MyConfigBuilders.About2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>ServiceID: <%= ServiceID %></p>
  <p>AppSetting_default: <%= AppSetting_default %></p>
    <p>ConString: <%= ConString %></p>

</asp:Content>
