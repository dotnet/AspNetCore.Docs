<asp:Repeater ID="Categories" runat="server" DataSourceID="CategoriesDataSource">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><asp:LinkButton runat="server" ID="ViewCategory"
                Text='<%# String.Format("{0} ({1:N0})", _
                    Eval("CategoryName"), Eval("NumberOfProducts")) %>' />
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
    OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetCategoriesAndNumberOfProducts" TypeName="CategoriesBLL">
</asp:ObjectDataSource>