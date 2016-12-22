Imports System.Web
Imports System.Web.Caching
Public Class NorthwindSiteMapProvider
    Inherits StaticSiteMapProvider
    Private ReadOnly siteMapLock As New Object()
    Private root As SiteMapNode = Nothing
    Public Const CacheDependencyKey As String = "NorthwindSiteMapProviderCacheDependency"
    Public Overrides Function BuildSiteMap() As System.Web.SiteMapNode
        ' Use a lock to make this method thread-safe
        SyncLock siteMapLock
            ' First, see if we already have constructed the
            ' rootNode. If so, return it...
            If root IsNot Nothing Then
                Return root
            End If
            ' We need to build the site map!
            ' Clear out the current site map structure
            MyBase.Clear()
            ' Get the categories and products information from the database
            Dim productsAPI As New ProductsBLL()
            Dim products As Northwind.ProductsDataTable = productsAPI.GetProducts()
            ' Create the root SiteMapNode
            root = New SiteMapNode( _
                Me, "root", "~/SiteMapProvider/Default.aspx", "All Categories")
            AddNode(root)
            ' Create SiteMapNodes for the categories and products
            For Each product As Northwind.ProductsRow In products
                ' Add a new category SiteMapNode, if needed
                Dim categoryKey, categoryName As String
                Dim createUrlForCategoryNode As Boolean = True
                If product.IsCategoryIDNull() Then
                    categoryKey = "Category:None"
                    categoryName = "None"
                    createUrlForCategoryNode = False
                Else
                    categoryKey = String.Concat("Category:", product.CategoryID)
                    categoryName = product.CategoryName
                End If
                Dim categoryNode As SiteMapNode = FindSiteMapNodeFromKey(categoryKey)
                ' Add the category SiteMapNode if it does not exist
                If categoryNode Is Nothing Then
                    Dim productsByCategoryUrl As String = String.Empty
                    If createUrlForCategoryNode Then
                        productsByCategoryUrl = _
                            "~/SiteMapProvider/ProductsByCategory.aspx?CategoryID=" & _
                            product.CategoryID
                    End If
                    categoryNode = New SiteMapNode _
                        (Me, categoryKey, productsByCategoryUrl, categoryName)
                    AddNode(categoryNode, root)
                End If
                ' Add the product SiteMapNode
                Dim productUrl As String = _
                    "~/SiteMapProvider/ProductDetails.aspx?ProductID=" & _
                    product.ProductID
                Dim productNode As New SiteMapNode _
                    (Me, String.Concat("Product:", product.ProductID), _
                    productUrl, product.ProductName)
                AddNode(productNode, categoryNode)
            Next
            ' Add a "dummy" item to the cache using a SqlCacheDependency
            ' on the Products and Categories tables
            Dim productsTableDependency As New _
                System.Web.Caching.SqlCacheDependency("NorthwindDB", "Products")
            Dim categoriesTableDependency As New _
                System.Web.Caching.SqlCacheDependency("NorthwindDB", "Categories")
            ' Create an AggregateCacheDependency
            Dim aggregateDependencies As New System.Web.Caching.AggregateCacheDependency()
            aggregateDependencies.Add(productsTableDependency, categoriesTableDependency)
            ' Add the item to the cache specifying a callback function
            HttpRuntime.Cache.Insert( _
                CacheDependencyKey, DateTime.Now, aggregateDependencies, _
                Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, _
                CacheItemPriority.Normal, AddressOf OnSiteMapChanged)
            ' Finally, return the root node
            Return root
        End SyncLock
    End Function
    Protected Overrides Function GetRootNodeCore() As System.Web.SiteMapNode
        Return BuildSiteMap()
    End Function
    Protected Sub OnSiteMapChanged _
    (key As String, value As Object, reason As CacheItemRemovedReason)
        SyncLock siteMapLock
            If String.Compare(key, CacheDependencyKey) = 0 Then
                ' Refresh the site map
                root = Nothing
            End If
        End SyncLock
    End Sub
    Public ReadOnly Property CachedDate() As Nullable(Of DateTime)
        Get
            Dim value As Object = HttpRuntime.Cache(CacheDependencyKey)
            If value Is Nothing OrElse Not TypeOf value Is Nullable(Of DateTime) Then
                Return Nothing
            Else
                Return CType(value, Nullable(Of DateTime))
            End If
        End Get
    End Property
End Class