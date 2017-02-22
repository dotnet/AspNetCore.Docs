@{
// Specify what fields users must fill in.
Validation.RequireFields("course", "professorname", "credits");
// Add validation criteria.  Here, require that input to Credits is an integer.
Validation.Add("credits", Validator.Integer());

if (IsPost)  {
// Wrap the postback code with a validation check.
if (Validation.IsValid()) {
	var course = Request["course"];
	var professorName = Request["professorname"];
	var credits = Request["credits"];
	// Display valid input values.
	<text>
		You entered: <br />
		Class: @course <br />
		Professor: @professorName <br />
		Credits: @credits <br />
	</text>
}
}
}
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8" />
<title>Testing Validation in ASP.NET Web Pages version 2</title>
<script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.6.2.js"></script>
<script  src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.8.1/jquery.validate.min.js"></script>
<script src="@Href("~/Scripts/jquery.validate.unobtrusive.min.js")"></script>
</head>
<body>
<form method="post" action="">
<!-- Display a summary message about any validation issues. -->
@Html.ValidationSummary()
<fieldset>
  <legend>Add Class</legend>
<div>
  <label for="Course">Class:</label>
  <!-- Validation.For("course") adds validation attributes to the input element. -->
  <input type="text" name="Course" value="@Request["course"]"  @Validation.For("course") />

  <!-- Display a field-specific message about validation issues. -->
  @Html.ValidationMessage("course")
</div>

<div>
  <label for="ProfessorName">Professor:</label>
  <input type="text" name="ProfessorName" value="@Request["professorname"]"
	  @Validation.For("professorname") />
  @Html.ValidationMessage("professorname")
</div>

<div>
  <label for="Credits">Credits:</label>
  <input type="text" name="Credits" value="@Request["credits"]" @Validation.For("credits") />
  @Html.ValidationMessage("credits")
</div>

<div>
  <label>&nbsp;</label>
  <input type="submit" value="Submit" class="submit" />
</div>
  </fieldset>
</form>
</body>
</html>