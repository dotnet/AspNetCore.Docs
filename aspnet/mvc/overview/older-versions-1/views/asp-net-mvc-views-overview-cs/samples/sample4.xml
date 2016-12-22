<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Login Form</title>
</head>
<body>
    <div>
    
    <% using (Html.BeginForm())
       { %>

        <label for="UserName">User Name:</label>
        <br />
        <%= Html.TextBox("UserName") %>
        
        <br /><br />
            
        <label for="Password">Password:</label>
        <br />
        <%= Html.Password("Password") %>
        
        <br /><br />

        <input type="submit" value="Log in" />        
    
    <% } %>
    
    </div>
</body>
</html>