<div>
 <ul>
 <asp:Repeater ID="rep1" DataSourceID="sds1" runat="server">
 <ItemTemplate>
 <li>
 <%#DataBinder.Eval(Container.DataItem, "Name")%>
 <asp:LinkButton ID="btn1" Text="Remove Item" runat="server" />
 <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server"
 TargetControlId="btn1" PopupControlID="ModalPanel" OkControlID="OKButton" />
 </li>
 </ItemTemplate>
 </asp:Repeater>
 </ul>
</div>