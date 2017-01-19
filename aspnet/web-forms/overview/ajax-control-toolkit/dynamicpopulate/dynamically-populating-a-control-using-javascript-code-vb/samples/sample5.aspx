<asp:Panel ID="panel1" runat="server">
 <input type="radio" id="rb1" name="format" value="format1" runat="server"
 onclick="$find('dpe1').populate(this.value);" />m-d-y
 <input type="radio" id="rb2" name="format" value="format2" runat="server"
 onclick="$find('dpe1').populate(this.value);" />d.m.y
 <input type="radio" id="rb3" name="format" value="format3" runat="server"
 onclick="$find('dpe1').populate(this.value);" />y/m/d
</asp:Panel>