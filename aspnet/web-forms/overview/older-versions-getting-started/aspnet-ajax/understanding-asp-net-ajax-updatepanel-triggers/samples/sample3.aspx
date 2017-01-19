<%@ Page Language="C#" AutoEventWireup="true"
 CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head id="Head1" runat="server">
 <title>Untitled Page</title>
 </head>
 <body>
 <form id="form1" runat="server">
 <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <div>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server"
 UpdateMode="Conditional">
 <ContentTemplate>
 <asp:Label ID="Label1" runat="server" /><br />
 <asp:Button ID="Button1" runat="server"
 Text="Update Both Panels" OnClick="Button1_Click" />
 <asp:Button ID="Button2" runat="server"
 Text="Update This Panel" OnClick="Button2_Click" />
 <asp:CheckBox ID="cbDate" runat="server"
 Text="Include Date" AutoPostBack="false"
 OnCheckedChanged="cbDate_CheckedChanged" />
 </ContentTemplate>
 </asp:UpdatePanel>
 <asp:UpdatePanel ID="UpdatePanel2" runat="server"
 UpdateMode="Conditional">
 <ContentTemplate>
 <asp:Label ID="Label2" runat="server"
 ForeColor="red" />
 </ContentTemplate>
 <Triggers>
 <asp:AsyncPostBackTrigger ControlID="Button1" 
 EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="ddlColor" 
 EventName="SelectedIndexChanged" />
 </Triggers>
 </asp:UpdatePanel>
 <asp:DropDownList ID="ddlColor" runat="server"
 AutoPostBack="true"
 OnSelectedIndexChanged="ddlColor_SelectedIndexChanged">
 <asp:ListItem Selected="true" Value="Red" />
 <asp:ListItem Value="Blue" />
 <asp:ListItem Value="Green" />
 </asp:DropDownList>
 </div>
 </form>
 </body>
</html>