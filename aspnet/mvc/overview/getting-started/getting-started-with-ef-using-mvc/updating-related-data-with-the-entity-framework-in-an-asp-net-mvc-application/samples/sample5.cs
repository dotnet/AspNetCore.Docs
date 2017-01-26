catch (RetryLimitExceededException /* dex */)
{
	//Log the error (uncomment dex variable name and add a line here to write a log.)
	ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
}
PopulateDepartmentsDropDownList(course.DepartmentID);
return View(course);