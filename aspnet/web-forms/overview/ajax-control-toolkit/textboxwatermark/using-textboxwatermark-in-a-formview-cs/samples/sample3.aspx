<div>
 <asp:FormView ID="FormView1" runat="server" DataSourceID="sds" AllowPaging="True">
 <ItemTemplate>
 <%# Eval("Name") %>
 <asp:LinkButton ID="btnNew" runat="server" CommandName="New" Text="Insert" />
 <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" />
 <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" />
 </ItemTemplate>
 <EditItemTemplate>
 <asp:TextBox ID="tbEdit" runat="server" Text='<%# Bind("Name") %>' />
 <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
 </EditItemTemplate>
 <InsertItemTemplate>
 <asp:TextBox ID="tbNew" runat="server" Text='<%# Bind("Name") %>' />
 <asp:LinkButton ID="btnInsert" runat="server" CommandName="Insert" Text="Insert" />
 <ajaxToolkit:TextBoxWatermarkExtender ID="tbwe" runat="server"
 TargetControlID="tbNew" WatermarkText=" Vendor name " />
 </InsertItemTemplate>
 </asp:FormView>
</div>