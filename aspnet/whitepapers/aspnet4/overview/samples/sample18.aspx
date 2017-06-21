<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowjQuery.aspx.cs" Inherits="ShowjQuery" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Show jQuery</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:TextBox ID="txtFirstName" runat="server" />
        <br />
        <asp:TextBox ID="txtLastName" runat="server" />
    </div>
    </form>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>

    <script type="text/javascript">
    
        $("input").focus( function() { $(this).css("background-color", "yellow"); });
    
    </script>
</body>
</html>