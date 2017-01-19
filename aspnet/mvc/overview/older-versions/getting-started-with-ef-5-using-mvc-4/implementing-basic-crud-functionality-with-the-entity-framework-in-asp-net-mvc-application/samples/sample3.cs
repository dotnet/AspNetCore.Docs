<div class="display-label">
        @Html.LabelFor(model => model.Enrollments)
    </div>
    <div class="display-field">
        <table>
            <tr>
                <th>Course Title</th>
                <th>Grade</th>
            </tr>
            @foreach (var item in Model.Enrollments)
            {
                <tr>
                    <td>
                        @Html.DisplayFor(modelItem => item.Course.Title)
                    </td>
                    <td>
                        @Html.DisplayFor(modelItem => item.Grade)
                    </td>
                </tr>
            }
        </table>
    </div>
</fieldset>
<p>
    @Html.ActionLink("Edit", "Edit", new { id=Model.StudentID }) |
    @Html.ActionLink("Back to List", "Index")
</p>