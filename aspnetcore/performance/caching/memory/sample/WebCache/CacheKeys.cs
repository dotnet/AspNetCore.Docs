public static class CacheKeys
{
    public static readonly string Entry = "_Entry";
    public static readonly string CallbackEntry = "_Callback";
    public static readonly string CallbackMessage = "_CallbackMessage";
    public static readonly string Parent = "_Parent";
    public static readonly string Child = "_Child";
    public static readonly string DependentMessage = "_DependentMessage";
    public static readonly string DependentCTS = "_DependentCTS";
    public static string Ticks { get { return "_Ticks"; } }
    public static string CancelMsg { get { return  "_CancelMsg"; } }
    public static string CancelTokenSource { get { return  "_CancelTokenSource"; } }
}