---
title: "Getting Started with Entity Framework 4.0 Database First and ASP.NET 4 Web Forms - Part 4 | Microsoft Docs"
author: tdykstra
description: "The Contoso University sample web application demonstrates how to create ASP.NET Web Forms applications using the Entity Framework. The sample application is..."
ms.author: riande
manager: wpickett
ms.date: 12/03/2010
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/older-versions-getting-started/getting-started-with-ef/the-entity-framework-and-aspnet-getting-started-part-4
---
Getting Started with Entity Framework 4.0 Database First and ASP.NET 4 Web Forms - Part 4
====================
by [Tom Dykstra](https://github.com/tdykstra)

> The Contoso University sample web application demonstrates how to create ASP.NET Web Forms applications using the Entity Framework 4.0 and Visual Studio 2010. For information about the tutorial series, see [the first tutorial in the series](the-entity-framework-and-aspnet-getting-started-part-1.md)


## Working with Related Data

In the previous tutorial you used the `EntityDataSource` control to filter, sort, and group data. In this tutorial you'll display and update related data.

You'll create the Instructors page that shows a list of instructors. When you select an instructor, you see a list of courses taught by that instructor. When you select a course, you see details for the course and a list of students enrolled in the course. You can edit the instructor name, hire date, and office assignment. The office assignment is a separate entity set that you access through a navigation property.

You can link master data to detail data in markup or in code. In this part of the tutorial, you'll use both methods.

[![Image01](the-entity-framework-and-aspnet-getting-started-part-4/_static/image2.png)](the-entity-framework-and-aspnet-getting-started-part-4/_static/image1.png)

## Displaying and Updating Related Entities in a GridView Control

Create a new web page named *Instructors.aspx* that uses the *Site.Master* master page, and add the following markup to the `Content` control named `Content2`:

    <h2>Instructors</h2>
        <div>
            <asp:EntityDataSource ID="InstructorsEntityDataSource" runat="server" 
                ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
                EntitySetName="People"
                Where="it.HireDate is not null" Include="OfficeAssignment" EnableUpdate="True">
            </asp:EntityDataSource>
        </div>

This markup creates an `EntityDataSource` control that selects instructors and enables updates. The `div` element configures markup to render on the left so that you can add a column on the right later.

Between the `EntityDataSource` markup and the closing `</div>` tag, add the following markup that creates a `GridView` control and a `Label` control that you'll use for error messages:

    <asp:GridView ID="InstructorsGridView" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" DataKeyNames="PersonID" DataSourceID="InstructorsEntityDataSource"
                OnSelectedIndexChanged="InstructorsGridView_SelectedIndexChanged" 
                SelectedRowStyle-BackColor="LightGray" 
                onrowupdating="InstructorsGridView_RowUpdating">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ShowEditButton="True" />
                    <asp:TemplateField HeaderText="Name" SortExpression="LastName">
                        <ItemTemplate>
                            <asp:Label ID="InstructorLastNameLabel" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>,
                            <asp:Label ID="InstructorFirstNameLabel" runat="server" Text='<%# Eval("FirstMidName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="InstructorLastNameTextBox" runat="server" Text='<%# Bind("FirstMidName") %>' Width="7em"></asp:TextBox>
                            <asp:TextBox ID="InstructorFirstNameTextBox" runat="server" Text='<%# Bind("LastName") %>' Width="7em"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hire Date" SortExpression="HireDate">
                        <ItemTemplate>
                            <asp:Label ID="InstructorHireDateLabel" runat="server" Text='<%# Eval("HireDate", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="InstructorHireDateTextBox" runat="server" Text='<%# Bind("HireDate", "{0:d}") %>' Width="7em"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Office Assignment" SortExpression="OfficeAssignment.Location">
                        <ItemTemplate>
                            <asp:Label ID="InstructorOfficeLabel" runat="server" Text='<%# Eval("OfficeAssignment.Location") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="InstructorOfficeTextBox" runat="server" 
                            Text='<%# Eval("OfficeAssignment.Location") %>' Width="7em"
                            oninit="InstructorOfficeTextBox_Init"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="LightGray"></SelectedRowStyle>
            </asp:GridView>
            <asp:Label ID="ErrorMessageLabel" runat="server" Text="" Visible="false" ViewStateMode="Disabled"></asp:Label>

This `GridView` control enables row selection, highlights the selected row with a light gray background color, and specifies handlers (which you'll create later) for the `SelectedIndexChanged` and `Updating` events. It also specifies `PersonID` for the `DataKeyNames` property, so that the key value of the selected row can be passed to another control that you'll add later.

The last column contains the instructor's office assignment, which is stored in a navigation property of the `Person` entity because it comes from an associated entity. Notice that the `EditItemTemplate` element specifies `Eval` instead of `Bind`, because the `GridView` control cannot directly bind to navigation properties in order to update them. You'll update the office assignment in code. To do that, you'll need a reference to the `TextBox` control, and you'll get and save that in the `TextBox` control's `Init` event.

Following the `GridView` control is a `Label` control that's used for error messages. The control's `Visible` property is `false`, and view state is turned off, so that the label will appear only when code makes it visible in response to an error.

Open the *Instructors.aspx.cs* file and add the following `using` statement:

    using ContosoUniversity.DAL;

Add a private class field immediately after the partial-class name declaration to hold a reference to the office assignment text box.

    private TextBox instructorOfficeTextBox;

Add a stub for the `SelectedIndexChanged` event handler that you'll add code for later. Also add a handler for the office assignment `TextBox` control's `Init` event so that you can store a reference to the `TextBox` control. You'll use this reference to get the value the user entered in order to update the entity associated with the navigation property.

    protected void InstructorsGridView_SelectedIndexChanged(object sender, EventArgs e)
            {
            }
    
            protected void InstructorOfficeTextBox_Init(object sender, EventArgs e)
            {
                instructorOfficeTextBox = sender as TextBox;
            }

You'll use the `GridView` control's `Updating` event to update the `Location` property of the associated `OfficeAssignment` entity. Add the following handler for the `Updating` event:

    protected void InstructorsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                using (var context = new SchoolEntities())
                {
                    var instructorBeingUpdated = Convert.ToInt32(e.Keys[0]);
                    var officeAssignment = (from o in context.OfficeAssignments
                                            where o.InstructorID == instructorBeingUpdated
                                            select o).FirstOrDefault();
    
                    try
                    {
                        if (String.IsNullOrWhiteSpace(instructorOfficeTextBox.Text) == false)
                        {
                            if (officeAssignment == null)
                            {
                                context.OfficeAssignments.AddObject(OfficeAssignment.CreateOfficeAssignment(instructorBeingUpdated, instructorOfficeTextBox.Text, null));
                            }
                            else
                            {
                                officeAssignment.Location = instructorOfficeTextBox.Text;
                            }
                        }
                        else
                        {
                            if (officeAssignment != null)
                            {
                                context.DeleteObject(officeAssignment);
                            }
                        }
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        e.Cancel = true;
                        ErrorMessageLabel.Visible = true;
                        ErrorMessageLabel.Text = "Update failed.";
                        //Add code to log the error.
                    }
                }
            }

This code is run when the user clicks **Update** in a `GridView` row. The code uses LINQ to Entities to retrieve the `OfficeAssignment` entity that's associated with the current `Person` entity, using the `PersonID` of the selected row from the event argument.

The code then takes one of the following actions depending on the value in the `InstructorOfficeTextBox` control:

- If the text box has a value and there's no `OfficeAssignment` entity to update, it creates one.
- If the text box has a value and there's an `OfficeAssignment` entity, it updates the `Location` property value.
- If the text box is empty and an `OfficeAssignment` entity exists, it deletes the entity.

After this, it saves the changes to the database. If an exception occurs, it displays an error message.

Run the page.

[![Image02](the-entity-framework-and-aspnet-getting-started-part-4/_static/image4.png)](the-entity-framework-and-aspnet-getting-started-part-4/_static/image3.png)

Click **Edit** and all fields change to text boxes.

[![Image03](the-entity-framework-and-aspnet-getting-started-part-4/_static/image6.png)](the-entity-framework-and-aspnet-getting-started-part-4/_static/image5.png)

Change any of these values, including **Office Assignment**. Click **Update** and you'll see the changes reflected in the list.

## Displaying Related Entities in a Separate Control

Each instructor can teach one or more courses, so you'll add an `EntityDataSource` control and a `GridView` control to list the courses associated with whichever instructor is selected in the instructors `GridView` control. To create a heading and the `EntityDataSource` control for courses entities, add the following markup between the error message `Label` control and the closing `</div>` tag:

    <h3>Courses Taught</h3>
            <asp:EntityDataSource ID="CoursesEntityDataSource" runat="server" 
                ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
                EntitySetName="Courses" 
                Where="@PersonID IN (SELECT VALUE instructor.PersonID FROM it.People AS instructor)">
                <WhereParameters>
                    <asp:ControlParameter ControlID="InstructorsGridView" Type="Int32" Name="PersonID" PropertyName="SelectedValue" />
                </WhereParameters>
            </asp:EntityDataSource>

The `Where` parameter contains the value of the `PersonID` of the instructor whose row is selected in the `InstructorsGridView` control. The `Where` property contains a subselect command that gets all associated `Person` entities from a `Course` entity's `People` navigation property and selects the `Course` entity only if one of the associated `Person` entities contains the selected `PersonID` value.

To create the `GridView` control., add the following markup immediately following the `CoursesEntityDataSource` control (before the closing `</div>` tag):

    <asp:GridView ID="CoursesGridView" runat="server" 
                DataSourceID="CoursesEntityDataSource"
                AllowSorting="True" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="LightGray" 
                DataKeyNames="CourseID">
                <EmptyDataTemplate>
                    <p>No courses found.</p>
                </EmptyDataTemplate>
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="CourseID" HeaderText="ID" ReadOnly="True" SortExpression="CourseID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:TemplateField HeaderText="Department" SortExpression="DepartmentID">
                        <ItemTemplate>
                            <asp:Label ID="GridViewDepartmentLabel" runat="server" Text='<%# Eval("Department.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

Because no courses will be displayed if no instructor is selected, an `EmptyDataTemplate` element is included.

Run the page.

[![Image04](the-entity-framework-and-aspnet-getting-started-part-4/_static/image8.png)](the-entity-framework-and-aspnet-getting-started-part-4/_static/image7.png)

Select an instructor who has one or more courses assigned, and the course or courses appear in the list. (Note: although the database schema allows multiple courses, in the test data supplied with the database no instructor actually has more than one course. You can add courses to the database yourself using the **Server Explorer** window or the *CoursesAdd.aspx* page, which you'll add in a later tutorial.)

[![Image05](the-entity-framework-and-aspnet-getting-started-part-4/_static/image10.png)](the-entity-framework-and-aspnet-getting-started-part-4/_static/image9.png)

The `CoursesGridView` control shows only a few course fields. To display all the details for a course, you'll use a `DetailsView` control for the course that the user selects. In *Instructors.aspx*, add the following markup after the closing `</div>` tag (make sure you place this markup **after** the closing div tag, not before it):

    <div>
            <h3>Course Details</h3>
            <asp:EntityDataSource ID="CourseDetailsEntityDataSource" runat="server" 
                ContextTypeName="ContosoUniversity.DAL.SchoolEntities" EnableFlattening="False" 
                EntitySetName="Courses"
                AutoGenerateWhereClause="False" Where="it.CourseID = @CourseID" Include="Department,OnlineCourse,OnsiteCourse,StudentGrades.Person"
                OnSelected="CourseDetailsEntityDataSource_Selected">
                <WhereParameters>
                    <asp:ControlParameter ControlID="CoursesGridView" Type="Int32" Name="CourseID" PropertyName="SelectedValue" />
                </WhereParameters>
            </asp:EntityDataSource>
            <asp:DetailsView ID="CourseDetailsView" runat="server" AutoGenerateRows="False"
                DataSourceID="CourseDetailsEntityDataSource">
                <EmptyDataTemplate>
                    <p>
                        No course selected.</p>
                </EmptyDataTemplate>
                <Fields>
                    <asp:BoundField DataField="CourseID" HeaderText="ID" ReadOnly="True" SortExpression="CourseID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
                    <asp:TemplateField HeaderText="Department">
                        <ItemTemplate>
                            <asp:Label ID="DetailsViewDepartmentLabel" runat="server" Text='<%# Eval("Department.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Location">
                        <ItemTemplate>
                            <asp:Label ID="LocationLabel" runat="server" Text='<%# Eval("OnsiteCourse.Location") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="URL">
                        <ItemTemplate>
                            <asp:Label ID="URLLabel" runat="server" Text='<%# Eval("OnlineCourse.URL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </div>

This markup creates an `EntityDataSource` control that's bound to the `Courses` entity set. The `Where` property selects a course using the `CourseID` value of the selected row in the courses `GridView` control. The markup specifies a handler for the `Selected` event, which you'll use later for displaying student grades, which is another level lower in the hierarchy.

In *Instructors.aspx.cs*, create the following stub for the `CourseDetailsEntityDataSource_Selected` method. (You'll fill this stub out later in the tutorial; for now, you need it so that the page will compile and run.)

    protected void CourseDetailsEntityDataSource_Selected(object sender, EntityDataSourceSelectedEventArgs e)
            {
            }

Run the page.

[![Image06](the-entity-framework-and-aspnet-getting-started-part-4/_static/image12.png)](the-entity-framework-and-aspnet-getting-started-part-4/_static/image11.png)

Initially there are no course details because no course is selected. Select an instructor who has a course assigned, and then select a course to see the details.

[![Image07](the-entity-framework-and-aspnet-getting-started-part-4/_static/image14.png)](the-entity-framework-and-aspnet-getting-started-part-4/_static/image13.png)

## Using the EntityDataSource "Selected" Event to Display Related Data

Finally, you want to show all of the enrolled students and their grades for the selected course. To do this, you'll use the `Selected` event of the `EntityDataSource` control bound to the course `DetailsView`.

In *Instructors.aspx*, add the following markup after the `DetailsView` control:

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

This markup creates a `ListView` control that displays a list of students and their grades for the selected course. No data source is specified because you'll databind the control in code. The `EmptyDataTemplate` element provides a message to display when no course is selected—in that case, there are no students to display. The `LayoutTemplate` element creates an HTML table to display the list, and the `ItemTemplate` specifies the columns to display. The student ID and the student grade are from the `StudentGrade` entity, and the student name is from the `Person` entity that the Entity Framework makes available in the `Person` navigation property of the `StudentGrade` entity.

In *Instructors.aspx.cs*, replace the stubbed-out `CourseDetailsEntityDataSource_Selected` method with the following code:

    protected void CourseDetailsEntityDataSource_Selected(object sender, EntityDataSourceSelectedEventArgs e)
            {
                var course = e.Results.Cast<Course>().FirstOrDefault();
                if (course != null)
                {
                    var studentGrades = course.StudentGrades.ToList();
                    GradesListView.DataSource = studentGrades;
                    GradesListView.DataBind();
                }
            }

The event argument for this event provides the selected data in the form of a collection, which will have zero items if nothing is selected or one item if a `Course` entity is selected. If a `Course` entity is selected, the code uses the `First` method to convert the collection to a single object. It then gets `StudentGrade` entities from the navigation property, converts them to a collection, and binds the `GradesListView` control to the collection.

This is sufficient to display grades, but you want to make sure that the message in the empty data template is displayed the first time the page is displayed and whenever a course is not selected. To do that, create the following method, which you'll call from two places:

    private void ClearStudentGradesDataSource()
            {
                var emptyStudentGradesList = new List<StudentGrade>();
                GradesListView.DataSource = emptyStudentGradesList;
                GradesListView.DataBind();
            }

Call this new method from the `Page_Load` method to display the empty data template the first time the page is displayed. And call it from the `InstructorsGridView_SelectedIndexChanged` method because that event is raised when an instructor is selected, which means new courses are loaded into the courses `GridView` control and none is selected yet. Here are the two calls:

    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ClearStudentGradesDataSource();                
                }
            }

    protected void InstructorsGridView_SelectedIndexChanged(object sender, EventArgs e)
            {
                ClearStudentGradesDataSource();
            }

Run the page.

[![Image08](the-entity-framework-and-aspnet-getting-started-part-4/_static/image16.png)](the-entity-framework-and-aspnet-getting-started-part-4/_static/image15.png)

Select an instructor that has a course assigned, and then select the course.

[![Image09](the-entity-framework-and-aspnet-getting-started-part-4/_static/image18.png)](the-entity-framework-and-aspnet-getting-started-part-4/_static/image17.png)

You have now seen a few ways to work with related data. In the following tutorial, you'll learn how to add relationships between existing entities, how to remove relationships, and how to add a new entity that has a relationship to an existing entity.

>[!div class="step-by-step"] [Previous](the-entity-framework-and-aspnet-getting-started-part-3.md) [Next](the-entity-framework-and-aspnet-getting-started-part-5.md)