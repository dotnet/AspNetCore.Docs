public class CustomUserRole : IdentityUserRole<int> { } 
public class CustomUserClaim : IdentityUserClaim<int> { } 
public class CustomUserLogin : IdentityUserLogin<int> { } 

public class CustomRole : IdentityRole<int, CustomUserRole> 
{ 
    public CustomRole() { } 
    public CustomRole(string name) { Name = name; } 
} 

public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int, 
    CustomUserLogin, CustomUserRole, CustomUserClaim> 
{ 
    public CustomUserStore(ApplicationDbContext context) 
        : base(context) 
    { 
    } 
} 

public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole> 
{ 
    public CustomRoleStore(ApplicationDbContext context) 
        : base(context) 
    { 
    } 
}