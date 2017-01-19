public class User 
{
    [Remote("UserNameAvailable", "Users")]
    public string UserName { get; set; }
}