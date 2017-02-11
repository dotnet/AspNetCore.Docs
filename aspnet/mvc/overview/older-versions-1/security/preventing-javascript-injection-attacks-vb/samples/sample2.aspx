<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="CustomerFeedback.Index"%>

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

     <% For Each feedback As CustomerFeedback.Feedback In ViewData.Model%>
          <p>

          <%=feedback.EntryDate.ToShortTimeString()%>
          --
          <%=feedback.Message%>
          </p>
     <% Next %>

</asp:Content>