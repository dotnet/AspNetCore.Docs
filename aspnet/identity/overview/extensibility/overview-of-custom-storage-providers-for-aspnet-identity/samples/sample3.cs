public class UserStore : IUserStore<IdentityUser, int>
{
    public UserStore() { ... }
    public UserStore(ExampleStorage database) { ... }
    public Task CreateAsync(IdentityUser user) { ... }
    public Task DeleteAsync(IdentityUser user) { ... }
    public Task<IdentityUser> FindByIdAsync(int userId) { ... }
    public Task<IdentityUser> FindByNameAsync(string userName) { ... }
    public Task UpdateAsync(IdentityUser user) { ... }
    public void Dispose() { ... }
}