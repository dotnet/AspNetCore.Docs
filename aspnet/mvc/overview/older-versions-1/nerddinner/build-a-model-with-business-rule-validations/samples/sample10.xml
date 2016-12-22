public partial class Dinner {

    public bool IsValid {
        get { return (GetRuleViolations().Count() == 0); }
    }

    public IEnumerable<RuleViolation> GetRuleViolations() {
        yield break;
    }

    partial void OnValidate(ChangeAction action) {
        if (!IsValid)
            throw new ApplicationException("Rule violations prevent saving");
    }
}

public class RuleViolation {

    public string ErrorMessage { get; private set; }
    public string PropertyName { get; private set; }

    public RuleViolation(string errorMessage, string propertyName) {
        ErrorMessage = errorMessage;
        PropertyName = propertyName;
    }
}