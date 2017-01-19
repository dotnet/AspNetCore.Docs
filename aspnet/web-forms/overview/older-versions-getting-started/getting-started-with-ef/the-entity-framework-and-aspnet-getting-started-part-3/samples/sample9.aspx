<h2>Find Students by Name</h2>
    Enter any part of the name
    <asp:TextBox ID="SearchTextBox" runat="server" AutoPostBack="true"></asp:TextBox>
     <asp:Button ID="SearchButton" runat="server" Text="Search" />
    <br />
    <br />
    <asp:EntityDataSource ID="SearchEntityDataSource" runat="server" 
        ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
        EntitySetName="People"
        Where="it.EnrollmentDate is not null and (it.FirstMidName Like '%' + @StudentName + '%' or it.LastName Like '%' + @StudentName + '%')" >
        <WhereParameters>
            <asp:ControlParameter ControlID="SearchTextBox" Name="StudentName" PropertyName="Text" 
             Type="String" DefaultValue="%"/>
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:GridView ID="SearchGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="PersonID"
        DataSourceID="SearchEntityDataSource" AllowPaging="true">
        <Columns>
            <asp:TemplateField HeaderText="Name" SortExpression="LastName, FirstMidName">
                <ItemTemplate>
                    <asp:Label ID="LastNameFoundLabel" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>, 
                    <asp:Label ID="FirstNameFoundLabel" runat="server" Text='<%# Eval("FirstMidName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Enrollment Date" SortExpression="EnrollmentDate">
                <ItemTemplate>
                    <asp:Label ID="EnrollmentDateFoundLabel" runat="server" Text='<%# Eval("EnrollmentDate", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>