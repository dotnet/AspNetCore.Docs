<%@ Master Language="VB" AutoEventWireup="false" CodeBehind="Site.Master.vb" Inherits="MvcApplication1.Site" %>

<%@ Import Namespace="MvcApplication1" %>
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

          <% For Each c In ViewData("categories")%>

               <%=Html.ActionLink(c.Name, "Details", New With {.id = c.Id})%> 

          <% Next%>


          <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server">

          </asp:ContentPlaceHolder>
     </div>
</body>
</html>