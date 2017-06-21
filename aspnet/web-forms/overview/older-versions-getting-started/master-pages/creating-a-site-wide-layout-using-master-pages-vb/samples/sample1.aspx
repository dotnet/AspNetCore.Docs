<%@ Master Language="VB" CodeFile="Site.master.vb" Inherits="Site" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Untitled Page</title>
 <asp:ContentPlaceHolder id="head" runat="server">
 </asp:ContentPlaceHolder>
</head>
<body>
 <form id="form1" runat="server">
 <div>
 <asp:ContentPlaceHolder id="ContentPlaceHolder1" runat="server">
 
 </asp:ContentPlaceHolder>
 </div>
 </form>
</body>
</html>