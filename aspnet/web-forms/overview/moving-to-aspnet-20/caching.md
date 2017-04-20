---
uid: web-forms/overview/moving-to-aspnet-20/caching
title: "Caching | Microsoft Docs"
author: microsoft
description: "An understanding of caching is important for a well-performing ASP.NET application. ASP.NET 1.x offered three different options for caching; output caching,..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/20/2005
ms.topic: article
ms.assetid: 2bb109d2-e299-46ea-9054-fa0263b59165
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/moving-to-aspnet-20/caching
msc.type: authoredcontent
---
Caching
====================
by [Microsoft](https://github.com/microsoft)

> An understanding of caching is important for a well-performing ASP.NET application. ASP.NET 1.x offered three different options for caching; output caching, fragment caching, and the cache API.


An understanding of caching is important for a well-performing ASP.NET application. ASP.NET 1.x offered three different options for caching; output caching, fragment caching, and the cache API. ASP.NET 2.0 offers all three of these methods, but it adds some significant additional features. There are several new cache dependencies and developers now have the option to create custom cache dependencies as well. The configuration of caching has also been improved significantly in ASP.NET 2.0.

## New Features

## Cache Profiles

Cache profiles allow developers to define specific cache settings that can then be applied to individual pages. For example, if you have some pages that should be expired from cache after 12 hours, you can easily create a cache profile that can be applied to those pages. To add a new cache profile, use the &lt;outputCacheSettings&gt; section in the configuration file. For example, below is the configuration of a cache profile called *twoday* that configures a cache duration of 12 hours.

[!code-xml[Main](caching/samples/sample1.xml)]

To apply this cache profile to a particular page, use the CacheProfile attribute of the @ OutputCache directive as shown below:

[!code-aspx[Main](caching/samples/sample2.aspx)]

## Custom Cache Dependencies

ASP.NET 1.x developers cried out for custom cache dependencies. In ASP.NET 1.x, the CacheDependency class was sealed which prevented developers from deriving their own classes from it. In ASP.NET 2.0, that limitation is removed and developers are free to develop their own custom cache dependencies. The CacheDependency class allows for the creation of a custom cache dependency based on files, directories, or cache keys.

For example, the code below creates a new custom cache dependency based on a file called stuff.xml located in the root of the Web application:

[!code-csharp[Main](caching/samples/sample3.cs)]

In this scenario, when the stuff.xml file changes, the cached item is invalidated.

It is also possible to create a custom cache dependency using cache keys. Using this method, the removal of the cache key will invalidate the cached data. The following example illustrates this:

[!code-csharp[Main](caching/samples/sample4.cs)]

To invalidate the item that was inserted above, simply remove the item that was inserted into cache to act as the cache key.

[!code-csharp[Main](caching/samples/sample5.cs)]

Note that the key of the item that acts as the cache key must be the same as the value added to the array of cache keys.

## Polling-Based SQL Cache Dependencies*(Also called Table-Based Dependencies)*

SQL Server 7 and 2000 use the polling-based model for SQL cache dependencies. The polling-based model uses a trigger on a database table that is triggered when data in the table change. That trigger updates a **changeId** field in the notification table that ASP.NET checks periodically. If the **changeId** field has been updated, ASP.NET knows that the data have changed and it invalidates the cached data.

> [!NOTE]
> SQL Server 2005 can also use the polling-based model, but because the polling-based model is not the most efficient model, it is advisable to use a query-based model (discussed later) with SQL Server 2005.


In order for a SQL cache dependency using the polling-based model to work correctly, the tables must have notifications enabled. This can be accomplished programmatically using the SqlCacheDependencyAdmin class or by using the aspnet\_regsql.exe utility.

The following command line registers the Products table in the Northwind database located on a SQL Server instance named *dbase* for SQL cache dependency.

[!code-console[Main](caching/samples/sample6.cmd)]

The following is an explanation of the command line switches used in the above command:

| **Command Line Switch** | **Purpose** |
| --- | --- |
| -S *server* | Specifies the server name. |
| -ed | Specifies that the database should be enabled for SQL cache dependency. |
| -d *database\_name* | Specifies the database name that should be enabled for SQL cache dependency. |
| -E | Specifies that aspnet\_regsql should use Windows authentication when connecting to the database. |
| -et | Specifies that we are enabling a database table for SQL cache dependency. |
| -t *table\_name* | Specifies the name of the database table to enable for SQL cache dependency. |

> [!NOTE]
> There are other switches available for aspnet\_regsql.exe. For a complete list, run aspnet\_regsql.exe -? from a command line.


When this command runs the following changes are made to the SQL Server database:

- An **AspNet\_SqlCacheTablesForChangeNotification** table is added. This table contains one row for each table in the database for which a SQL cache dependency has been enabled.
- The following stored procedures are created inside of the database:


| AspNet\_SqlCachePollingStoredProcedure | Queries the AspNet\_SqlCacheTablesForChangeNotification table and returns all tables that are enabled for SQL cache dependency and the value of changeId for each table. This stored proc is used for polling to determine if data have changed. |
| --- | --- |
| AspNet\_SqlCacheQueryRegisteredTablesStoredProcedure | Returns all of the tables enabled for SQL cache dependency by querying the AspNet\_SqlCacheTablesForChangeNotification table and returns all tables enabled for SQL cache dependency. |
| AspNet\_SqlCacheRegisterTableStoredProcedure | Registers a table for SQL cache dependency by adding the necessary entry in the notification table and adds the trigger. |
| AspNet\_SqlCacheUnRegisterTableStoredProcedure | Unregisters a table for SQL cache dependency by removing the entry in the notification table and removes the trigger. |
| AspNet\_SqlCacheUpdateChangeIdStoredProcedure | Updates the notification table by incrementing the changeId for the changed table. ASP.NET uses this value to determine if the data have changed. As indicated below, this stored proc is executed by the trigger created when the table is enabled. |


- A SQL Server trigger called ***table\_name*\_AspNet\_SqlCacheNotification\_Trigger** is created for the table. This trigger executes the AspNet\_SqlCacheUpdateChangeIdStoredProcedure when an INSERT, UPDATE, or DELETE is performed on the table.
- A SQL Server role called **aspnet\_ChangeNotification\_ReceiveNotificationsOnlyAccess** is added to the database.

The **aspnet\_ChangeNotification\_ReceiveNotificationsOnlyAccess** SQL Server role has EXEC permissions to the AspNet\_SqlCachePollingStoredProcedure. In order for the polling model to work correctly, you must add your process account to the aspnet\_ChangeNotification\_ReceiveNotificationsOnlyAccess role. The aspnet\_regsql.exe tool will not do this for you.

### Configuring Polling-Based SQL Cache Dependencies

There are several steps that are required for configuring polling-based SQL cache dependencies. The first step is to enable the database and the table as discussed above. Once that step is complete, the rest of the configuration is as follows:

- Configuring the ASP.NET configuration file.
- Configuring the SqlCacheDependency

### Configuring the ASP.NET Configuration File

In addition to adding a connection string as discussed in a previous module, you must also configure a &lt;cache&gt; element with a &lt;sqlCacheDependency&gt; element as shown below:

[!code-xml[Main](caching/samples/sample7.xml)]

This configuration enables a SQL cache dependency on the *pubs* database. Note that the pollTime attribute in the &lt;sqlCacheDependency&gt; element defaults to 60000 milliseconds or 1 minute. (This value cannot be less than 500 milliseconds.) In this example, the &lt;add&gt; element adds a new database and overrides the pollTime, setting it to 9000000 milliseconds.

#### Configuring the SqlCacheDependency

The next step is to configure the SqlCacheDependency. The easiest way to accomplish that is to specify the value for the SqlDependency attribute in the @ Outcache directive as follows:

[!code-aspx[Main](caching/samples/sample8.aspx)]

In the above @ OutputCache directive, a SQL cache dependency is configured for the *authors* table in the *pubs* database. Multiple dependencies can be configured by separating them with a semi-colon like so:

[!code-aspx[Main](caching/samples/sample9.aspx)]

Another method of configuring the SqlCacheDependency is to do so programmatically. The following code creates a new SQL cache dependency on the *authors* table in the *pubs* database.

[!code-csharp[Main](caching/samples/sample10.cs)]

One of the benefits of programmatically defining the SQL cache dependency is that you can handle any exceptions that might occur. For example, if you attempt to define a SQL cache dependency for a database that has not been enabled for notification, a **DatabaseNotEnabledForNotificationException** exception will be thrown. In that case, you can attempt to enable the database for notifications by calling the **SqlCacheDependencyAdmin.EnableNotifications** method and passing it the database name.

Likewise, if you attempt to define a SQL cache dependency for a table that has not been enabled for notification, a **TableNotEnabledForNotificationException** will be thrown. You can then call the **SqlCacheDependencyAdmin.EnableTableForNotifications** method passing it the database name and table name.

The following code sample illustrates how to properly configure exception handling when configuring a SQL cache dependency.

[!code-csharp[Main](caching/samples/sample11.cs)]

More Information: [https://msdn.microsoft.com/en-us/library/t9x04ed2.aspx](https://msdn.microsoft.com/en-us/library/t9x04ed2.aspx)

## Query-Based SQL Cache Dependencies (SQL Server 2005 Only)

When using SQL Server 2005 for SQL cache dependency, the polling-based model is not necessary. When used with SQL Server 2005, SQL cache dependencies communicate directly via SQL connections to the SQL Server instance (no further configuration is necessary) using SQL Server 2005 query notifications.

The simplest way to enable query-based notification is to do so declaratively by setting the **SqlCacheDependency** attribute of the data source object to **CommandNotification** and setting the **EnableCaching** attribute to **true**. Using this method, no code is required. If the result of a command executed against the data source changes, it will invalidate the cache data.

The following example configures a data source control for SQL cache dependency:

[!code-aspx[Main](caching/samples/sample12.aspx)]

In this case, if the query specified in the **SelectCommand** returns a different result than it did originally, the results that are cached are invalidated.

You can also specify that all of your data sources be enabled for SQL cache dependencies by setting the **SqlDependency** attribute of the **@ OutputCache** directive to **CommandNotification**. The example below illustrates this.

[!code-aspx[Main](caching/samples/sample13.aspx)]

> [!NOTE]
> For more information on query notifications in SQL Server 2005, see the SQL Server Books Online.


Another method of configuring a query-based SQL cache dependency is to do so programmatically using the SqlCacheDependency class. The following code sample illustrates how this is accomplished.

[!code-csharp[Main](caching/samples/sample14.cs)]

More Information: [https://msdn.microsoft.com/library/default.asp?url=/library/enus/dnvs05/html/querynotification.asp](https://msdn.microsoft.com/library/default.asp?url=/library/enus/dnvs05/html/querynotification.asp)

## Post-Cache Substitution

Caching a page can dramatically increase the performance of a Web application. However, in some cases you need most of the page to be cached and some fragments within the page to be dynamic. For example, if you create a page of news stories that is entirely static for set periods of time, you can set the entire page to be cached. If you wanted to include a rotating ad banner that changed on every page request, then the part of the page containing the advertisement needs to be dynamic. To allow you to cache a page but substitute some content dynamically, you can use ASP.NET post-cache substitution. With post-cache substitution, the entire page is output cached with specific parts marked as exempt from caching. In the example of the ad banners, the AdRotator control allows you to take advantage of post-cache substitution so that ads dynamically created for each user and for each page refresh.

There are three ways to implement post-cache substitution:

- Declaratively, using the Substitution control.
- Programmatically, using the Substitution control API.
- Implicitly, using the AdRotator control.

### Substitution Control

The ASP.NET Substitution control specifies a section of a cached page that is created dynamically rather than cached. You place a Substitution control at the location on the page where you want the dynamic content to appear. At run time, the Substitution control calls a method that you specify with the MethodName property. The method must return a string, which then replaces the content of the Substitution control. The method must be a static method on the containing Page or UserControl control. Using the substitution control causes client-side cacheability to be changed to server cacheability, so that the page will not be cached on the client. This ensures that future requests to the page call the method again to generate dynamic content.

### Substitution API

To create dynamic content for a cached page programmatically, you can call the [WriteSubstitution](https://msdn.microsoft.com/en-us/library/system.web.httpresponse.writesubstitution.aspx) method in your page code, passing it the name of a method as a parameter. The method that handles the creation of the dynamic content takes a single [HttpContext](https://msdn.microsoft.com/en-us/library/system.web.httpcontext.aspx) parameter and returns a string. The return string is the content that will be substituted at the given location. An advantage of calling the WriteSubstitution method instead of using the Substitution control declaratively is that you can call a method of any arbitrary object rather than calling a static method of the Page or the UserControl object.

Calling the WriteSubstitution method causes client-side cacheability to be changed to server cacheability, so that the page will not be cached on the client. This ensures that future requests to the page call the method again to generate dynamic content.

### AdRotator Control

The AdRotator server control implements support for post-cache substitution internally. If you place an AdRotator control on your page, it will render unique advertisements on each request, regardless of whether the parent page is cached. As a result, a page that includes an AdRotator control is only cached server-side.

## ControlCachePolicy Class

The ControlCachePolicy class allows for the programmatic control of fragment caching using user controls. ASP.NET embeds user controls within a [BasePartialCachingControl](https://msdn.microsoft.com/en-us/library/system.web.ui.basepartialcachingcontrol.aspx) instance. The BasePartialCachingControl class represents a user control that has output caching enabled.

When you access the [BasePartialCachingControl.CachePolicy](https://msdn.microsoft.com/en-us/library/system.web.ui.basepartialcachingcontrol.cachepolicy.aspx) property of a [PartialCachingControl](https://msdn.microsoft.com/en-us/library/system.web.ui.partialcachingcontrol.aspx) control, you will always receive a valid ControlCachePolicy object. However, if you access the [UserControl.CachePolicy](https://msdn.microsoft.com/en-us/library/system.web.ui.usercontrol.cachepolicy.aspx) property of a [UserControl](https://msdn.microsoft.com/en-us/library/system.web.ui.usercontrol.aspx) control, you receive a valid ControlCachePolicy object only if the user control is already wrapped by a BasePartialCachingControl control. If it is not wrapped, the ControlCachePolicy object returned by the property will throw exceptions when you attempt to manipulate it because it does not have an associated BasePartialCachingControl. To determine whether a UserControl instance supports caching without generating exceptions, inspect the [SupportsCaching](https://msdn.microsoft.com/en-us/library/system.web.ui.controlcachepolicy.supportscaching.aspx) property.

Using the ControlCachePolicy class is one of several ways you can enable output caching. The following list describes methods you can use to enable output caching:

- Use the [@ OutputCache](https://msdn.microsoft.com/en-us/library/hdxfb6cy.aspx) directive to enable output caching in declarative scenarios.
- Use the [PartialCachingAttribute](https://msdn.microsoft.com/en-us/library/system.web.ui.partialcachingattribute.aspx) attribute to enable caching for a user control in a code-behind file.
- Use the ControlCachePolicy class to specify cache settings in programmatic scenarios in which you are working with BasePartialCachingControl instances that have been cache-enabled using one of the previous methods and dynamically loaded using the [System.Web.UI.TemplateControl.LoadControl](https://msdn.microsoft.com/en-us/library/system.web.ui.templatecontrol.loadcontrol.aspx) method.

A ControlCachePolicy instance can be successfully manipulated only between the Init and PreRender stages of the control life cycle. If you modify a ControlCachePolicy object after the PreRender phase, ASP.NET throws an exception because any changes made after the control is rendered cannot actually affect cache settings (a control is cached during the Render stage). Finally, a user control instance (and therefore its ControlCachePolicy object) is only available for programmatic manipulation when it is actually rendered.

## Changes to Caching Configuration - The &lt;caching&gt; Element

There are several changes to caching configuration in ASP.NET 2.0. The &lt;caching&gt; element is new in ASP.NET 2.0 and allows you to make caching configuration changes in the configuration file. The following attributes are available.

| **Element** | **Description** |
| --- | --- |
| **cache** | Optional element. Defines global application cache settings. |
| **outputCache** | Optional element. Specifies application-wide output-cache settings. |
| **outputCacheSettings** | Optional element. Specifies output-cache settings that can be applied to pages in the application. |
| **sqlCacheDependency** | Optional element. Configures the SQL cache dependencies for an ASP.NET application. |

### The &lt;cache&gt; Element

The following attributes are available in the &lt;cache&gt; element:

| **Attribute** | **Description** |
| --- | --- |
| **disableMemoryCollection** | Optional **Boolean** attribute. Gets or sets a value indicating whether the cache memory collection that occurs when the machine is under memory pressure is disabled. |
| **disableExpiration** | Optional **Boolean** attribute. Gets or sets a value indicating whether cache expiration is disabled. When disabled, cached items do not expire and background scavenging of expired cache items does not occur. |
| **privateBytesLimit** | Optional **Int64** attribute. Gets or sets a value indicating the maximum size of an application's private bytes before the cache starts flushing expired items and attempting to reclaim memory. This limit includes both memory used by the cache as well as normal memory overhead from the running application. A setting of zero indicates that ASP.NET will use its own heuristics for determining when to start reclaiming memory. |
| **percentagePhysicalMemoryUsedLimit** | Optional **Int32** attribute. Gets or sets a value indicating the maximum percentage of a machine's physical memory that can be consumed by an application before the cache starts flushing expired items and attempting to reclaim memory This memory usage includes both memory used by the cache as well as the normal memory usage of the running application. A setting of zero indicates that ASP.NET will use its own heuristics for determining when to start reclaiming memory. |
| **privateBytesPollTime** | Optional **TimeSpan** attribute. Gets or sets a value indicating the time interval between polling for the application's private bytes memory usage. |

### The &lt;outputCache&gt; Element

The following attributes are available for the &lt;outputCache&gt; element.

| **Attribute** | **Description** |
| --- | --- |
| **enableOutputCache** | Optional **Boolean** attribute. Enables/disables the page output cache. If disabled, no pages are cached regardless of the programmatic or declarative settings. Default value is **true**. |
| **enableFragmentCache** | Optional **Boolean** attribute. Enables/disables the application fragment cache. If disabled, no pages are cached regardless of the [@ OutputCache](https://msdn.microsoft.com/en-us/library/hdxfb6cy.aspx) directive or caching profile used. Includes a cache-control header indicating that upstream proxy servers as well as browser clients should not attempt to cache page output. Default value is **false**. |
| **sendCacheControlHeader** | Optional **Boolean** attribute. Gets or sets a value indicating whether the **cache-control:private** header is sent by the output cache module by default. Default value is **false**. |
| **omitVaryStar** | Optional **Boolean** attribute. Enables/disables sending an Http "**Vary: \***" header in the response. With the default setting of false, a "**Vary: \***" header is sent for output cached pages. When the Vary header is sent, it allows for different versions to be cached based upon what is specified in the Vary header. For example, *Vary:User-Agents* will store different versions of a page based upon the user agent issuing the request. Default value is **false**. |

### The &lt;outputCacheSettings&gt; Element

The &lt;outputCacheSettings&gt; element allows for the creation of cache profiles as previously described. The only child element for the &lt;outputCacheSettings&gt; element is the &lt;outputCacheProfiles&gt; element for configuring cache profiles.

### The &lt;sqlCacheDependency&gt; Element

The following attributes are available for the &lt;sqlCacheDependency&gt; element.

| **Attribute** | **Description** |
| --- | --- |
| **enabled** | Required **Boolean** attribute. Indicates whether or not changes are being polled for. |
| **pollTime** | Optional **Int32** attribute. Sets the frequency with which the SqlCacheDependency polls the database table for changes. This value corresponds to the number of milliseconds between successive pollings. It cannot be set to less than 500 milliseconds. Default value is 1 minute. |

### More Information

There is some additional information that you should be aware of regarding cache configuration.

- If the worker process private bytes limit is not set, the cache will use one of the following limits: 

    - x86 2GB: 800MB or 60% of physical RAM, whichever is less
    - x86 3GB: 1800MB or 60% of physical RAM, whichever is less
    - x64: 1 terabyte or 60% of physical RAM, whichever is less
- If both the worker process private bytes limit and &lt;cache privateBytesLimit/&gt; are set, the cache will use the minimum of the two.
- Just like in 1.x, we drop cache entries and call GC.Collect for two reasons: 

    - We are very close to the private bytes limit
    - The available memory is near or less than 10%
- You can effectively disable trim and cache for low available memory conditions by setting &lt;cache percentagePhysicalMemoryUseLimit/&gt; to 100.
- Unlike 1.x, 2.0 will suspend the trim and collect calls if the last GC.Collect did not reduce private bytes or the size of the managed heaps by more than 1% of the (cache) memory limit.

## Lab1: Custom Cache Dependencies

1. Create a new Web site.
2. Add a new XML file called cache.xml and save it to the root of the Web application.
3. Add the following code to the Page\_Load method in the code-behind of default.aspx: 

    [!code-csharp[Main](caching/samples/sample15.cs)]
4. Add the following to the top of default.aspx in source view: 

    [!code-aspx[Main](caching/samples/sample16.aspx)]
5. Browse Default.aspx. What does the time say?
6. Refresh the browser. What does the time say?
7. Open cache.xml and add the following code: 

    [!code-xml[Main](caching/samples/sample17.xml)]
8. Save cache.xml.
9. Refresh your browser. What does the time say?
10. Explain why the time updated instead of displaying the previously cached values:

## Lab 2: Using Polling-Based Cache Dependencies

This lab uses the project you created in the previous module that allows for editing of data in the Northwind database via a GridView and DetailsView control.

1. Open the project in Visual Studio 2005.
2. Run the aspnet\_regsql utility against the Northwind database to enable the database and the Products table. Use the following command from a Visual Studio Command Prompt: 

    [!code-console[Main](caching/samples/sample18.cmd)]
3. Add the following to your web.config file: 

    [!code-xml[Main](caching/samples/sample19.xml)]
4. Add a new webform called showdata.aspx.
5. Add the following @ outputcache directive to the showdata.aspx page: 

    [!code-aspx[Main](caching/samples/sample20.aspx)]
6. Add the following code to the Page\_Load of showdata.aspx: 

    [!code-html[Main](caching/samples/sample21.html)]
7. Add a new SqlDataSource control to showdata.aspx and configure it to use the Northwind database connection. Click Next.
8. Select the ProductName and ProductID checkboxes and click Next.
9. Click Finish.
10. Add a new GridView to the showdata.aspx page.
11. Choose SqlDataSource1 from the dropdown.
12. Save and browse showdata.aspx. Make note of the time displayed.