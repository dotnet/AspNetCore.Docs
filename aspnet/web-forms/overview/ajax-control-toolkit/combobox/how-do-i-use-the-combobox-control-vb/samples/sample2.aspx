<%@ Page Language="VB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <br />
        
        Select your favorite movie:
        <br />
        <cc1:ComboBox 
            ID="ComboBox1"
            DataSourceID="SqlDataSource1" 
            DataTextField="Title" 
            DataValueField="Id" 
            MaxLength="0" 
            runat="server" >
        </cc1:ComboBox>
     
        <asp:SqlDataSource 
            ID="SqlDataSource1"  
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [Movies]"
            runat="server">
        </asp:SqlDataSource>
     
    </div>
    </form>
</body>
</html>