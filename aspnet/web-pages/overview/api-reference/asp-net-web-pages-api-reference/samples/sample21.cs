// Call the method directly to disable validation on the specified item from
// one of the Request collections.
Request.Unvalidated("userText");

// You can optionally specify which collection the value is from.
var prodID = Request.Unvalidated().QueryString["productID"];
var richtextValue = Request.Unvalidated().Form["richTextBox1"];
var cookie = Request.Unvalidated().Cookies["mostRecentVisit"];