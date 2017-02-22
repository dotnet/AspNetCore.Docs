<asp:GridView ID="Products" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="ProductID" DataSourceID="ProductsDataSource" 
    AllowPaging="True" AllowSorting="True">
    <Columns>
        <asp:CommandField ShowEditButton="True" />
        <asp:TemplateField HeaderText="Product" SortExpression="ProductName">
            <EditItemTemplate>
                <asp:TextBox ID="ProductName" runat="server" 
                    Text='<%# Bind("ProductName") %>'></asp:TextBox>
                <asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator1" Display="Dynamic" 
                    ControlToValidate="ProductName" SetFocusOnError="True"
                    ErrorMessage="You must provide a name for the product."
                    runat="server">*</asp:RequiredFieldValidator>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" 
                    Text='<%# Bind("ProductName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="CategoryName" HeaderText="Category" 
            ReadOnly="True" SortExpression="CategoryName" />
        <asp:TemplateField HeaderText="Price" SortExpression="UnitPrice">
            <EditItemTemplate>
                $<asp:TextBox ID="UnitPrice" runat="server" Columns="8" 
                    Text='<%# Bind("UnitPrice", "{0:N2}") %>'></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1"
                    ControlToValidate="UnitPrice" Display="Dynamic" 
                    ErrorMessage="You must enter a valid currency value with no 
                        currency symbols. Also, the value must be greater than 
                        or equal to zero."
                    Operator="GreaterThanEqual" SetFocusOnError="True" 
                    Type="Currency" runat="server" 
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
<asp:ObjectDataSource ID="ProductsDataSource" runat="server"
    OldValuesParameterFormatString="{0}" SelectMethod="GetProducts" 
    TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
    <UpdateParameters>
        <asp:Parameter Name="productName" Type="String" />
        <asp:Parameter Name="unitPrice" Type="Decimal" />
        <asp:Parameter Name="productID" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>