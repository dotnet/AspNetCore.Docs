private void DisplayExceptionDetails(Exception ex)
{
    // Display a user-friendly message
    ExceptionDetails.Text = "There was a problem updating the product. ";
    if (ex is System.Data.Common.DbException)
        ExceptionDetails.Text += "Our database is currently experiencing problems.
            Please try again later.";
    else if (ex is NoNullAllowedException)
        ExceptionDetails.Text += "There are one or more required fields that are
            missing.";
    else if (ex is ArgumentException)
    {
        string paramName = ((ArgumentException)ex).ParamName;
        ExceptionDetails.Text +=
            string.Concat("The ", paramName, " value is illegal.");
    }
    else if (ex is ApplicationException)
        ExceptionDetails.Text += ex.Message;
}