// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
public static void RegisterBundles(BundleCollection bundles)
{
    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));
 
   // Code removed for brevity/
 
   BundleTable.EnableOptimizations = true;
}