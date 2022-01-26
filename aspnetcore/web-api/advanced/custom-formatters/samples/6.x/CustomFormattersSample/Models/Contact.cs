namespace CustomFormattersSample.Models;

public record Contact(Guid Id, string FirstName, string LastName)
{
    public Contact(string FirstName, string LastName)
        : this(Guid.Empty, FirstName, LastName) { }
}
