---
uid: web-pages/overview/data/5-working-with-data
title: "Introduction to Working with a Database in ASP.NET Web Pages (Razor) Sites | Microsoft Docs"
author: tfitzmac
description: "This chapter describes how to access data from a database and display it using ASP.NET Web Pages."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/18/2014
ms.topic: article
ms.assetid: 673d502f-2c16-4a6f-bb63-dbfd9a77ef47
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/data/5-working-with-data
msc.type: authoredcontent
---
Introduction to Working with a Database in ASP.NET Web Pages (Razor) Sites
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This article describes how to use Microsoft WebMatrix tools to create a database in an ASP.NET Web Pages (Razor) website, and how to create pages that let you display, add, edit, and delete data.
> 
> **What you'll learn:** 
> 
> - How to create a database.
> - How to connect to a database.
> - How to display data in a web page.
> - How to insert, update, and delete database records.
> 
> These are the features introduced in the article:
> 
> - Working with a Microsoft SQL Server Compact Edition database.
> - Working with SQL queries.
> - The `Database` class.
>   
> 
> ## Software versions used in the tutorial
> 
> 
> - ASP.NET Web Pages (Razor) 2
> - WebMatrix 2
>   
> 
> This tutorial also works with WebMatrix 3. You can use ASP.NET Web Pages 3 and Visual Studio 2013 (or Visual Studio Express 2013 for Web); however, the user interface will be different.


## Introduction to Databases

Imagine a typical address book. For each entry in the address book (that is, for each person) you have several pieces of information such as first name, last name, address, email address, and phone number.

A typical way to picture data like this is as a table with rows and columns. In database terms, each row is often referred to as a record. Each column (sometimes referred to as fields) contains a value for each type of data: first name, last name, and so on.

| **ID** | **FirstName** | **LastName** | **Address** | **Email** | **Phone** |
| --- | --- | --- | --- | --- | --- |
| 1 | Jim | Abrus | 210 100th St SE Orcas WA 98031 | jim@contoso.com | 555 0100 |
| 2 | Terry | Adams | 1234 Main St. Seattle WA 99011 | terry@cohowinery.com | 555 0101 |

For most database tables, the table has to have a column that contains a unique identifier, like a customer number, account number, etc. This is known as the table's *primary key*, and you use it to identify each row in the table. In the example, the ID column is the primary key for the address book.

With this basic understanding of databases, you're ready to learn how to create a simple database and perform operations such as adding, modifying, and deleting data.

> [!TIP] 
> 
> **Relational Databases**
> 
> You can store data in lots of ways, including text files and spreadsheets. For most business uses, though, data is stored in a relational database.
> 
> This article doesn't go very deeply into databases. However, you might find it useful to understand a little about them. In a relational database, information is logically divided into separate tables. For example, a database for a school might contain separate tables for students and for class offerings. The database software (such as SQL Server) supports powerful commands that let you dynamically establish relationships between the tables. For example, you can use the relational database to establish a logical relationship between students and classes in order to create a schedule. Storing data in separate tables reduces the complexity of the table structure and reduces the need to keep redundant data in tables.


## Creating a Database

This procedure shows you how to create a database named SmallBakery by using the SQL Server Compact Database design tool that's included in WebMatrix. Although you can create a database using code, it's more typical to create the database and database tables using a design tool like WebMatrix.

1. Start WebMatrix, and on the Quick Start page, click **Site From Template**.
2. Select **Empty Site**, and in the **Site Name** box enter "SmallBakery" and then click **OK**. The site is created and displayed in WebMatrix.
3. In the left pane, click the **Databases** workspace.
4. In the ribbon, click **New Database**. An empty database is created with the same name as your site.
5. In the left pane, expand the **SmallBakery.sdf** node and then click **Tables**.
6. In the ribbon, click **New Table**. WebMatrix opens the table designer.

    ![[image]](5-working-with-data/_static/image1.jpg)
7. Click in the **Name** column and enter &quot;Id&quot;.
8. In the **Data Type** column, select **int**.
9. Set the **Is Primary Key?** and **Is Identify?** options to **Yes**.

    As the name suggests, **Is Primary Key** tells the database that this will be the table's primary key. **Is Identity** tells the database to automatically create an ID number for every new record and to assign it the next sequential number (starting at 1).
10. Click in the next row. The editor starts a new column definition.
11. For the Name value, enter &quot;Name&quot;.
12. For **Data Type**, choose &quot;nvarchar&quot; and set the length to 50. The *var* part of `nvarchar` tells the database that the data for this column will be a string whose size might vary from record to record. (The *n* prefix represents *national*, indicating that the field can hold character data that represents any alphabet or writing system &#8212; that is, that the field holds Unicode data.)
13. Set the **Allow Nulls** option to **No**. This will enforce that the *Name* column is not left blank.
14. Using this same process, create a column named *Description*. Set **Data Type** to "nvarchar" and 50 for the length, and set **Allow Nulls** to false.
15. Create a column named *Price*. Set **Data Type to "money"** and set **Allow Nulls** to false.
16. In the box at the top, name the table &quot;Product&quot;.

    When you're done, the definition will look like this:

    ![[image]](5-working-with-data/_static/image2.jpg)
17. Press Ctrl+S to save the table.

## Adding Data to the Database

Now you can add some sample data to your database that you'll work with later in the article.

1. In the left pane, expand the **SmallBakery.sdf** node and then click **Tables**.
2. Right-click the Product table and then click **Data**.
3. In the edit pane, enter the following records:

    | **Name** | **Description** | **Price** |
    | --- | --- | --- |
    | Bread | Baked fresh every day. | 2.99 |
    | Strawberry Shortcake | Made with organic strawberries from our garden. | 9.99 |
    | Apple Pie | Second only to your mom's pie. | 12.99 |
    | Pecan Pie | If you like pecans, this is for you. | 10.99 |
    | Lemon Pie | Made with the best lemons in the world. | 11.99 |
    | Cupcakes | Your kids and the kid in you will love these. | 7.99 |

    Remember that you don't have to enter anything for the *Id* column. When you created the *Id* column, you set its **Is Identity** property to true, which causes it to automatically be filled in.

    When you're finished entering the data, the table designer will look like this:

    ![[image]](5-working-with-data/_static/image3.jpg)
4. Close the tab that contains the database data.

## Displaying Data from a Database

Once you've got a database with data in it, you can display the data in an ASP.NET web page. To select the table rows to display, you use a SQL statement, which is a command that you pass to the database.

1. In the left pane, click the **Files** workspace.
2. In the root of the website, create a new CSHTML page named *ListProducts.cshtml*.
3. Replace the existing markup with the following:

    [!code-cshtml[Main](5-working-with-data/samples/sample1.cshtml)]

    In the first code block, you open the *SmallBakery.sdf* file (database) that you created earlier. The `Database.Open` method assumes that the *.sdf* file is in your website's *App\_Data* folder. (Notice that you don't need to specify the *.sdf* extension &#8212; in fact, if you do, the `Open` method won't work.)

    > [!NOTE]
    > The *App\_Data* folder is a special folder in ASP.NET that's used to store data files. For more information, see [Connecting to a Database](#SB_ConnectingToADatabase) later in this article.

    You then make a request to query the database using the following SQL `Select` statement:

    [!code-sql[Main](5-working-with-data/samples/sample2.sql)]

    In the statement, `Product` identifies the table to query. The `*` character specifies that the query should return all the columns from the table. (You could also list columns individually, separated by commas, if you wanted to see only some of the columns.) The `Order By` clause indicates how the data should be sorted &#8212; in this case, by the *Name* column. This means that the data is sorted alphabetically based on the value of the *Name* column for each row.

    In the body of the page, the markup creates an HTML table that will be used to display the data. Inside the `<tbody>` element, you use a `foreach` loop to individually get each data row that's returned by the query. For each data row, you create an HTML table row (`<tr>` element). Then you create HTML table cells (`<td>` elements) for each column. Each time you go through the loop, the next available row from the database is in the `row` variable (you set this up in the `foreach` statement). To get an individual column from the row, you can use `row.Name` or `row.Description` or whatever the name is of the column you want.
4. Run the page in a browser. (Make sure the page is selected in the **Files** workspace before you run it.) The page displays a list like the following:

    ![[image]](5-working-with-data/_static/image4.jpg)

> [!TIP] 
> 
> **Structured Query Language (SQL)**
> 
> SQL is a language that's used in most relational databases for managing data in a database. It includes commands that let you retrieve data and update it, and that let you create, modify, and manage database tables. SQL is different than a programming language (like the one you're using in WebMatrix) because with SQL, the idea is that you tell the database what you want, and it's the database's job to figure out how to get the data or perform the task. Here are examples of some SQL commands and what they do:
> 
> `SELECT Id, Name, Price FROM Product WHERE Price > 10.00 ORDER BY Name`
> 
> This fetches the *Id*, *Name*, and *Price* columns from records in the *Product* table if the value of *Price* is more than 10, and returns the results in alphabetical order based on the values of the *Name* column. This command will return a result set that contains the records that meet the criteria, or an empty set if no records match.
> 
> `INSERT INTO Product (Name, Description, Price) VALUES ("Croissant", "A flaky delight", 1.99)`
> 
> This inserts a new record into the *Product* table, setting the *Name* column to &quot;Croissant&quot;, the *Description* column to &quot;A flaky delight&quot;, and the price to 1.99.
> 
> `DELETE FROM Product WHERE ExpirationDate < "01/01/2008"`
> 
> This command deletes records in the *Product* table whose expiration date column is earlier than January 1, 2008. (This assumes that the *Product* table has such a column, of course.) The date is entered here in MM/DD/YYYY format, but it should be entered in the format that's used for your locale.
> 
> The `Insert Into` and `Delete` commands don't return result sets. Instead, they return a number that tells you how many records were affected by the command.
> 
> For some of these operations (like inserting and deleting records), the process that's requesting the operation has to have appropriate permissions in the database. This is why for production databases you often have to supply a username and password when you connect to the database.
> 
> There are dozens of SQL commands, but they all follow a pattern like this. You can use SQL commands to create database tables, count the number of records in a table, calculate prices, and perform many more operations.


## Inserting Data in a Database

This section shows how to create a page that lets users add a new product to the *Product* database table. After a new product record is inserted, the page displays the updated table using the *ListProducts.cshtml* page that you created in the previous section.

The page includes validation to make sure that the data that the user enters is valid for the database. For example, code in the page makes sure that a value has been entered for all required columns.

1. In the website, create a new CSHTML file named *InsertProducts.cshtml*.
2. Replace the existing markup with the following:

    [!code-cshtml[Main](5-working-with-data/samples/sample3.cshtml)]

    The body of the page contains an HTML form with three text boxes that let users enter a name, description, and price. When users click the **Insert** button, the code at the top of the page opens a connection to the *SmallBakery.sdf* database. You then get the values that the user has submitted by using the `Request` object and assign those values to local variables.

    To validate that the user entered a value for each required column, you register each `<input>` element that you want to validate:

    [!code-csharp[Main](5-working-with-data/samples/sample4.cs)]

    The `Validation` helper checks that there is a value in each of the fields that you've registered. You can test whether all the fields passed validation by checking `Validation.IsValid()`, which you typically do before you process the information you get from the user:

    [!code-csharp[Main](5-working-with-data/samples/sample5.cs)]

    (The `&&` operator means AND — this test is *If this is a form submission AND all the fields have passed validation*.)

    If all the columns validated (none were empty), you go ahead and create a SQL statement to insert the data and then execute it as shown next:

    [!code-csharp[Main](5-working-with-data/samples/sample6.cs)]

    For the values to insert, you include parameter placeholders (`@0`, `@1`, `@2`).

    > [!NOTE]
    > As a security precaution, always pass values to a SQL statement using parameters, as you see in the preceding example. This gives you a chance to validate the user's data, plus it helps protect against attempts to send malicious commands to your database (sometimes referred to as SQL injection attacks).

    To execute the query, you use this statement, passing to it the variables that contain the values to substitute for the placeholders:

    [!code-csharp[Main](5-working-with-data/samples/sample7.cs)]

    After the `Insert Into` statement has executed, you send the user to the page that lists the products using this line:

    [!code-javascript[Main](5-working-with-data/samples/sample8.js)]

    If validation didn't succeed, you skip the insert. Instead, you have a helper in the page that can display the accumulated error messages (if any):

    [!code-cshtml[Main](5-working-with-data/samples/sample9.cshtml)]

    Notice that the style block in the markup includes a CSS class definition named `.validation-summary-errors`. This is the name of the CSS class that's used by default for the `<div>` element that contains any validation errors. In this case, the CSS class specifies that validation summary errors are displayed in red and in bold, but you can define the `.validation-summary-errors` class to display any formatting you like.

### Testing the Insert Page

1. View the page in a browser. The page displays a form that's similar to the one that's shown in the following illustration.

    ![[image]](5-working-with-data/_static/image5.jpg)
2. Enter values for all the columns, but make sure that you leave the *Price* column blank.
3. Click **Insert**. The page displays an error message, as shown in the following illustration. (No new record is created.)

    ![[image]](5-working-with-data/_static/image6.jpg)
4. Fill the form out completely, and then click **Insert**. This time, the *ListProducts.cshtml* page is displayed and shows the new record.

## Updating Data in a Database

After data has been entered into a table, you might need to update it. This procedure shows you how to create two pages that are similar to the ones you created for data insertion earlier. The first page displays products and lets users select one to change. The second page lets the users actually make the edits and save them.

> [!NOTE] 
> 
> **Important** In a production website, you typically restrict who's allowed to make changes to the data. For information about how to set up membership and about ways to authorize users to perform tasks on the site, see [Adding Security and Membership to an ASP.NET Web Pages Site](https://go.microsoft.com/fwlink/?LinkId=202904).


1. In the website, create a new CSHTML file named *EditProducts.cshtml*.
2. Replace the existing markup in the file with the following:

    [!code-cshtml[Main](5-working-with-data/samples/sample10.cshtml)]

    The only difference between this page and the *ListProducts.cshtml* page from earlier is that the HTML table in this page includes an extra column that displays an **Edit** link. When you click this link, it takes you to the *UpdateProducts.cshtml* page (which you'll create next) where you can edit the selected record.

    Look at the code that creates the **Edit** link:

    [!code-cshtml[Main](5-working-with-data/samples/sample11.cshtml)]

    This creates an HTML `<a>` element whose `href` attribute is set dynamically. The `href` attribute specifies the page to display when the user clicks the link. It also passes the `Id` value of the current row to the link. When the page runs, the page source might contain links like these:

    [!code-html[Main](5-working-with-data/samples/sample12.html)]

    Notice that the `href` attribute is set to `UpdateProducts/n`, where *n* is a product number. When a user clicks one of these links, the resulting URL will look something like this:

    `http://localhost:18816/UpdateProducts/6`

    In other words, the product number to be edited will be passed in the URL.
3. View the page in a browser. The page displays the data in a format like this:

    ![[image]](5-working-with-data/_static/image7.jpg)

    Next, you'll create the page that lets users actually update the data. The update page includes validation to validate the data that the user enters. For example, code in the page makes sure that a value has been entered for all required columns.
4. In the website, create a new CSHTML file named *UpdateProducts.cshtml*.
5. Replace the existing markup in the file with the following.

    [!code-cshtml[Main](5-working-with-data/samples/sample13.cshtml)]

    The body of the page contains an HTML form where a product is displayed and where users can edit it. To get the product to display, you use this SQL statement:

    [!code-sql[Main](5-working-with-data/samples/sample14.sql)]

    This will select the product whose ID matches the value that's passed in the `@0` parameter. (Because *Id* is the primary key and therefore must be unique, only one product record can ever be selected this way.) To get the ID value to pass to this `Select` statement, you can read the value that's passed to the page as part of the URL, using the following syntax:

    [!code-csharp[Main](5-working-with-data/samples/sample15.cs)]

    To actually fetch the product record, you use the `QuerySingle` method, which will return just one record:

    [!code-csharp[Main](5-working-with-data/samples/sample16.cs)]

    The single row is returned into the `row` variable. You can get data out of each column and assign it to local variables like this:

    [!code-csharp[Main](5-working-with-data/samples/sample17.cs)]

    In the markup for the form, these values are displayed automatically in individual text boxes by using embedded code like the following:

    [!code-html[Main](5-working-with-data/samples/sample18.html)]

    That part of the code displays the product record to be updated. Once the record has been displayed, the user can edit individual columns.

    When the user submits the form by clicking the **Update** button, the code in the `if(IsPost)` block runs. This gets the user's values from the `Request` object, stores the values in variables, and validates that each column has been filled in. If validation passes, the code creates the following SQL Update statement:

    [!code-sql[Main](5-working-with-data/samples/sample19.sql)]

    In a SQL `Update` statement, you specify each column to update and the value to set it to. In this code, the values are specified using the parameter placeholders `@0`, `@1`, `@2`, and so on. (As noted earlier, for security, you should always pass values to a SQL statement by using parameters.)

    When you call the `db.Execute` method, you pass the variables that contain the values in the order that corresponds to the parameters in the SQL statement:

    [!code-csharp[Main](5-working-with-data/samples/sample20.cs)]

    After the `Update` statement has been executed, you call the following method in order to redirect the user back to the edit page:

    [!code-cshtml[Main](5-working-with-data/samples/sample21.cshtml)]

    The effect is that the user sees an updated listing of the data in the database and can edit another product.
6. Save the page.
7. Run the *EditProducts.cshtml* page (not the update page) and then click **Edit** to select a product to edit. The *UpdateProducts.cshtml* page is displayed, showing the record you selected.

    ![[image]](5-working-with-data/_static/image8.jpg)
8. Make a change and click **Update**. The products list is shown again with your updated data.

## Deleting Data in a Database

This section shows how to let users delete a product from the *Product* database table. The example consists of two pages. In the first page, users select a record to delete. The record to be deleted is then displayed in a second page that lets them confirm that they want to delete the record.

> [!NOTE] 
> 
> **Important** In a production website, you typically restrict who's allowed to make changes to the data. For information about how to set up membership and about ways to authorize user to perform tasks on the site, see [Adding Security and Membership to an ASP.NET Web Pages Site](https://go.microsoft.com/fwlink/?LinkId=202904).


1. In the website, create a new CSHTML file named *ListProductsForDelete.cshtml*.
2. Replace the existing markup with the following:

    [!code-cshtml[Main](5-working-with-data/samples/sample22.cshtml)]

    This page is similar to the *EditProducts.cshtml* page from earlier. However, instead of displaying an **Edit** link for each product, it displays a **Delete** link. The **Delete** link is created using the following embedded code in the markup:

    [!code-cshtml[Main](5-working-with-data/samples/sample23.cshtml)]

    This creates a URL that looks like this when users click the link:

    `http://<server>/DeleteProduct/4`

    The URL calls a page named *DeleteProduct.cshtml* (which you'll create next) and passes it the ID of the product to delete (here, 4).
3. Save the file, but leave it open.
4. Create another CHTML file named *DeleteProduct.cshtml*. Replace the existing content with the following:

    [!code-cshtml[Main](5-working-with-data/samples/sample24.cshtml)]

    This page is called by *ListProductsForDelete.cshtml* and lets users confirm that they want to delete a product. To list the product to be deleted, you get the ID of the product to delete from the URL using the following code:

    [!code-csharp[Main](5-working-with-data/samples/sample25.cs)]

    The page then asks the user to click a button to actually delete the record. This is an important security measure: when you perform sensitive operations in your website like updating or deleting data, these operations should always be done using a POST operation, not a GET operation. If your site is set up so that a delete operation can be performed using a GET operation, anyone can pass a URL like `http://<server>/DeleteProduct/4` and delete anything they want from your database. By adding the confirmation and coding the page so that the deletion can be performed only by using a POST, you add a measure of security to your site.

    The actual delete operation is performed using the following code, which first confirms that this is a post operation and that the ID isn't empty:

    [!code-csharp[Main](5-working-with-data/samples/sample26.cs)]

    The code runs a SQL statement that deletes the specified record and then redirects the user back to the listing page.
5. Run *ListProductsForDelete.cshtml* in a browser.

    ![[image]](5-working-with-data/_static/image9.jpg)
6. Click the **Delete** link for one of the products. The *DeleteProduct.cshtml* page is displayed to confirm that you want to delete that record.
7. Click the **Delete** button. The product record is deleted and the page is refreshed with an updated product listing.

> [!TIP] 
> 
> <a id="SB_ConnectingToADatabase"></a>
> ### Connecting to a Database
> 
> You can connect to a database in two ways. The first is to use the `Database.Open` method and to specify the name of the database file (less the *.sdf* extension):
> 
> `var db = Database.Open("SmallBakery");`
> 
> The `Open` method assumes that the .*sdf* file is in the website's *App\_Data* folder. This folder is designed specifically for holding data. For example, it has appropriate permissions to allow the website to read and write data, and as a security measure, WebMatrix does not allow access to files from this folder.
> 
> The second way is to use a connection string. A connection string contains information about how to connect to a database. This can include a file path, or it can include the name of a SQL Server database on a local or remote server, along with a user name and password to connect to that server. (If you keep data in a centrally managed version of SQL Server, such as on a hosting provider's site, you always use a connection string to specify the database connection information.)
> 
> In WebMatrix, connection strings are usually stored in an XML file named *Web.config*. As the name implies, you can use a *Web.config* file in the root of your website to store the site's configuration information, including any connection strings that your site might require. An example of a connection string in a *Web.config* file might look like the following:
> 
> [!code-xml[Main](5-working-with-data/samples/sample27.xml)]
> 
> In the example, the connection string points to a database in an instance of SQL Server that's running on a server somewhere (as opposed to a local *.sdf* file). You would need to substitute the appropriate names for `myServer` and `myDatabase`, and specify SQL Server login values for `username` and `password`. (The username and password values are not necessarily the same as your Windows credentials or as the values that your hosting provider has given you for logging in to their servers. Check with the administrator for the exact values you need.)
> 
> The `Database.Open` method is flexible, because it lets you pass either the name of a database *.sdf* file or the name of a connection string that's stored in the *Web.config* file. The following example shows how to connect to the database using the connection string illustrated in the previous example:
> 
> [!code-cshtml[Main](5-working-with-data/samples/sample28.cshtml)]
> 
> As noted, the `Database.Open` method lets you pass either a database name or a connection string, and it'll figure out which to use. This is very useful when you deploy (publish) your website. You can use an *.sdf* file in the *App\_Data* folder when you're developing and testing your site. Then when you move your site to a production server, you can use a connection string in the *Web.config* file that has the same name as your *.sdf* file but that points to the hosting provider's database &#8212; all without having to change your code.
> 
> Finally, if you want to work directly with a connection string, you can call the `Database.OpenConnectionString` method and pass it the actual connection string instead of just the name of one in the *Web.config* file. This might be useful in situations where for some reason you don't have access to the connection string (or values in it, such as the *.sdf* file name) until the page is running. However, for most scenarios, you can use `Database.Open` as described in this article.


## Additional Resources

- [SQL Server Compact](https://www.microsoft.com/sqlserver/2008/en/us/compact.aspx)
- [Connecting to a SQL Server or MySQL Database in WebMatrix](https://go.microsoft.com/fwlink/?LinkId=208661)
- [Validating User Input in ASP.NET Web Pages Sites](https://go.microsoft.com/fwlink/?LinkId=253002)