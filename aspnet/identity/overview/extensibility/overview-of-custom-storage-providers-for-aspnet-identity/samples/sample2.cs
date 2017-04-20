public class IdentityUser : IUser<int>
{
    public IdentityUser() { ... }
    public IdentityUser(string userName) { ... }
    public int Id { get; set; }
    public string UserName { get; set; }
    // can also define optional properties such as:
    //    PasswordHash
    //    SecurityStamp
    //    Claims
    //    Logins
    //    Roles
}