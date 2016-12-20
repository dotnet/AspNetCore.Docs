---
title: "Security Guidance for ASP.NET Web API 2 OData | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 02/06/2013
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-security-guidance
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-api\overview\odata-support-in-aspnet-web-api\odata-security-guidance.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/43771) | [View dev content](http://docs.aspdev.net/tutorials/web-api/overview/odata-support-in-aspnet-web-api/odata-security-guidance.html) | [View prod content](http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-security-guidance) | Picker: 43777

Security Guidance for ASP.NET Web API 2 OData
====================
by [Mike Wasson](https://github.com/MikeWasson)

This topic describes some of the security issues that you should consider when exposing a dataset through OData.

## EDM Security

The query semantics are based on the entity data model (EDM), not the underlying model types. You can exclude a property from the EDM and it will not be visible to the query. For example, suppose your model includes an Employee type with a Salary property. You might want to exclude this property from the EDM to hide it from clients.

There are two ways to exlude a property from the EDM. You can set the **[IgnoreDataMember]** attribute on the property in the model class:

    public class Employee
    {
        public string Name { get; set; }
        public string Title { get; set; }
        [IgnoreDataMember]
        public decimal Salary { get; set; } // Not visible in the EDM
    }

You can also remove the property from the EDM programmatically:

    var employees = modelBuilder.EntitySet<Employee>("Employees");
    employees.EntityType.Ignore(emp => emp.Salary);

## Query Security

A malicious or naive client may be able to construct a query that takes a very long time to execute. In the worst case this can disrupt access to your service.

The **[Queryable]** attribute is an action filter that parses, validates, and applies the query. The filter converts the query options into a LINQ expression. When the OData controller returns an **IQueryable** type, the **IQueryable** LINQ provider converts the LINQ expression into a query. Therefore, performance depends on the LINQ provider that is used, and also on the particular characteristics of your dataset or database schema.

For more information about using OData query options in ASP.NET Web API, see [Supporting OData Query Options](supporting-odata-query-options.md).

If you know that all clients are trusted (for example, in an enterprise environment), or if your dataset is small, query performance might not be an issue. Otherwise, you should consider the following recommendations.

- Test your service with various queries and profile the DB.
- Enable server-driven paging, to avoid returning a large data set in one query. For more information, see [Server-Driven Paging](supporting-odata-query-options.md#server-paging). 

        // Enable server-driven paging.
        [Queryable(PageSize=10)]
- Do you need $filter and $orderby? Some applications might allow client paging, using $top and $skip, but disable the other query options. 

        // Allow client paging but no other query options.
        [Queryable(AllowedQueryOptions=AllowedQueryOptions.Skip | 
                                       AllowedQueryOptions.Top)]
- Consider restricting $orderby to properties in a clustered index. Sorting large data without a clustered index is slow. 

        // Set the allowed $orderby properties.
        [Queryable(AllowedOrderByProperties="Id,Name")] // Comma separated list
- Maximum node count: The **MaxNodeCount** property on **[Queryable]** sets the maximum number nodes allowed in the $filter syntax tree. The default value is 100, but you may want to set a lower value, because a large number of nodes can be slow to compile. This is particularly true if you are using LINQ to Objects (i.e., LINQ queries on a collection in memory, without the use of an intermediate LINQ provider). 

        // Set the maximum node count.
        [Queryable(MaxNodeCount=20)]
- Consider disabling the any() and all() functions, as these can be slow. 

        // Disable any() and all() functions.
        [Queryable(AllowedFunctions= AllowedFunctions.AllFunctions & 
            ~AllowedFunctions.All & ~AllowedFunctions.Any)]
- If any string properties contain large strings&#8212for example, a product description or a blog entry&#8212consider disabling the string functions. 

        // Disable string functions.
        [Queryable(AllowedFunctions=AllowedFunctions.AllFunctions & 
            ~AllowedFunctions.AllStringFunctions)]
- Consider disallowing filtering on navigation properties. Filtering on navigation properties can result in a join, which might be slow, depending on your database schema. The following code shows a query validator that prevents filtering on navigation properties. For more information about query validators, see [Query Validation](supporting-odata-query-options.md#query-validation). 

        // Validator to prevent filtering on navigation properties.
        public class MyFilterQueryValidator : FilterQueryValidator
        {
            public override void ValidateNavigationPropertyNode(
                Microsoft.Data.OData.Query.SemanticAst.QueryNode sourceNode, 
                Microsoft.Data.Edm.IEdmNavigationProperty navigationProperty, 
                ODataValidationSettings settings)
            {
                throw new ODataException("No navigation properties");
            }
        }
- Consider restricting $filter queries by writing a validator that is customized for your database. For example, consider these two queries: 

    - All movies with actors whose last name starts with ‘A'.
    - All movies released in 1994.

    Unless movies are indexed by actors, the first query might require the DB engine to scan the entire list of movies. Whereas the second query might be acceptable, assuming movies are indexed by release year.

    The following code shows a validator that allows filtering on the "ReleaseYear" and "Title" properties but no other properties.

        // Validator to restrict which properties can be used in $filter expressions.
        public class MyFilterQueryValidator : FilterQueryValidator
        {
            static readonly string[] allowedProperties = { "ReleaseYear", "Title" };
        
            public override void ValidateSingleValuePropertyAccessNode(
                SingleValuePropertyAccessNode propertyAccessNode,
                ODataValidationSettings settings)
            {
                string propertyName = null;
                if (propertyAccessNode != null)
                {
                    propertyName = propertyAccessNode.Property.Name;
                }
        
                if (propertyName != null && !allowedProperties.Contains(propertyName))
                {
                    throw new ODataException(
                        String.Format("Filter on {0} not allowed", propertyName));
                }
                base.ValidateSingleValuePropertyAccessNode(propertyAccessNode, settings);
            }
        }
- In general, consider which $filter functions you need. If your clients do not need the full expressiveness of $filter, you can limit the allowed functions.