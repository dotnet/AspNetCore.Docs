<EditItemTemplate>
    <h4>
        <asp:Label ID="ProductNameLabel" runat="server"
            Text='<%# Eval("ProductName") %>' />
    </h4>
    <table border="0">
        <tr>
            <td class="ProductPropertyLabel">Name:</td>
            <td colspan="3" class="ProductPropertyValue">
                <asp:TextBox runat="server" ID="ProductName" Width="90%" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    ControlToValidate="ProductName"
                    ErrorMessage="You must enter a name for the product."
                    runat="server">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="ProductPropertyLabel">Category:</td>
            <td class="ProductPropertyValue">
                <asp:DropDownList ID="Categories" runat="server"
                    DataSourceID="CategoriesDataSource"
                    DataTextField="CategoryName" DataValueField="CategoryID" />
            </td>
            <td class="ProductPropertyLabel">Supplier:</td>
            <td class="ProductPropertyValue">
                <asp:DropDownList ID="Suppliers"
                    DataSourceID="SuppliersDataSource" DataTextField="CompanyName"
                    DataValueField="SupplierID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="ProductPropertyLabel">Discontinued:</td>
            <td class="ProductPropertyValue">
                <asp:CheckBox runat="server" id="Discontinued" />
            </td>
            <td class="ProductPropertyLabel">Price:</td>
            <td class="ProductPropertyValue">
                <asp:Label ID="UnitPriceLabel" runat="server"
                    Text='<%# Eval("UnitPrice", "{0:C}") %>' />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button runat="Server" ID="UpdateButton" CommandName="Update"
                    Text="Update" />
                 
                <asp:Button runat="Server" ID="CancelButton" CommandName="Cancel"
                    Text="Cancel" CausesValidation="False" />
            </td>
        </tr>
    </table>
    <br />
    <asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategories"
        TypeName="CategoriesBLL">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SuppliersDataSource" runat="server"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetSuppliers"
        TypeName="SuppliersBLL">
    </asp:ObjectDataSource>
</EditItemTemplate>