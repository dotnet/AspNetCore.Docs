<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyConfigBuilders.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>

  <p>ServiceID: <%= ServiceID %></p>
  <p>AppSetting_default: <%= AppSetting_default %></p>
  <p>ConString: <%= ConString %></p>
</asp:Content>
