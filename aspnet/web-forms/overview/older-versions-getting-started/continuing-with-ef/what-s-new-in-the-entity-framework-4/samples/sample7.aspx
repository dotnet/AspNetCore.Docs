<h2>Alumni</h2>
    <asp:EntityDataSource ID="AlumniEntityDataSource" runat="server" 
        ContextTypeName="ContosoUniversity.DAL.AlumniAssociationModelContainer" EnableFlattening="False" 
        EntitySetName="Alumni">
    </asp:EntityDataSource>
    <asp:GridView ID="AlumniGridView" runat="server" 
        DataSourceID="AlumniEntityDataSource" AutoGenerateColumns="False"
        OnRowDataBound="AlumniGridView_RowDataBound"
        DataKeyNames="AlumnusId">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:TemplateField HeaderText="Donations">
                <ItemTemplate>
                    <asp:GridView ID="DonationsGridView" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="DateAndAmount" HeaderText="Date and Amount" />
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>