using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
public class NorthwindSiteMapProvider : StaticSiteMapProvider
{
    private readonly object siteMapLock = new object();
    private SiteMapNode root = null;
    public const string CacheDependencyKey = 
        "NorthwindSiteMapProviderCacheDependency";
    public override SiteMapNode BuildSiteMap()
    {
        // Use a lock to make this method thread-safe
        lock (siteMapLock)
        {
            // First, see if we already have constructed the
            // rootNode. If so, return it...
            if (root != null)
                return root;
            // We need to build the site map!
            
            // Clear out the current site map structure
            base.Clear();
            // Get the categories and products information from the database
            ProductsBLL productsAPI = new ProductsBLL();
            Northwind.ProductsDataTable products = productsAPI.GetProducts();
            // Create the root SiteMapNode
            root = new SiteMapNode(
                this, "root", "~/SiteMapProvider/Default.aspx", "All Categories");
            AddNode(root);
            // Create SiteMapNodes for the categories and products
            foreach (Northwind.ProductsRow product in products)
            {
                // Add a new category SiteMapNode, if needed
                string categoryKey, categoryName;
                bool createUrlForCategoryNode = true;
                if (product.IsCategoryIDNull())
                {
                    categoryKey = "Category:None";
                    categoryName = "None";
                    createUrlForCategoryNode = false;
                }
                else
                {
                    categoryKey = string.Concat("Category:", product.CategoryID);
                    categoryName = product.CategoryName;
                }
                SiteMapNode categoryNode = FindSiteMapNodeFromKey(categoryKey);
                // Add the category SiteMapNode if it does not exist
                if (categoryNode == null)
                {
                    string productsByCategoryUrl = string.Empty;
                    if (createUrlForCategoryNode)
                        productsByCategoryUrl = 
                            "~/SiteMapProvider/ProductsByCategory.aspx?CategoryID=" 
                            + product.CategoryID;
                    categoryNode = new SiteMapNode(
                        this, categoryKey, productsByCategoryUrl, categoryName);
                    AddNode(categoryNode, root);
                }
                // Add the product SiteMapNode
                string productUrl = 
                    "~/SiteMapProvider/ProductDetails.aspx?ProductID=" 
                    + product.ProductID;
                SiteMapNode productNode = new SiteMapNode(
                    this, string.Concat("Product:", product.ProductID), 
                    productUrl, product.ProductName);
                AddNode(productNode, categoryNode);
            }
            
            // Add a "dummy" item to the cache using a SqlCacheDependency
            // on the Products and Categories tables
            System.Web.Caching.SqlCacheDependency productsTableDependency = 
                new System.Web.Caching.SqlCacheDependency("NorthwindDB", "Products");
            System.Web.Caching.SqlCacheDependency categoriesTableDependency = 
                new System.Web.Caching.SqlCacheDependency("NorthwindDB", "Categories");
            // Create an AggregateCacheDependency
            System.Web.Caching.AggregateCacheDependency aggregateDependencies = 
                new System.Web.Caching.AggregateCacheDependency();
            aggregateDependencies.Add(productsTableDependency, categoriesTableDependency);
            // Add the item to the cache specifying a callback function
            HttpRuntime.Cache.Insert(
                CacheDependencyKey, DateTime.Now, aggregateDependencies, 
                Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, 
                CacheItemPriority.Normal, 
                new CacheItemRemovedCallback(OnSiteMapChanged));
            // Finally, return the root node
            return root;
        }
    }
    protected override SiteMapNode GetRootNodeCore()
    {
        return BuildSiteMap();
    }
    protected void OnSiteMapChanged(string key, object value, CacheItemRemovedReason reason)
    {
        lock (siteMapLock)
        {
            if (string.Compare(key, CacheDependencyKey) == 0)
            {
                // Refresh the site map
                root = null;
            }
        }
    }
    public DateTime? CachedDate
    {
        get
        {
            return HttpRuntime.Cache[CacheDependencyKey] as DateTime?;
        }
    }
}