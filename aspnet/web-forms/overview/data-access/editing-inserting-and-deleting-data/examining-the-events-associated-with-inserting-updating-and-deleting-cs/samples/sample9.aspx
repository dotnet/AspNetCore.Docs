<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"
    DataKeyNames="ProductID" DataSourceID="ObjectDataSource1">
    <Fields>
        <asp:BoundField DataField="ProductName"
          HeaderText="ProductName" SortExpression="ProductName" />
        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice"
          SortExpression="UnitPrice" />
        <asp:CommandField ShowInsertButton="True" />
    </Fields>
</asp:DetailsView>