internal class TodoDto
{
    public string Title {get; set;} = String.Empty;
    public string Description {get; set;} = String.Empty;
    public bool IsDone {get; set;}
}

internal class NoteDto
{
    public string Title {get; set;} = String.Empty;
}