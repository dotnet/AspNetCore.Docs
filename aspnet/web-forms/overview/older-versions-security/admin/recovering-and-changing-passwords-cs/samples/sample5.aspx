MembershipUser usr = Membership.GetUser(username);
string resetPwd = usr.ResetPassword();
usr.ChangePassword(resetPwd, newPassword);