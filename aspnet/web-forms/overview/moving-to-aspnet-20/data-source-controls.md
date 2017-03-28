---
uid: web-forms/overview/moving-to-aspnet-20/data-source-controls
title: "Data Source Controls | Microsoft Docs"
author: microsoft
description: "The DataGrid control in ASP.NET 1.x marked a great improvement in data access in Web applications. However, it wasn’t as user-friendly as it could have been...."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/20/2005
ms.topic: article
ms.assetid: 78fd0e92-f9c6-4e96-a5e9-0375b307a828
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/moving-to-aspnet-20/data-source-controls
msc.type: authoredcontent
---
Data Source Controls
====================
by [Microsoft](https://github.com/microsoft)

> The DataGrid control in ASP.NET 1.x marked a great improvement in data access in Web applications. However, it wasn't as user-friendly as it could have been. It still required a considerable amount of code to obtain much useful functionality from it. Such is the model in all data access endeavors in 1.x.


The DataGrid control in ASP.NET 1.x marked a great improvement in data access in Web applications. However, it wasn't as user-friendly as it could have been. It still required a considerable amount of code to obtain much useful functionality from it. Such is the model in all data access endeavors in 1.x.

ASP.NET 2.0 addresses this with in part with data source controls. The data source controls in ASP.NET 2.0 provide developers with a declarative model for retrieving data, displaying data, and editing data. The purpose of data source controls is to provide a consistent representation of data to data-bound controls regardless of the source of those data. At the heart of the data source controls in ASP.NET 2.0 is the DataSourceControl abstract class. The DataSourceControl class provides a base implementation of the IDataSource interface and the IListSource interface, the latter of which allows you to assign the data source control as the DataSource of a data-bound control (via the new DataSourceId property discussed later) and expose the data therein as a list. Each list of data from a data source control is exposed as a DataSourceView object. Access to the DataSourceView instances is provided by the IDataSource interface. For example, the GetViewNames method returns an ICollection that allows you to enumerate the DataSourceViews associated with a particular data source control, and the GetView method allows you to access a particular DataSourceView instance by name.

Data source controls have no user-interface. They are implemented as server controls so that they can support declarative syntax and so that they have access to page state if desired. Data source controls do not render any HTML markup to the client.

> [!NOTE]
> As you'll see later, there are also caching benefits obtained by using data source controls.


## Storing Connection Strings

Before we get into looking at how to configure data source controls, we should cover a new capability in ASP.NET 2.0 concerning connection strings. ASP.NET 2.0 introduces a new section in the configuration file that allows you to easily store connection strings that can be read dynamically at runtime. The &lt;connectionStrings&gt; section makes it easy to store connection strings.

The snippet below adds a new connection string.

[!code-xml[Main](data-source-controls/samples/sample1.xml)]

> [!NOTE]
> Just as with the &lt;appSettings&gt; section, the &lt;connectionStrings&gt; section appears outside of the &lt;system.web&gt; section in the configuration file.


To use this connection string, you can use the following syntax when setting the ConnectionString attribute of a server control.

[!code-aspx[Main](data-source-controls/samples/sample2.aspx)]

The &lt;connectionStrings&gt; section can also be encrypted so that sensitive information is not exposed. That ability will be covered in a later module.

## Caching Data Sources

Each DataSourceControl provides four properties for configuring caching; EnableCaching, CacheDuration, CacheExpirationPolicy, and CacheKeyDependency.

## EnableCaching

EnableCaching is a Boolean property that determines whether or not caching is enabled for the data source control.

## CacheDuration Property

The CacheDuration property sets the number of seconds that the cache remains valid. Setting this property to **0** causes the cache to remain valid until explicitly invalidated.

## CacheExpirationPolicy Property

The CacheExpirationPolicy property can be set to either **Absolute** or **Sliding**. Setting it to Absolute means that the maximum amount of time that the data will be cached is the number of seconds specified by the CacheDuration property. By setting it to Sliding, the expiration time is reset when each operation is performed.

## CacheKeyDependency Property

If a string value is specified for the CacheKeyDependency property, ASP.NET will set up a new cache dependency based on that string. This allows you to explicitly invalidate the cache by simply changing or removing the CacheKeyDependency.

**Important**: If impersonation is enabled and access to the data source and/or content of data are based upon client identity, it is recommended that caching be disabled by setting EnableCaching to False. If caching is enabled in this scenario and a user other than the user who originally requested the data issues a request, authorization to the data source is not enforced. The data will simply be served from cache.

## The SqlDataSource Control

The SqlDataSource control allows a developer to access data stored in any relational database that supports ADO.NET. It can use the System.Data.SqlClient provider to access a SQL Server database, the System.Data.OleDb provider, the System.Data.Odbc provider, or the System.Data.OracleClient provider to access Oracle. Therefore, the SqlDataSource is certainly not only used for accessing data in a SQL Server database.

In order to use the SqlDataSource, you simply provide a value for the ConnectionString property and specify a SQL command or stored procedure. The SqlDataSource control takes care of working with the underlying ADO.NET architecture. It opens the connection, queries the data source or executes the stored procedure, returns the data, and then closes the connection for you.

> [!NOTE]
> Because the DataSourceControl class automatically closes the connection for you, it should reduce the number of customer calls generated by leaking database connections.


The code snippet below binds a DropDownList control to a SqlDataSource control using the connection string that is stored in the configuration file as shown above.

[!code-aspx[Main](data-source-controls/samples/sample3.aspx)]

As illustrated above, the DataSourceMode property of the SqlDataSource specifies the mode for the data source. In the example above, the DataSourceMode is set to DataReader. In that case, the SqlDataSource will return an IDataReader object using a forward-only and read-only cursor. The specified type of object that is returned is controlled by the provider that is used. In this case, I'm using the System.Data.SqlClient provider as specified in the &lt;connectionStrings&gt; section of the web.config file. Therefore, the object that is returned will be of type SqlDataReader. By specifying a DataSourceMode value of DataSet, the data can be stored in a DataSet on the server. This mode allows you to add features such as sorting, paging, etc. If I had been data-binding the SqlDataSource to a GridView control, I would have chosen the DataSet mode. However, in the case of a DropDownList, the DataReader mode is the correct choice.

> [!NOTE]
> When caching a SqlDataSource or an AccessDataSource, the DataSourceMode property must be set to DataSet. An exception will occur if you enable caching with a DataSourceMode of DataReader.


## SqlDataSource Properties

The following are some of the properties of the SqlDataSource control.

### CancelSelectOnNullParameter

A Boolean value that specifies whether a select command is canceled if one of the parameters is null. True by default.

### ConflictDetection

In a situation where multiple users may be updating a data source at the same time, the ConflictDetection property determines the behavior of the SqlDataSource control. This property evaluates to one of the values of the ConflictOptions enumeration. Those values are **CompareAllValues** and **OverwriteChanges**. If set to OverwriteChanges, the last person to write data to the data source overwrites any previous changes. However, if the ConflictDetection property is set to CompareAllValues, parameters get created for the columns returned by the SelectCommand and parameters are also created to hold the original values in each of those columns allowing the SqlDataSource to determine whether or not the values have changed since the SelectCommand was executed.

### DeleteCommand

Sets or gets the SQL string used when deleting rows from the database. This can either be a SQL query or a stored procedure name.

### DeleteCommandType

Sets or gets the type of delete command, either a SQL query (Text) or a stored procedure (StoredProcedure).

### DeleteParameters

Returns the parameters that are used by the DeleteCommand of the SqlDataSourceView object associated with the SqlDataSource control.

### OldValuesParameterFormatString

This property is used to specify the format of the original value parameters in cases where the ConflictDetection property is set to CompareAllValues. The default is {0} which means that original value parameters will take the same name as the original parameter. In other words, if the field name is EmployeeID, the original value parameter would be @EmployeeID.

### SelectCommand

Sets or gets the SQL string that is used to retrieve data from the database. This can either be a SQL query or a stored procedure name.

### SelectCommandType

Sets or gets the type of select command, either a SQL query (Text) or a stored procedure (StoredProcedure).

### SelectParameters

Returns the parameters that are used by the SelectCommand of the SqlDataSourceView object associated with the SqlDataSource control.

### SortParameterName

Gets or sets the name of a stored procedure parameter that is used when sorting data retrieved by the data source control. Valid only when SelectCommandType is set to StoredProcedure.

### SqlCacheDependency

A semi-colon delimited string specifying the databases and tables used in a SQL Server cache dependency. (SQL cache dependencies will be discussed in a later module.)

### UpdateCommand

Sets or gets the SQL string that is used when updating data in the database. This can either be a SQL query or a stored procedure name.

### UpdateCommandType

Sets or gets the type of update command, either a SQL query (Text) or a stored procedure (StoredProcedure).

### UpdateParameters

Returns the parameters that are used by the UpdateCommand of the SqlDataSourceView object associated with the SqlDataSource control.

## The AccessDataSource Control

The AccessDataSource control derives from the SqlDataSource class and is used to data-bind to a Microsoft Access database. The ConnectionString property for the AccessDataSource control is a read-only property. Instead of using the ConnectionString property, the DataFile property is used to point to the Access Database as shown below.

[!code-aspx[Main](data-source-controls/samples/sample4.aspx)]

The AccessDataSource will always set the ProviderName of the base SqlDataSource to System.Data.OleDb and connects to the database using the Microsoft.Jet.OLEDB.4.0 OLE DB provider. You cannot use the AccessDataSource control to connect to a password-protected Access database. If you have to connect to a password protected database, you should use the SqlDataSource control.

> [!NOTE]
> Access databases stored within the Web site should be placed in the App\_Data directory. ASP.NET does not allow files in this directory to be browsed. You will need to grant the process account Read and Write permissions to the App\_Data directory when using Access databases.


## The XmlDataSource Control

The XmlDataSource is used to data-bind XML data to data-bound controls. You can bind to an XML file using the DataFile property or you can bind to an XML string using the Data property. The XmlDataSource exposes XML attributes as bindable fields. In cases where you need to bind to values that are not represented as attributes, you will need to use an XSL transform. You can also use XPath expressions to filter XML data.

Consider the following XML file:

[!code-xml[Main](data-source-controls/samples/sample5.xml)]

Notice that the XmlDataSource uses an XPath property of *People/Person* in order to filter on just the &lt;Person&gt; nodes. The DropDownList then data-binds to the LastName attribute using the DataTextField property.

While the XmlDataSource control is primarily used to data-bind to read-only XML data, it is possible to edit the XML data file. Note that in such cases, automatic insertion, updating, and deletion of information in the XML file does not happen automatically as it does with other data source controls. Instead, you will have to write code to manually edit the data using the following methods of the XmlDataSource control.

### GetXmlDocument

Retrieves an XmlDocument object containing the XML code retrieved by the XmlDataSource.

### Save

Saves the in-memory XmlDocument back to the data source.

It's important to realize that the Save method will only work when the following two conditions are met:

1. The XmlDataSource is using the DataFile property to bind to an XML file instead of the Data property to bind to in-memory XML data.
2. No transformation is specified via the Transform or TransformFile property.

Note also that the Save method can yield unexpected results when called by multiple users concurrently.

## The ObjectDataSource Control

The data source controls that we have covered up to this point are excellent choices for two-tier applications where the data source control communicates directly to the data store. However, many real-world applications are multi-tier applications where a data source control might need to communicate to a business object which, in turn, communicates with the data layer. In these situations, the ObjectDataSource fills the bill nicely. The ObjectDataSource works in conjunction with a source object. The ObjectDataSource control will create an instance of the source object, call the specified method, and dispose of the object instance all within the scope of a single request, if your object has instance methods instead of static methods (Shared in Visual Basic). Therefore, your object must be stateless. That is, your object should acquire and release all required resources within the span of a single request. You can control how the source object is created by handling the ObjectCreating event of the ObjectDataSource control. You can create an instance of the source object, and then set the ObjectInstance property of the ObjectDataSourceEventArgs class to that instance. The ObjectDataSource control will use the instance that is created in the ObjectCreating event instead of creating an instance on its own.

If the source object for an ObjectDataSource control exposes public static methods (Shared in Visual Basic) that can be called to retrieve and modify data, an ObjectDataSource control will call those methods directly. If an ObjectDataSource control must create an instance of the source object in order to make method calls, the object must include a public constructor that takes no parameters. The ObjectDataSource control will call this constructor when it creates a new instance of the source object.

If the source object does not contain a public constructor without parameters, you can create an instance of the source object that will be used by the ObjectDataSource control in the ObjectCreating event.

## Specifying Object Methods

The source object for an ObjectDataSource control can contain any number of methods that are used to select, insert, update, or delete data. These methods are called by the ObjectDataSource control based on the name of the method, as identified by using either the SelectMethod, InsertMethod, UpdateMethod, or DeleteMethod property of the ObjectDataSource control. The source object can also include an optional SelectCount method, which is identified by the ObjectDataSource control using the SelectCountMethod property, that returns the count of the total number of objects at the data source. The ObjectDataSource control will call the SelectCount method after a Select method has been called to retrieve the total number of records at the data source for use when paging.

## Lab Using Data Source Controls

## Exercise 1 - Displaying Data with the SqlDataSource Control

The following exercise uses the SqlDataSource control to connect to the Northwind database. It assumes that you have access to the Northwind database on a SQL Server 2000 instance.

1. Create a new ASP.NET Web site.
2. Add a new web.config file.

    1. Right-click on the project in Solution Explorer and click Add New Item.
    2. Choose Web Configuration File from the list of templates and click Add.
3. Edit the &lt;connectionStrings&gt; section as follows: 

    [!code-aspx[Main](data-source-controls/samples/sample6.aspx)]
4. Switch to Code view and add a ConnectionString attribute and a SelectCommand attribute to the &lt;asp:SqlDataSource&gt; control as follows: 

    [!code-aspx[Main](data-source-controls/samples/sample7.aspx)]
5. From Design view, add a new GridView control.
6. From the Choose Data Source dropdown in the GridView Tasks menu, choose SqlDataSource1.
7. Right-click on Default.aspx and choose View in Browser from the menu. Click Yes when prompted to save.
8. The GridView displays the data from the Products table.

## Exercise 2 - Editing Data with the SqlDataSource Control

The following exercise demonstrates how to data bind a DropDownList control using the declarative syntax and allows you to edit the data presented in the DropDownList control.

1. In Design view, delete the GridView control from Default.aspx. 

    **Important**: Leave the SqlDataSource control on the page.
2. Add a DropDownList control to Default.aspx.
3. Switch to Source view.
4. Add a DataSourceId, DataTextField, and DataValueField attribute to the &lt;asp:DropDownList&gt; control as follows: 

    [!code-aspx[Main](data-source-controls/samples/sample8.aspx)]
5. Save Default.aspx and view it in the browser. Note that the DropDownList contains all of the products from the Northwind database.
6. Close the browser.
7. In Source view of Default.aspx, add a new TextBox control below the DropDownList control. Change the ID property of the TextBox to txtProductName.
8. Under the TextBox control, add a new Button control. Change the ID property of the Button to btnUpdate and the Text property to **Update Product Name**.
9. In Source view of Default.aspx, add an UpdateCommand property and two new UpdateParameters to the SqlDataSource tag as follows: 

    [!code-aspx[Main](data-source-controls/samples/sample9.aspx)]

    > [!NOTE]
    > Note that there are two update parameters (ProductName and ProductID) added in this code. These parameters are mapped to the Text property of the txtProductName TextBox and the SelectedValue property of the ddlProducts DropDownList.
10. Switch to Design view and double-click on the Button control to add an event handler.
11. Add the following code to the btnUpdate\_Click code: 

    [!code-csharp[Main](data-source-controls/samples/sample10.cs)]
12. Right-click on Default.aspx and choose to view it in the browser. Click Yes when prompted to save all changes.
13. ASP.NET 2.0 partial classes allow for compilation at runtime. It is not necessary to build an application in order to see code changes take effect.
14. Select a product from the DropDownList.
15. Enter a new name for the selected product in the TextBox and then click the Update button.
16. The product name is updated in the database.

## Exercise 3 Using the ObjectDataSource Control

This exercise will demonstrate how to use the ObjectDataSource control and a source object to interact with the Northwind database.

1. Right-click on the project in Solution Explorer and click on Add New Item.
2. Select Web Form in the templates list. Change the name to object.aspx and click Add.
3. Right-click on the project in Solution Explorer and click on Add New Item.
4. Select Class in the templates list. Change the name of the class to NorthwindData.cs and click Add.
5. Click Yes when prompted to add the class to the App\_Code folder.
6. Add the following code to the NorthwindData.cs file: 

    [!code-csharp[Main](data-source-controls/samples/sample11.cs)]
7. Add the following code to the Source view of object.aspx: 

    [!code-aspx[Main](data-source-controls/samples/sample12.aspx)]
8. Save all files and browse object.aspx.
9. Interact with the interface by viewing details, editing employees, adding employees, and deleting employees.