<asp:Panel runat="server" ID="ProductsBySupplierPanel" Visible="False">
    <h3>
        Products for the Selected Supplier</h3>
    <p>
        <asp:GridView ID="ProductsBySupplier" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ProductsBySupplierDataSource" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" 
                    SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" 
                    ReadOnly="True" SortExpression="CategoryName" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" 
                    HeaderText="Price" HtmlEncode="False" 
                    SortExpression="UnitPrice" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ProductsBySupplierDataSource" runat="server" 
            OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProductsBySupplierID" TypeName="ProductsBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="Suppliers" Name="supplierID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Panel>