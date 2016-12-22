void Application_Start(object sender, EventArgs e)
{
    // Default behavior
    // Bundles all .js files in folders such as "scripts" if URL pointed to it: http://localhost:54716/scripts/custom/js
    BundleTable.Bundles.EnableDefaultBundles();

    // Static bundle.
    // Access on url http://localhosthost:54716/StaticBundle
    Bundle b = new Bundle("~/StaticBundle", typeof(JsMinify));
    b.AddFile("~/scripts/custom/ECMAScript5.js");
    b.AddFile("~/scripts/custom/GoToDefinition.js");
    b.AddFile("~/scripts/bundle/JScript1.js");
    b.AddFile("~/scripts/bundle/JScript2.js");

    BundleTable.Bundles.Add(b);

    // Dynamic bundle
    // Bundles all .coffee files in folders such as "script" when "coffee" is appended to it: http://localhost:54716/scripts/coffee
    // DynamicFolderBundle fb = new DynamicFolderBundle("coffee", typeof(CoffeeMinify), "*.coffee");
    // BundleTable.Bundles.Add(fb);
}