public static void RegisterBundles(BundleCollection bundles)
{
    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

    // Use the development version of Modernizr to develop with and learn   
    // from.Then, when you're ready for production, use the build tool at 
    // http://modernizr.com to pick only the tests you need.
    bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

    bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
        "~/Content/bootstrap.css", "~/Content/bootstrap-responsive.css"));

        bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
}