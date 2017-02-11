<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllProducts.aspx.cs"
    Inherits="AllProducts" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>View All Products in a GridView</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            All Products</h2>
        <p>
            <asp:GridView ID="GridView1" runat="server"
             CssClass="DataWebControlStyle">
               <HeaderStyle CssClass="HeaderStyle" />
               <AlternatingRowStyle CssClass="AlternatingRowStyle" />
            </asp:GridView>
             </p>
    </div>
    </form>
</body>
</html>