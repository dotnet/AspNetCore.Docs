<ItemTemplate>
    <li>
        <asp:LinkButton CommandName="ListProducts"  runat="server"
            CommandArgument='<%# Eval("CategoryID") %>' ID="ViewCategory"
            Text='<%# string.Format("{0} ({1:N0})", _
                Eval("CategoryName"), Eval("NumberOfProducts")) %>'>
        </asp:LinkButton>
    </li>
</ItemTemplate>