<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestjQueryUICDN.WebForm1" %>
<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Using jQuery UI from the CDN</title>
    <link rel="Stylesheet" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:TextBox ID="txtStartDate" ClientIDMode="Static" runat="server" />
    </div>
    </form>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
    <script>
        $("#txtStartDate").datepicker();
    </script>
</body>
</html>