<form id="form1" runat="server">
 <asp:ScriptManager ID="asm" runat="server" />
 <div>
 Departure date: <asp:TextBox ID="tbDeparture" runat="server" />
 Return date: <asp:TextBox ID="tbReturn" runat="server" />
 </div>
 <asp:Panel ID="pnlCalendar" runat="server">
 <asp:UpdatePanel ID="up1" runat="server">
 <ContentTemplate>
 <asp:Calendar ID="c1" runat="server" 
 OnSelectionChanged="c1_SelectionChanged" />
 </ContentTemplate>
 </asp:UpdatePanel>
 </asp:Panel>
 <ajaxToolkit:PopupControlExtender ID="pce1" runat="server"
 TargetControlID="tbDeparture" PopupControlID="pnlCalendar" Position="Bottom" />
 <ajaxToolkit:PopupControlExtender ID="pce2" runat="server"
 TargetControlID="tbReturn" PopupControlID="pnlCalendar" Position="Bottom" />
</form>