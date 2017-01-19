<asp:Label ID="ODSEvents" runat="server" EnableViewState="False" />
<asp:GridView ID="ProductsDeclarative" runat="server" 
    AutoGenerateColumns="False" DataKeyNames="ProductID" 
    DataSourceID="ProductsDataSourceDeclarative" 
    AllowPaging="True" AllowSorting="True">
    <Columns>
        <asp:CommandField ShowEditButton="True" />
        <asp:TemplateField HeaderText="Product" SortExpression="ProductName">
            <EditItemTemplate>
                <asp:TextBox ID="ProductName" runat="server" 
                    Text='<%# Bind("ProductName") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                    ControlToValidate="ProductName" Display="Dynamic" 
                    ErrorMessage="You must provide a name for the product." 
                    SetFocusOnError="True"
                    runat="server">*</asp:RequiredFieldValidator>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" 
                    Text='<%# Bind("ProductName") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="CategoryName" HeaderText="Category" 
            ReadOnly="True" SortExpression="CategoryName" />
        <asp:TemplateField HeaderText="Price" SortExpression="UnitPrice">
            <EditItemTemplate>
                $<asp:TextBox ID="UnitPrice" runat="server" Columns="8" 
                    Text='<%# Bind("UnitPrice", "{0:N2}") %>'></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="UnitPrice"
                    ErrorMessage="You must enter a valid currency value with 
                        no currency symbols. Also, the value must be greater than 
                        or equal to zero."
                    Operator="GreaterThanEqual" SetFocusOnError="True" 
                    Type="Currency" Display="Dynamic" 
                    ValueToCompare="0">*</asp:CompareValidator>
            </EditItemTemplate>
            <ItemStyle HorizontalAlign="Right" />
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" 
                    Text='<%# Bind("UnitPrice", "{0:c}") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ProductsDataSourceDeclarative" runat="server" 
    SelectMethod="GetProducts" TypeName="ProductsBLL" 
    UpdateMethod="UpdateProduct">
    <UpdateParameters>
        <asp:Parameter Name="productName" Type="String" />
        <asp:Parameter Name="unitPrice" Type="Decimal" />
        <asp:Parameter Name="productID" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>