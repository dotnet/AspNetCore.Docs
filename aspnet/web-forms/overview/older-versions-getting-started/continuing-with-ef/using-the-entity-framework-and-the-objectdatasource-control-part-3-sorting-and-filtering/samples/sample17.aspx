<asp:TemplateField HeaderText="Courses">
                <ItemTemplate>
                    <asp:GridView ID="CoursesGridView" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="CourseID" HeaderText="ID" />
                            <asp:BoundField DataField="Title" HeaderText="Title" />
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>
            </asp:TemplateField>