<%@ Page Language="VB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ltlResult.Text = Editor1.Content
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <cc1:Editor 
            ID="Editor1" 
            Width="450px"  
            Height="200px"
            runat="server"/>
        <br />
        <asp:Button
            id="btnSubmit"
            Text="Submit"
            Runat="server" onclick="btnSubmit_Click" />
    
        <hr />
        <h1>You Entered:</h1>
        
        <asp:Literal
            id="ltlResult"
            Runat="server" />
        
    </div>
    </form>
</body>
</html>