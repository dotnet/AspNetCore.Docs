public class jForumMembershipProvider : SqlMembershipProvider {
    public jForumMembershipProvider() {

    }
    public override MembershipUser CreateUser(
    string username,
    string password,
    string email,
    string passwordQuestion,
    string passwordAnswer,
    bool isApproved,
    object providerUserKey,
    out MembershipCreateStatus status) {
        // your own implementation
        return base.CreateUser(
        username,
        password,
        email,
        passwordQuestion,
        passwordAnswer,
        isApproved,
        providerUserKey,
        out status);
    }
}