<form id="form1" runat="server">
 <asp:ScriptManager ID="asm" runat="server" />
 <div>
 <asp:TextBox ID="Name" runat="server" /> <br />
 <asp:Button ID="btn" runat="server" Text="Submit" OnClick="btn_Click" /><br />
 <asp:Label ID="lbl" runat="server" />
 </div>
 <ajaxToolkit:TextBoxWatermarkExtender ID="tbwe" runat="server"
 TargetControlID="Name" WatermarkText=" Your Name " />
</form>