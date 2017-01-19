public class IdentityRole : IRole<int>
{
    public IdentityRole() { ... }
    public IdentityRole(string roleName) { ... }
    public int Id { get; set; }
    public string Name { get; set; }
}