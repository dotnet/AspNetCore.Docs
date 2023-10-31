namespace ConfigSample.Options;

public abstract class SomethingWithAName
{
    public abstract string? Name { get; set; }
}

public class NameTitleOptions(int age) : SomethingWithAName
{
    public const string NameTitle = "NameTitle";

    public override string? Name { get; set; }
    public string Title { get; set; } = string.Empty;

    public int Age { get; set; } = age;
}
