public class RoleStore : IRoleStore<IdentityRole, int>
{
    public RoleStore() { ... }
    public RoleStore(ExampleStorage database) { ... }
    public Task CreateAsync(IdentityRole role) { ... }
    public Task DeleteAsync(IdentityRole role) { ... }
    public Task<IdentityRole> FindByIdAsync(int roleId) { ... }
    public Task<IdentityRole> FindByNameAsync(string roleName) { ... }
    public Task UpdateAsync(IdentityRole role) { ... }
    public void Dispose() { ... }
}