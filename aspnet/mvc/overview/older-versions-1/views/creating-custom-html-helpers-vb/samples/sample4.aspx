<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Index2.aspx.vb" Inherits="MvcApplication1.Index2"%>
<%@ Import Namespace="MvcApplication1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title>Index2</title>
</head>

<body>
     <div>
     <% Using Html.BeginForm()
          <%= LabelHelper.Label("firstName", "First Name:") %>
          <br />
          <%= Html.TextBox("firstName") %>
          <br /><br />
          <%= LabelHelper.Label("lastName", "Last Name:") %>
          <br />

          <%= Html.TextBox("lastName") %>
          <br /><br />
          <input type="submit" value="Register" />
     <% End Using %>
     </div>
</body>
</html>