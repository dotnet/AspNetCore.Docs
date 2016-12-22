<asp:GridView ID="ProductsGrid" runat="server" AutoGenerateColumns="False"
    DataKeyNames="ProductID" DataSourceID="ProductsOptimisticConcurrencyDataSource"
    OnRowUpdated="ProductsGrid_RowUpdated">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:TemplateField HeaderText="Product" SortExpression="ProductName">
            <EditItemTemplate>
                <asp:TextBox ID="EditProductName" runat="server"
                    Text='<%# Bind("ProductName") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    ControlToValidate="EditProductName"
                    ErrorMessage="You must enter a product name."
                    runat="server">*</asp:RequiredFieldValidator>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server"
                    Text='<%# Bind("ProductName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Category" SortExpression="CategoryName">
            <EditItemTemplate>
                <asp:DropDownList ID="EditCategoryID" runat="server"
                    DataSourceID="CategoriesDataSource" AppendDataBoundItems="true"
                    DataTextField="CategoryName" DataValueField="CategoryID"
                    SelectedValue='<%# Bind("CategoryID") %>'>
                    <asp:ListItem Value=">(None)</asp:ListItem>
                </asp:DropDownList><asp:ObjectDataSource ID="CategoriesDataSource"
                    runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetCategories" TypeName="CategoriesBLL">
                </asp:ObjectDataSource>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server"
                    Text='<%# Bind("CategoryName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier" SortExpression="SupplierName">
            <EditItemTemplate>
                <asp:DropDownList ID="EditSuppliersID" runat="server"
                    DataSourceID="SuppliersDataSource" AppendDataBoundItems="true"
                    DataTextField="CompanyName" DataValueField="SupplierID"
                    SelectedValue='<%# Bind("SupplierID") %>'>
                    <asp:ListItem Value=">(None)</asp:ListItem>
                </asp:DropDownList><asp:ObjectDataSource ID="SuppliersDataSource"
                    runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetSuppliers" TypeName="SuppliersBLL">
                </asp:ObjectDataSource>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server"
                    Text='<%# Bind("SupplierName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit"
            SortExpression="QuantityPerUnit" />
        <asp:TemplateField HeaderText="Price" SortExpression="UnitPrice">
            <EditItemTemplate>
                <asp:TextBox ID="EditUnitPrice" runat="server"
                    Text='<%# Bind("UnitPrice", "{0:N2}") %>' Columns="8" />
                <asp:CompareValidator ID="CompareValidator1" runat="server"
                    ControlToValidate="EditUnitPrice"
                    ErrorMessage="Unit price must be a valid currency value without the
                    currency symbol and must have a value greater than or equal to zero."
                    Operator="GreaterThanEqual" Type="Currency"
                    ValueToCompare="0">*</asp:CompareValidator>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label4" runat="server"
                    Text='<%# Bind("UnitPrice", "{0:C}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Units In Stock" SortExpression="UnitsInStock">
            <EditItemTemplate>
                <asp:TextBox ID="EditUnitsInStock" runat="server"
                    Text='<%# Bind("UnitsInStock") %>' Columns="6"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator2" runat="server"
                    ControlToValidate="EditUnitsInStock"
                    ErrorMessage="Units in stock must be a valid number
                        greater than or equal to zero."
                    Operator="GreaterThanEqual" Type="Integer"
                    ValueToCompare="0">*</asp:CompareValidator>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server"
                    Text='<%# Bind("UnitsInStock", "{0:N0}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Units On Order" SortExpression="UnitsOnOrder">
            <EditItemTemplate>
                <asp:TextBox ID="EditUnitsOnOrder" runat="server"
                    Text='<%# Bind("UnitsOnOrder") %>' Columns="6"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator3" runat="server"
                    ControlToValidate="EditUnitsOnOrder"
                    ErrorMessage="Units on order must be a valid numeric value
                        greater than or equal to zero."
                    Operator="GreaterThanEqual" Type="Integer"
                    ValueToCompare="0">*</asp:CompareValidator>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server"
                    Text='<%# Bind("UnitsOnOrder", "{0:N0}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reorder Level" SortExpression="ReorderLevel">
            <EditItemTemplate>
                <asp:TextBox ID="EditReorderLevel" runat="server"
                    Text='<%# Bind("ReorderLevel") %>' Columns="6"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator4" runat="server"
                    ControlToValidate="EditReorderLevel"
                    ErrorMessage="Reorder level must be a valid numeric value
                        greater than or equal to zero."
                    Operator="GreaterThanEqual" Type="Integer"
                    ValueToCompare="0">*</asp:CompareValidator>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label7" runat="server"
                    Text='<%# Bind("ReorderLevel", "{0:N0}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued"
            SortExpression="Discontinued" />
    </Columns>
</asp:GridView>