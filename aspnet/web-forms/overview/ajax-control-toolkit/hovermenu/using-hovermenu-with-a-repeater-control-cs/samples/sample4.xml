<asp:Repeater ID="rep1" DataSourceID="sds1" runat="server">
 <ItemTemplate>
 <br />
 <asp:Panel ID="myPanel" runat="server" Width="400px" BackColor="Lime" BorderWidth="1px">
 <div>
 Vendor
 <%#DataBinder.Eval(Container.DataItem, "Name")%>
 </div>
 </asp:Panel>
 <br />
 <ajaxToolkit:HoverMenuExtender ID="hme" runat="server" TargetControlID="myPanel"
 PopupControlID="HoverPanel" PopupPosition="Right" PopDelay="50" />
 </ItemTemplate>
</asp:Repeater>