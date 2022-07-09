#region snippet
using Microsoft.AspNetCore.Mvc;

[NonViewComponent]
public class ReviewComponent
{
    public string Status(string name) => JobStatus.GetCurrentStatus(name);
}
#endregion

public static class JobStatus
{
    public static string GetCurrentStatus(string name) => name;
}
