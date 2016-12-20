---
title: "Create a Singleton in OData v4 Using Web API 2.2 | Microsoft Docs"
author: rick-anderson
description: "This topic shows how to define a singleton in an OData endpoint in Web API 2.2."
ms.author: riande
manager: wpickett
ms.date: 06/27/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-v4/using-a-singleton-in-an-odata-endpoint-in-web-api-22
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-api\overview\odata-support-in-aspnet-web-api\odata-v4\using-a-singleton-in-an-odata-endpoint-in-web-api-22.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/58351) | [View dev content](http://docs.aspdev.net/tutorials/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/using-a-singleton-in-an-odata-endpoint-in-web-api-22.html) | [View prod content](http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/using-a-singleton-in-an-odata-endpoint-in-web-api-22) | Picker: 58360

Create a Singleton in OData v4 Using Web API 2.2
====================
by Zoe Luo

> Traditionally, an entity could only be accessed if it were encapsulated inside an entity set. But OData v4 provides two additional options, Singleton and Containment, both of which WebAPI 2.2 supports.


This article shows how to define a singleton in an OData endpoint in Web API 2.2. For information on what a singleton is and how you can benefit from using it, see [Using a singleton to define your special entity](https://blogs.msdn.com/b/odatateam/archive/2014/03/05/use-singleton-to-define-your-special-entity.aspx). To create an OData V4 endpoint in Web API, see [Create an OData v4 Endpoint Using ASP.NET Web API 2.2](create-an-odata-v4-endpoint.md). 

We'll create a singleton in your Web API project using the following data model:

![Data Model](using-a-singleton-in-an-odata-endpoint-in-web-api-22/_static/image1.png)

A singleton named `Umbrella` will be defined based on type `Company`, and an entity set named `Employees` will be defined based on type `Employee`.

The solution used in this tutorial can be downloaded from [CodePlex](http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/OData/v4/ODataSingletonSample/).

## Define the data model

1. Define the CLR types.

        /// <summary> 
        /// Present the EntityType "Employee" 
        /// </summary> 
        public class Employee 
        {     
            public int ID { get; set; }     
            public string Name { get; set; }  
           
            [Singleton]     
            public Company Company { get; set; } 
        } 
        /// <summary> 
        /// Present company category, which is an enum type 
        /// </summary> 
        public enum CompanyCategory 
        { 
            IT = 0,     
            Communication = 1,     
            Electronics = 2,     
            Others = 3 
        } 
        /// <summary> 
        /// Present the EntityType "Company" 
        /// </summary> 
        public class Company 
        {
             public int ID { get; set; }
             public string Name { get; set; }
             public Int64 Revenue { get; set; }
             public CompanyCategory Category { get; set; }
             public List<Employee> Employees { get; set; } 
        }
2. Generate the EDM model based on the CLR types.

        public static IEdmModel GetEdmModel() 
        { 
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Employee>("Employees"); builder.Singleton<Company>("Umbrella");
            builder.Namespace = typeof(Company).Namespace;
            return builder.GetEdmModel(); 
        }

    Here, `builder.Singleton<Company>("Umbrella")` tells the model builder to create a singleton named `Umbrella` in the EDM model.

    The generated metadata will look like the following:

        <EntityContainer Name="Container"> 
          <EntitySet Name="Employees" EntityType="ODataSingletonSample.Employee"> 
            <NavigationPropertyBinding Path="Company" Target="Umbrella"/> 
          </EntitySet> 
          <Singleton Name="Umbrella" Type="ODataSingletonSample.Company"> 
            <NavigationPropertyBinding Path="Employees" Target="Employees"/> 
          </Singleton> 
        </EntityContainer>

    From the metadata we can see that the navigation property `Company` in the `Employees` entity set is bound to the singleton `Umbrella`. The binding is done automatically by `ODataConventionModelBuilder`, since only `Umbrella` has the `Company` type. If there is any ambiguity in the model, you can use `HasSingletonBinding` to explicitly bind a navigation property to a singleton; `HasSingletonBinding` has the same effect as using the `Singleton` attribute in the CLR type definition:

        EntitySetConfiguration<Employee> employeesConfiguration = 
            builder.EntitySet<Employee>("Employees"); 
        employeesConfiguration.HasSingletonBinding(c => c.Company, "Umbrella");

## Define the singleton controller

Like the EntitySet controller, the singleton controller inherits from `ODataController`, and the singleton controller name should be `[singletonName]Controller`.

    public class UmbrellaController : ODataController 
    {
        public static Company Umbrella;
        static UmbrellaController()
        {
            InitData();
        }
        private static void InitData()
        {
            Umbrella = new Company()
            {
                ID = 1,
                Name = "Umbrella",
                Revenue = 1000,
                Category = CompanyCategory.Communication,
                Employees = new List<Employee>()
            };
        } 
    }

In order to handle different kinds of requests, actions are required to be pre-defined in the controller. **Attribute routing** is enabled by default in WebApi 2.2. For example, to define an action to handle querying `Revenue` from `Company` using attribute routing, use the following:

    [ODataRoute("Umbrella/Revenue")] 
    public IHttpActionResult GetCompanyRevenue() 
    {
         return Ok(Umbrella.Revenue); 
    }

If you are not willing to define attributes for each action, just define your actions following [OData Routing Conventions](../odata-routing-conventions.md). Since a key is not required for querying a singleton, the actions defined in the singleton controller are slightly different from actions defined in the entityset controller.

For reference, method signatures for every action definition in the singleton controller are listed below.

    // Get Singleton 
    // ~/singleton 
    public IHttpActionResult Get() 
    public IHttpActionResult GetUmbrella() 
    
    // Get Singleton 
    // ~/singleton/cast 
    public IHttpActionResult GetFromSubCompany() 
    public IHttpActionResult GetUmbrellaFromSubCompany() 
    
    // Get Singleton Property 
    // ~/singleton/property  
    public IHttpActionResult GetName() 
    public IHttpActionResult GetNameFromCompany() 
    
    // Get Singleton Navigation Property 
    // ~/singleton/navigation  
    public IHttpActionResult GetEmployees() 
    public IHttpActionResult GetEmployeesFromCompany() 
    
    // Update singleton by PUT 
    // PUT ~/singleton 
    public IHttpActionResult Put(Company newCompany) 
    public IHttpActionResult PutUmbrella(Company newCompany) 
    
    // Update singleton by Patch 
    // PATCH ~/singleton 
    public IHttpActionResult Patch(Delta<Company> item) 
    public IHttpActionResult PatchUmbrella(Delta<Company> item) 
    
    // Add navigation link to singleton 
    // POST ~/singleton/navigation/$ref 
    public IHttpActionResult CreateRef(string navigationProperty, [FromBody] Uri link) 
    
    // Delete navigation link from singleton 
    // DELETE ~/singleton/navigation/$ref?$id=~/relatedKey 
    public IHttpActionResult DeleteRef(string relatedKey, string navigationProperty) 
    
    // Add a new entity to singleton navigation property 
    // POST ~/singleton/navigation 
    public IHttpActionResult PostToEmployees([FromBody] Employee employee) 
    
    // Call function bounded to singleton 
    // GET ~/singleton/function() 
    public IHttpActionResult GetEmployeesCount()

Basically, this is all you need to do on the service side. The [sample project](http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/OData/v4/ODataSingletonSample/) contains all of the code for the solution and the OData client that shows how to use the singleton. The client is built by following the steps in [Create an OData v4 Client App](create-an-odata-v4-client-app.md).

. 

*Thanks to Leo Hu for the original content of this article.*