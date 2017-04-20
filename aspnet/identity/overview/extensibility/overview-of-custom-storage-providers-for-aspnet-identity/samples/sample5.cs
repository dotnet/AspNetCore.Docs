public class UserStore : IUserStore<IdentityUser, int>,
                         IUserClaimStore<IdentityUser, int>,
                         IUserLoginStore<IdentityUser, int>,
                         IUserRoleStore<IdentityUser, int>,
                         IUserPasswordStore<IdentityUser, int>,
                         IUserSecurityStampStore<IdentityUser, int>
{
    // interface implementations not shown
}