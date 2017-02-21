public static void InitializeIdentityForEF(ApplicationDbContext db) {
    var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
    var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
    const string name = "admin@example.com";
    const string password = "Admin@123456";
    const string roleName = "Admin";

    //Create Role Admin if it does not exist
    var role = roleManager.FindByName(roleName);
    if (role == null) {
        role = new IdentityRole(roleName);
        var roleresult = roleManager.Create(role);
    }

    var user = userManager.FindByName(name);
    if (user == null) {
        user = new ApplicationUser { UserName = name, Email = name };
        var result = userManager.Create(user, password);
        result = userManager.SetLockoutEnabled(user.Id, false);
    }

    // Add user admin to Role Admin if not already added
    var rolesForUser = userManager.GetRoles(user.Id);
    if (!rolesForUser.Contains(role.Name)) {
        var result = userManager.AddToRole(user.Id, role.Name);
    }
}