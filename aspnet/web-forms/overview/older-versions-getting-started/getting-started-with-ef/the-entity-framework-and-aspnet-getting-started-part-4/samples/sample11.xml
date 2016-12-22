<h3>Student Grades</h3>
        <asp:ListView ID="GradesListView" runat="server">
            <EmptyDataTemplate>
                <p>No student grades found.</p>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table border="1" runat="server" id="itemPlaceholderContainer">
                    <tr runat="server">
                        <th runat="server">
                            Name
                        </th>
                        <th runat="server">
                            Grade
                        </th>
                    </tr>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="StudentLastNameLabel" runat="server" Text='<%# Eval("Person.LastName") %>' />,
                        <asp:Label ID="StudentFirstNameLabel" runat="server" Text='<%# Eval("Person.FirstMidName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="StudentGradeLabel" runat="server" Text='<%# Eval("Grade") %>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>