<asp:GridView ID="SearchGridView" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="CourseID" DataSourceID="SearchEntityDataSource"  AllowPaging="true">
        <Columns>
            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Department.Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CourseID" HeaderText="ID"/>
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Credits" HeaderText="Credits" />
        </Columns>
    </asp:GridView>