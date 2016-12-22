<%@ Page Language="VB" 
  Inherits="System.Web.Mvc.ViewPage(Of List(Of MvcApplication1.Movie))" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <div>
    
<%  For Each m In Model%>

    Title: <%= m.Title %>
    <br />
    Director: <%= m.Director %>
    <br />
    <%=Html.ActionLink("Edit", "Edit", New With {.id = m.Id})%>
    <%=Html.ActionLink("Delete", "Delete", New With {.id = m.Id})%>
       
        <hr />
<% Next%>
    
    <%= Html.ActionLink("Add Movie", "Add") %>
    
    </div>
</body>
</html>