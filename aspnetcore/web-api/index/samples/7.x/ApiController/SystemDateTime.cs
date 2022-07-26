public class SystemDateTime : IDateTime
{
    public string Now => DateTime.Now.ToString();
}

public interface IDateTime
{
    string Now { get; }
}
