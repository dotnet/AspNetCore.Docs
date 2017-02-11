<asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false"
                    IncludeStyleBlock="false" Orientation="Horizontal">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Home" />
                        <asp:MenuItem NavigateUrl="~/About.aspx" Text="About" />
                        <asp:MenuItem NavigateUrl="~/Students.aspx" Text="Students">
                            <asp:MenuItem NavigateUrl="~/StudentsAdd.aspx" Text="Add Students" />
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Courses.aspx" Text="Courses">
                            <asp:MenuItem NavigateUrl="~/CoursesAdd.aspx" Text="Add Courses" />
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Instructors.aspx" Text="Instructors">
                            <asp:MenuItem NavigateUrl="~/InstructorsCourses.aspx" Text="Course Assignments" />
                            <asp:MenuItem NavigateUrl="~/OfficeAssignments.aspx" Text="Office Assignments" />
                        </asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Departments.aspx" Text="Departments">
                            <asp:MenuItem NavigateUrl="~/DepartmentsAdd.aspx" Text="Add Departments" />
                        </asp:MenuItem>
                    </Items>
                </asp:Menu>