<div>
 <ul>
 <asp:Repeater ID="rep1" DataSourceID="sds1" runat="server">
 <ItemTemplate>
 <li>
 <%#DataBinder.Eval(Container.DataItem, "Name")%>
 <asp:LinkButton ID="btn1" Text="Remove Item" runat="server" />
 <ajaxToolkit:ConfirmButtonExtender ID="cfe1" runat="server" TargetControlID="btn1" ConfirmText="Are you sure?!" />
 </li>
 </ItemTemplate>
 </asp:Repeater>
 </ul>
</div>