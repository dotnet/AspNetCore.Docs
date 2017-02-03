<%@ Page Language="VB" %>
<%@ Register namespace="MyControls" tagprefix="custom" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Show Custom Editor</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
    <custom:CustomEditor ID="CustomEditor1" 
        Width="450px"  
        Height="200px"
        runat="server" />
    
    </div>
    </form>
</body>
</html>