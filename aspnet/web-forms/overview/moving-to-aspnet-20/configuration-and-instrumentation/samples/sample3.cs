System.Configuration.Configuration updateWebConfig =
    System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/webApp");

System.Web.Configuration.CompilationSection compilation =
    updateWebConfig.GetSection("system.web/compilation")
    as System.Web.Configuration.CompilationSection;

compilation.Debug = false;

if (!compilation.SectionInformation.IsLocked) {
    updateWebConfig.Save();
    Response.Write("Save Success!");
} else {
    Response.Write("Save Failed!");
}