public IEnumerable<RuleViolation> GetRuleViolations() {

    if (String.IsNullOrEmpty(Title))
        yield return new RuleViolation("Title required","Title");

    if (String.IsNullOrEmpty(Description))
        yield return new RuleViolation("Description required","Description");

    if (String.IsNullOrEmpty(HostedBy))
        yield return new RuleViolation("HostedBy required", "HostedBy");

    if (String.IsNullOrEmpty(Address))
        yield return new RuleViolation("Address required", "Address");

    if (String.IsNullOrEmpty(Country))
        yield return new RuleViolation("Country required", "Country");

    if (String.IsNullOrEmpty(ContactPhone))
        yield return new RuleViolation("Phone# required", "ContactPhone");

    if (!PhoneValidator.IsValidNumber(ContactPhone, Country))
        yield return new RuleViolation("Phone# does not match country", "ContactPhone");

    yield break;
}