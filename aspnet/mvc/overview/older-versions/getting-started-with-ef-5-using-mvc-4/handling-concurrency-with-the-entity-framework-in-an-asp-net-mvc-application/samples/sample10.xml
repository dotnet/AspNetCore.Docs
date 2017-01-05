@model ContosoUniversity.Models.Department

@{
    ViewBag.Title = "Edit";
}

<h2>Edit</h2>

@using (Html.BeginForm()) {
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(true)

    <fieldset>
        <legend>Department</legend>

        @Html.HiddenFor(model => model.DepartmentID)
        @Html.HiddenFor(model => model.RowVersion)

        <div class="editor-label">
            @Html.LabelFor(model => model.Name)
        </div>