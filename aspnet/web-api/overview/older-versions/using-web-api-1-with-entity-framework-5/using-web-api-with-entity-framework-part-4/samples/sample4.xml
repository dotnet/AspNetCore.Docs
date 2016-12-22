const string adminRole = "Administrator";
const string adminName = "Administrator";

if (!Roles.RoleExists(adminRole))
{
    Roles.CreateRole(adminRole);
}
if (!WebSecurity.UserExists(adminName))
{
    WebSecurity.CreateUserAndAccount(adminName, "password");
    Roles.AddUserToRole(adminName, adminRole);
}