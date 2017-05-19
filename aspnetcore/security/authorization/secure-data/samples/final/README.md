# How to build/run Secure user data sample

* Set password with the Secret Manager tool:

  `dotnet user-secrets set SeedUserPW <pw>`

* Update the database:

	`dotnet ef database update`
