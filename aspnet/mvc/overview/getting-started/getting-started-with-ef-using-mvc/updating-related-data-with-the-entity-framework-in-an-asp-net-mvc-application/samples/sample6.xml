@model ContosoUniversity.Models.Course

@{
    ViewBag.Title = "Create";
}

<h2>Create</h2>

@using (Html.BeginForm()) 
{
    @Html.AntiForgeryToken()
    
    <div class="form-horizontal">
        <h4>Course</h4>
        <hr />
        @Html.ValidationSummary(true)

        <div class="form-group">
            @Html.LabelFor(model => model.CourseID, new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.CourseID)
                @Html.ValidationMessageFor(model => model.CourseID)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Title, new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Title)
                @Html.ValidationMessageFor(model => model.Title)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(model => model.Credits, new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.Credits)
                @Html.ValidationMessageFor(model => model.Credits)
            </div>
        </div>

        <div class="form-group">
            <label class="control-label col-md-2" for="DepartmentID">Department</label>
            <div class="col-md-10">
                @Html.DropDownList("DepartmentID", String.Empty)
                @Html.ValidationMessageFor(model => model.DepartmentID)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
}

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
}