@{
    // Note that client validation as implemented here will work only with
    // ASP.NET Web Pages 2.

    var message="";
    // Specify validation requirements for different fields.
    Validation.RequireField("coursename", "Class name is required");
    Validation.RequireField("credits", "Credits is required");
    Validation.Add("coursename", Validator.StringLength(5));
    Validation.Add("credits", Validator.Integer("Credits must be an integer"));
    Validation.Add("credits", Validator.Range(1, 5, "Credits must be between 1 and 5"));
    Validation.Add("startDate", Validator.DateTime("Start date must be a date"));

    if (IsPost)  {
        // Before processing anything, make sure that all user input is valid.
        if (Validation.IsValid()) {
            var coursename = Request["coursename"];
            var credits = Request["credits"].AsInt();
            var startDate = Request["startDate"].AsDateTime();
            message += @"For Class, you entered " + coursename;
            message += @"<br/>For Credits, you entered " + credits.ToString();
            message += @"<br/>For Start Date, you entered " + startDate.ToString("dd-MMM-yyyy");

            // Further processing here
        }
    }
}
<!DOCTYPE html>
<html lang="en">
<head>
  <title>Validation Example with Client Validation</title>
  <style>
      body {margin: 1in; font-family: 'Segoe UI'; font-size: 11pt; }
   </style>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.6.2.js"></script>
    <script
        src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.8.1/jquery.validate.js">
    </script>
    <script src="~/Scripts/jquery.validate.unobtrusive.js"></script>
</head>
<body>
  <h1>Validation Example with Client Validation</h1>
  <p>This example page asks the user to enter information about some classes at school.</p>
  <form method="post">
    @Html.ValidationSummary()
    <div>
      <label for="coursename">Course name: </label>
      <input type="text"
         name="coursename"
         value="@Request["coursename"]"
         @Validation.For("coursename")
      />
      @Html.ValidationMessage("coursename")
    </div>

    <div>
      <label for="credits">Credits: </label>
      <input type="text"
         name="credits"
         value="@Request["credits"]"
         @Validation.For("credits")
      />
      @Html.ValidationMessage("credits")
    </div>

    <div>
      <label for="startDate">Start date: </label>
      <input type="text"
         name="startDate"
         value="@Request["startDate"]"
         @Validation.For("startDate")
      />
      @Html.ValidationMessage("startDate")
    </div>

   <div>
      <input type="submit" value="Submit" class="submit" />
    </div>

    <div>
      @if(IsPost){
        <p>@Html.Raw(message)</p>
      }
    </div>
  </form>
</body>
</html>