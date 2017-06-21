public UserManager()
            : base(new UserStore<User>(new ApplicationDbContext()))
{
            this.PasswordHasher = new SQLPasswordHasher();
}