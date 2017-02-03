var manager = new ApplicationUserManager(
    new UserStore<ApplicationUser>(
    context.Get<ApplicationDbContext>() as MySQLDatabase));