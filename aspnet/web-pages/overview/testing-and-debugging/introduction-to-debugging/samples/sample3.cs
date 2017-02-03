var weekday = DateTime.Now.DayOfWeek;
// DEBUG: Display the initial value of weekday. 
@weekday

// As a test, add 1 day to the current weekday.
if(weekday.ToString() != "Saturday") {
	// If weekday is not Saturday, simply add one day.
	weekday = weekday + 1; 
}
else {
	// If weekday is Saturday, reset the day to 0, or Sunday.
	weekday = 0; 
}

// DEBUG: Display the updated test value of weekday.
@weekday

// Convert weekday to a string value for the switch statement.
var weekdayText = weekday.ToString();