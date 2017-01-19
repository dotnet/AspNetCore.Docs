<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index4.aspx.cs" Inherits="MvcApp.Views.Home.Index4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Login Form without Help</title>
</head>
<body>
    <div>

    <form method="post" action="/Home/Login">
    
    <label for="userName">User Name:</label>
    <br />
    <input name="userName" />
    
    <br /><br />
    
    <label for="password">Password:</label>
    <br />
    <input name="password" type="password" />
    
    <br /><br />
    <input type="submit" value="Log In" />
    
    </form>
    
    </div>
</body>
</html>