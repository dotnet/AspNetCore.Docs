public partial class _Default : System.Web.UI.Page {
    private bool _debugStatus;
    private CompilationSection compilation;
    private Configuration config;
    protected void Page_Init(object sender, EventArgs e) {
        config = WebConfigurationManager.OpenWebConfiguration("/mod9lab");
        compilation =
            (CompilationSection)config.GetSection("system.web/compilation");
        _debugStatus = compilation.Debug;
    }
}