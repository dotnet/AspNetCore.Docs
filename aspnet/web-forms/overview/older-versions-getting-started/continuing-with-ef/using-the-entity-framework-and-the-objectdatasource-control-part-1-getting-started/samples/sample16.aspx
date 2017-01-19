<EditItemTemplate>
                    <asp:ObjectDataSource ID="InstructorsObjectDataSource" runat="server" DataObjectTypeName="ContosoUniversity.DAL.InstructorName"
                        SelectMethod="GetInstructorNames" TypeName="ContosoUniversity.DAL.SchoolRepository">
                    </asp:ObjectDataSource>
                    <asp:DropDownList ID="InstructorsDropDownList" runat="server" DataSourceID="InstructorsObjectDataSource"
                        SelectedValue='<%# Eval("Administrator")  %>'
                        DataTextField="FullName" DataValueField="PersonID" OnInit="DepartmentsDropDownList_Init" >
                    </asp:DropDownList>
                </EditItemTemplate>