@model ContosoUniversity.Models.Instructor

@{
    ViewBag.Title = "Edit";
}

<h2>Edit</h2>

@using (Html.BeginForm())
{
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(true)

    <fieldset>
        <legend>Instructor</legend>

        @Html.HiddenFor(model => model.InstructorID)

        <div class="editor-label">
            @Html.LabelFor(model => model.LastName)
        </div>
        <div class="editor-field">
            @Html.EditorFor(model => model.LastName)
            @Html.ValidationMessageFor(model => model.LastName)
        </div>

        <div class="editor-label">
            @Html.LabelFor(model => model.FirstMidName)
        </div>
        <div class="editor-field">
            @Html.EditorFor(model => model.FirstMidName)
            @Html.ValidationMessageFor(model => model.FirstMidName)
        </div>

        <div class="editor-label">
            @Html.LabelFor(model => model.HireDate)
        </div>
        <div class="editor-field">
            @Html.EditorFor(model => model.HireDate)
            @Html.ValidationMessageFor(model => model.HireDate)
        </div>

        <div class="editor-label">
            @Html.LabelFor(model => model.OfficeAssignment.Location)
        </div>
        <div class="editor-field">
            @Html.EditorFor(model => model.OfficeAssignment.Location)
            @Html.ValidationMessageFor(model => model.OfficeAssignment.Location)
        </div>

        <div class="editor-field">
    <table>
        <tr>
            @{
                int cnt = 0;
                List<ContosoUniversity.ViewModels.AssignedCourseData> courses = ViewBag.Courses;

                foreach (var course in courses) {
                    if (cnt++ % 3 == 0) {
                        @:  </tr> <tr> 
                    }
                    @: <td> 
                        <input type="checkbox" 
                               name="selectedCourses" 
                               value="@course.CourseID" 
                               @(Html.Raw(course.Assigned ? "checked=\"checked\"" : "")) /> 
                        @course.CourseID @:  @course.Title
                    @:</td>
                }
                @: </tr>
            }
    </table>
</div>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
}

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
}