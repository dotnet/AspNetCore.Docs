<%@ Page Language="C#"  
  Inherits="System.Web.Mvc.ViewPage<List<MovieEntityApp.Models.Movie>>" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <div>
    
<% foreach (var m in ViewData.Model)
   { %>

    Title: <%= m.Title %>
    <br />
    Director: <%= m.Director %>
    <br />
    <%= Html.ActionLink("Edit", "Edit", new { id = m.Id })%>
    <%= Html.ActionLink("Delete", "Delete", new { id = m.Id })%>
       
        <hr />
<% } %>

<%= Html.ActionLink("Add Movie", "Add") %>
    
    </div>
</body>
</html>