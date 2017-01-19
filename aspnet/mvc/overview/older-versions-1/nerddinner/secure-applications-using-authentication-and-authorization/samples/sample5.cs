public partial class Dinner {

    public bool IsHostedBy(string userName) {
        return HostedBy.Equals(userName, StringComparison.InvariantCultureIgnoreCase);
    }
}