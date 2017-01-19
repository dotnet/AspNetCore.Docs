<ajaxToolkit:ReorderList ID="rl1" runat="server" SortOrderField="position" 
 AllowReorder="true" DataSourceID="sds" DataKeyField="id">
 <DragHandleTemplate>
 <div class="DragHandleClass">
 </div>
 </DragHandleTemplate>
 <ItemTemplate>
 <asp:Label ID="ItemLabel" runat="server" Text='<%#Eval("description") %>' />
 </ItemTemplate>
</ajaxToolkit:ReorderList>