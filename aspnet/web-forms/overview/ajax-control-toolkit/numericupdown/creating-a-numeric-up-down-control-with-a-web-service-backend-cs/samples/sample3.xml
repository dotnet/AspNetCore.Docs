<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title>Control Toolkit</title>
</head>
<body>
 <form id="form1" runat="server">
 <asp:ScriptManager ID="asm" runat="server" />
 <div>
 How many MB do you want? <asp:TextBox ID="TextBox1" Text="32" runat="server" />
 <ajaxToolkit:NumericUpDownExtender ID="nud" runat="server"
 TargetControlID="TextBox1" Width="100"
 ServiceUpPath="NumericUpDown1.cs.asmx" 
 ServiceDownPath="NumericUpDown1.cs.asmx"
 ServiceUpMethod="Up" ServiceDownMethod="Down" />
 </div>
 </form>
</body>
</html>