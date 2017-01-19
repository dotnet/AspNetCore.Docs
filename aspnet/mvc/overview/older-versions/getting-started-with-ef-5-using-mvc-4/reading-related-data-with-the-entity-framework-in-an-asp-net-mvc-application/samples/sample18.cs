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
                @Html.DisplayFor(modelItem => item.HireDate)
            </td> 
            <td> 
                @if (item.OfficeAssignment != null) 
                { 
                    @item.OfficeAssignment.Location  
                } 
            </td> 
        </tr> 
    } 
</table>