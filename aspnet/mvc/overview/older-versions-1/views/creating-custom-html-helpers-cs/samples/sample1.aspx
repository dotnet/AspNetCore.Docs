<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MvcApplication1.Views.Home.Index"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns= "http://www.w3.org/1999/xhtml ">
<head id="Head1" runat="server">
     <title>Index</title>
</head>
<body>
      <div>
          <% using (Html.BeginForm())
          { %>

               <label for="firstName">First Name:</label>
               <br />
               <%= Html.TextBox("firstName")%>
               <br /><br />
               <label for="lastName">Last Name:</label>
               <br />

               <%= Html.TextBox("lastName")%>
               <br /><br />
               <input type="submit" value="Register" />    
          <% } %>
     1     </div>
</body>
</html>