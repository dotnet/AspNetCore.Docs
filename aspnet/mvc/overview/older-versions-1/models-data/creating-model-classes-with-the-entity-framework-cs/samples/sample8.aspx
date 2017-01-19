<%@ Page Language="C#" 
  Inherits="System.Web.Mvc.ViewPage<MovieEntityApp.Models.Movie>" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit</title>
    <style type="text/css">
    
    .input-validation-error
    {
        background-color:Yellow;
    }
    
    </style>    
</head>
<body>
    <div>

<h1>Edit Movie</h1>

<form method="post" action="/Home/Edit">

    <!-- Include Hidden Id -->
    <%= Html.Hidden("id") %>

    Title:
    <br />
    <%= Html.TextBox("title") %>
    
    <br /><br />
    Director:
    <br />
    <%= Html.TextBox("director") %>
    
    <br /><br />
    <input type="submit" value="Edit Movie" />
</form>
    
    </div>
</body>
</html>