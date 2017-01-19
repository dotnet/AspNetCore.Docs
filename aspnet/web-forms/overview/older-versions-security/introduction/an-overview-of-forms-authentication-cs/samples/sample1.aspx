<%@ Master Language="C#" AutoEventWireup="true" CodeFile="Site.master.cs" Inherits="Site" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Forms Authentication, Authorization, and User Accounts</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="wrapper">
        <form id="form1" runat="server">
        
            <div id="header">
                <span class="title">User Account Tutorials</span>
            </div>
        
            <div id="content">
                <asp:contentplaceholder id="MainContent" runat="server">
                  <!-- Page-specific content will go here... -->
                </asp:contentplaceholder>
            </div>
            
            <div id="navigation">
                TODO: Menu will go here...
            </div>
        </form>
    </div>
</body>
</html>