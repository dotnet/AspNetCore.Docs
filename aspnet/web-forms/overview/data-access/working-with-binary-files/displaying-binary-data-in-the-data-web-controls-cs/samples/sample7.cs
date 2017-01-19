if (category.IsPictureNull())
{
    // Display some "No Image Available" picture
    Response.Redirect("~/Images/NoPictureAvailable.gif");
}
else
{
    // Send back the binary contents of the Picture column
    // ... Set ContentType property and write out ...
    // ... data via Response.BinaryWrite ...
}