DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("iPhone")
{
    ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
        ("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
});