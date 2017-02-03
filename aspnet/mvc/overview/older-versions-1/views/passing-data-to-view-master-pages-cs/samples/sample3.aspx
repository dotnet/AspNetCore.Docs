<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="Site.Master.cs" Inherits="MvcApplication1.Views.Shared.Site" %>
<%@ Import Namespace="MvcApplication1.Models" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title></title>
     <asp:ContentPlaceHolder ID="head" runat="server">

     </asp:ContentPlaceHolder>
</head>
<body>
     <div>
          <h1>My Movie Website</h1>

          <% foreach (var c in (IEnumerable<MovieCategory>)ViewData["categories"])
                           {%>

               <%= Html.ActionLink(c.Name, "Details", new {id=c.Id} ) %> 

          <% } %>


          <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server">

          </asp:ContentPlaceHolder>
     </div>
</body>
</html>