namespace HttpContextInBackgroundThread;

/// <summary>
/// The information for creating an email.
/// </summary>
public class EmailMessage
{
    /// <summary>
    ///   Gets or sets the user agent making the request.
    /// </summary>
    public string UserAgent { get; set; } = string.Empty;
}
