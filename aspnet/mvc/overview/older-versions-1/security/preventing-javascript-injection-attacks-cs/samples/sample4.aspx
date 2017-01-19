<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CustomerFeedback.Views.Home.Index"%>

<%@ Import Namespace="CustomerFeedback.Models" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
     <h1>Customer Feedback</h1>
     <p>
          Please use the following form to enter feedback about our product.
     </p>

     <form method="post" action="/Home/Create">
          <label for="message">Message:</label>
          <br />
          <textarea name="message" cols="50" rows="2"></textarea>
          <br /><br />
          <input type="submit" value="Submit Feedback" />

     </form>

     <% foreach (Feedback feedback in ViewData.Model)
     {%>
          <p>
          <%=feedback.EntryDate.ToShortTimeString()%>
          --
          <%=Html.Encode(feedback.Message)%>
          </p>
     <% }%>

</asp:Content>