// ... Save user's information to the database ...
...

// Attempt to send the user a confirmation email
try
{
	// ... Send an email ...
}
catch (Exception e)
{
	// Error in sending email. Log it!
	ErrorSignal.FromCurrentContext().Raise(e);
}