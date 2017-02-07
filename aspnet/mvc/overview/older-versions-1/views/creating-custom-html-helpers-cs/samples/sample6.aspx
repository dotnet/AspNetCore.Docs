<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index3.aspx.cs" Inherits="MvcApplication1.Views.Home.Index3" %>

<%@ Import Namespace="MvcApplication1.Helpers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title>Index3</title>
</head>
<body>
     <div>

          <% using (Html.BeginForm())
          { %>
               <%= Html.Label("firstName", "First Name:") %>    
               <br />
               <%= Html.TextBox("firstName")%>
               <br /><br />
               <%= Html.Label("lastName", "Last Name:") %>    
               <br />
               <%= Html.TextBox("lastName")%>

               <br /><br />
               <input type="submit" value="Register" />
          <% } %>
     </div>
</body>
</html>