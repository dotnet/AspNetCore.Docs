<%@ Master Language="C#" AutoEventWireup="true" CodeFile="Site.master.cs" Inherits="Site" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Untitled Page</title>
 <asp:ContentPlaceHolder id="head" runat="server">
 </asp:ContentPlaceHolder>
 <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
 <form id="form1" runat="server">
 <div id="topContent">
 <a href="Default.aspx">Master Pages Tutorials</a>
 </div>
 
 <div id="mainContent">
 <asp:ContentPlaceHolder id="MainContent" runat="server">
 </asp:ContentPlaceHolder>
 </div>
 
 <div id="leftContent">
 <h3>Lessons</h3>    
 <ul>
 <li>TODO</li>
 </ul>
 <h3>News</h3>    
 <ul>
 <li>TODO</li>
 </ul>
 </div>
 
 <div id="footerContent">
 <img src="Images/PoweredByASPNET.gif" alt="Powered by ASP.NET!" />
 </div>
 </form>
</body>
</html>