public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, 
    int, CustomUserLogin, CustomUserRole, CustomUserClaim> 
{ 
    ...