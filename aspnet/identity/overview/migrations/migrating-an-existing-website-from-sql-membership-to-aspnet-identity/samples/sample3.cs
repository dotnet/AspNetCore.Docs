public class User : IdentityUser
{
	public User()
	{
		CreateDate = DateTime.Now;
		IsApproved = false;
		LastLoginDate = DateTime.Now;
		LastActivityDate = DateTime.Now;
		LastPasswordChangedDate = DateTime.Now;
		LastLockoutDate = DateTime.Parse("1/1/1754");
		FailedPasswordAnswerAttemptWindowStart = DateTime.Parse("1/1/1754");
		FailedPasswordAttemptWindowStart = DateTime.Parse("1/1/1754");
	}

	public System.Guid ApplicationId { get; set; }
	public string MobileAlias { get; set; }
	public bool IsAnonymous { get; set; }
	public System.DateTime LastActivityDate { get; set; }
	public string MobilePIN { get; set; }
	public string LoweredEmail { get; set; }
	public string LoweredUserName { get; set; }
	public string PasswordQuestion { get; set; }
	public string PasswordAnswer { get; set; }
	public bool IsApproved { get; set; }
	public bool IsLockedOut { get; set; }
	public System.DateTime CreateDate { get; set; }
	public System.DateTime LastLoginDate { get; set; }
	public System.DateTime LastPasswordChangedDate { get; set; }
	public System.DateTime LastLockoutDate { get; set; }
	public int FailedPasswordAttemptCount { get; set; }
	public System.DateTime FailedPasswordAttemptWindowStart { get; set; }
	public int FailedPasswordAnswerAttemptCount { get; set; }
	public System.DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }
	public string Comment { get; set; }
}