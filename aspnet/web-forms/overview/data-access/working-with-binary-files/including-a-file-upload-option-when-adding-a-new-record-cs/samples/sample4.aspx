<asp:DetailsView ID="NewCategory" runat="server" AutoGenerateRows="False" 
    DataKeyNames="CategoryID" DataSourceID="CategoriesDataSource" 
    DefaultMode="Insert">
    <Fields>
        <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
            InsertVisible="False" ReadOnly="True" 
            SortExpression="CategoryID" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category" 
            SortExpression="CategoryName" />
        <asp:BoundField DataField="Description" HeaderText="Description" 
            SortExpression="Description" />
        <asp:TemplateField HeaderText="Brochure" SortExpression="BrochurePath">
            <InsertItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server"
                    Text='<%# Bind("BrochurePath") %>'></asp:TextBox>
            </InsertItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Picture"></asp:TemplateField>
        <asp:CommandField ShowInsertButton="True" />
    </Fields>
</asp:DetailsView>