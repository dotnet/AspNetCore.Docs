<%@ Page Language="VB" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Show the panel
        pnlResults.Visible = true
        
        ' Show the selected values
        lblSelectedText.Text = txtCardText.Text            
        lblSelectedColor.Text = txtCardColor.Text
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
        
        <h1>Create a Business Card</h1>
    
        <asp:Label 
            ID="lblCardText" 
            Text="Card Text"
            AssociatedControlID="txtCardText"
            runat="server" />
        <br />
        <asp:TextBox
            ID="txtCardText"
            Runat="server" />
        
        <br /><br />    
    
        <asp:Label 
            ID="lblCardColor" 
            Text="Card Color"
            AssociatedControlID="txtCardColor"
            runat="server" />
        <br />
        <asp:TextBox
            ID="txtCardColor"
            AutoCompleteType="None"
            Runat="server" />
            
        <cc1:ColorPickerExtender 
            ID="txtCardColor_ColorPickerExtender"  
            TargetControlID="txtCardColor"            
            Enabled="True" 
            runat="server">
        </cc1:ColorPickerExtender>
            
        <br /><br />
        
        <asp:Button
            ID="btnSubmit"
            Text="Submit"
            Runat="server" OnClick="btnSubmit_Click" />

        <asp:Panel ID="pnlResults" Visible="false" runat="server">
 
            <h2>Your Selection</h2>

            Selected Card Text:
            <asp:Label
                ID="lblSelectedText"
                Runat="server" />
            <br />        
            Selected Card Color:
            <asp:Label
                ID="lblSelectedColor"
                Runat="server" />
        
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>