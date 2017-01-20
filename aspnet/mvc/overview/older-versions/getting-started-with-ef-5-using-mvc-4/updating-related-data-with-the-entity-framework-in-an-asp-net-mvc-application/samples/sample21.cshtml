@model ContosoUniversity.ViewModels.InstructorIndexData

@{
    ViewBag.Title = "Instructors";
}

<h2>Instructors</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th></th>
        <th>Last Name</th>
        <th>First Name</th>
        <th>Hire Date</th>
        <th>Office</th>
        <th>Courses</th>
    </tr>
    @foreach (var item in Model.Instructors)
    {
        string selectedRow = "";
        if (item.InstructorID == ViewBag.InstructorID)
        {
            selectedRow = "selectedrow";
        } 
        <tr class="@selectedRow" valign="top">
            <td>
                @Html.ActionLink("Select", "Index", new { id = item.InstructorID }) | 
                @Html.ActionLink("Edit", "Edit", new { id = item.InstructorID }) | 
                @Html.ActionLink("Details", "Details", new { id = item.InstructorID }) | 
                @Html.ActionLink("Delete", "Delete", new { id = item.InstructorID })
            </td>
            <td>
                @item.LastName
            </td>
            <td>
                @item.FirstMidName
            </td>
            <td>
                @String.Format("{0:d}", item.HireDate)
            </td>
            <td>
                @if (item.OfficeAssignment != null)
                { 
                    @item.OfficeAssignment.Location  
                }
            </td>
            <td>
                @{
                foreach (var course in item.Courses)
                {
                    @course.CourseID @:  @course.Title <br />
                }
                }
            </td>
        </tr> 
    }
</table>

@if (Model.Courses != null)
{ 
    <h3>Courses Taught by Selected Instructor</h3> 
    <table>
        <tr>
            <th></th>
            <th>ID</th>
            <th>Title</th>
            <th>Department</th>
        </tr>

        @foreach (var item in Model.Courses)
        {
            string selectedRow = "";
            if (item.CourseID == ViewBag.CourseID)
            {
                selectedRow = "selectedrow";
            } 
        
            <tr class="@selectedRow">

                <td>
                    @Html.ActionLink("Select", "Index", new { courseID = item.CourseID })
                </td>
                <td>
                    @item.CourseID
                </td>
                <td>
                    @item.Title
                </td>
                <td>
                    @item.Department.Name
                </td>
            </tr> 
        }

    </table> 
}
@if (Model.Enrollments != null)
{ 
    <h3>Students Enrolled in Selected Course</h3> 
    <table>
        <tr>
            <th>Name</th>
            <th>Grade</th>
        </tr>
        @foreach (var item in Model.Enrollments)
        { 
            <tr>
                <td>
                    @item.Student.FullName
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.Grade)
                </td>
            </tr> 
        }
    </table> 
}