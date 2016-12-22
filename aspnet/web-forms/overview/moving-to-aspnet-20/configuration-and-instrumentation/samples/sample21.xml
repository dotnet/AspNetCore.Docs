if (ddlLogAppEvents.SelectedValue != "-1") {
    if (Convert.ToBoolean(ddlLogAppEvents.SelectedValue)) {
        RuleSettings appRules = new
        RuleSettings("AppRestartEvents",
        "Application Lifetime Events",
        "EventLogProvider");
        health.Rules.Add(appRules);
        config.Save();
    } else {
        health.Rules.Remove("AppRestartEvents");
        config.Save();
    }
}