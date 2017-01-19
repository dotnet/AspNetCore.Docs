<p>
    <asp:Button ID="UpdateAllProducts1" runat="server" Text="Update Products" />
</p>
<p>
    <asp:GridView ID="ProductsGrid" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ProductID" DataSourceID="ProductsDataSource" 
        AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:TemplateField HeaderText="Product" SortExpression="ProductName">
                <ItemTemplate>
                    <asp:TextBox ID="ProductName" runat="server" 
                        Text='<%# Bind("ProductName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        ControlToValidate="ProductName"
                        ErrorMessage="You must provide the product's name." 
                        runat="server">*</asp:RequiredFieldValidator>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category" 
                SortExpression="CategoryName">
                <ItemTemplate>
                    <asp:DropDownList ID="Categories" runat="server" 
                        AppendDataBoundItems="True" 
                        DataSourceID="CategoriesDataSource"
                        DataTextField="CategoryName" 
                        DataValueField="CategoryID" 
                        SelectedValue='<%# Bind("CategoryID") %>'>
                        <asp:ListItem>-- Select One --</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" 
                SortExpression="UnitPrice">
                <ItemTemplate>
                    $<asp:TextBox ID="UnitPrice" runat="server" Columns="8" 
                        Text='<%# Bind("UnitPrice", "{0:N}") %>'></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="UnitPrice"
                        ErrorMessage="You must enter a valid currency value. 
                                      Please omit any currency symbols."
                        Operator="GreaterThanEqual" Type="Currency" 
                        ValueToCompare="0">*</asp:CompareValidator>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discontinued" SortExpression="Discontinued">
                <ItemTemplate>
                    <asp:CheckBox ID="Discontinued" runat="server" 
                        Checked='<%# Bind("Discontinued") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</p>
<p>
    <asp:Button ID="UpdateAllProducts2" runat="server" Text="Update Products" />
    <asp:ObjectDataSource ID="ProductsDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetProducts" TypeName="ProductsBLL">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CategoriesDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCategories" TypeName="CategoriesBLL">
    </asp:ObjectDataSource>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />
</p>