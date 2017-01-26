// ... Save user's information to the database ...
...

// Attempt to send the user a confirmation e-mail
try
{
	// ... Send an e-mail ...
}
catch (Exception e)
{
	// Error in sending e-mail. Log it!
	ErrorSignal.FromCurrentContext().Raise(e);
}