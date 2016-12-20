---
title: "Containment in OData v4 Using Web API 2.2 | Microsoft Docs"
author: rick-anderson
description: "Traditionally, an entity could only be accessed if it were encapsulated inside an entity set. But OData v4 provides two additional options, Singleton and Con..."
ms.author: riande
manager: wpickett
ms.date: 06/27/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-v4/odata-containment-in-web-api-22
---
Containment in OData v4 Using Web API 2.2
====================
by Jinfu Tan

> Traditionally, an entity could only be accessed if it were encapsulated inside an entity set. But OData v4 provides two additional options, Singleton and Containment, both of which WebAPI 2.2 supports.


This topic shows how to define a containment in an OData endpoint in WebApi 2.2. For more information about containment, see [Containment is coming with OData v4](https://blogs.msdn.com/b/odatateam/archive/2014/03/13/containment-is-coming-with-odata-v4.aspx). To create an OData V4 endpoint in Web API, see [Create an OData v4 Endpoint Using ASP.NET Web API 2.2](create-an-odata-v4-endpoint.md).

First, we'll create a containment domain model in the OData service, using this data model:

![Data model](odata-containment-in-web-api-22/_static/image1.png)

An account contains many PaymentInstruments (PI), but we don't define an entity set for a PI. Instead, the PIs can only be accessed through an Account.

You can download the solution used in this topic from [CodePlex](https://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataContainmentSample/).

## Defining the data model

1. Define the CLR types.

        public class Account     
        {         
            public int AccountID { get; set; }         
            public string Name { get; set; }         
            [Contained]         
            public IList<PaymentInstrument> PayinPIs { get; set; }     
        }     
        
        public class PaymentInstrument     
        {         
            public int PaymentInstrumentID { get; set; }        
            public string FriendlyName { get; set; }     
        }

    The `Contained` attribute is used for containment navigation properties.
2. Generate the EDM model based on the CLR types.

        public static IEdmModel GetModel()         
        {             
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();             
            builder.EntitySet<Account>("Accounts");             
            var paymentInstrumentType = builder.EntityType<PaymentInstrument>();             
            var functionConfiguration = 
                paymentInstrumentType.Collection.Function("GetCount");             
            functionConfiguration.Parameter<string>("NameContains");             
            functionConfiguration.Returns<int>();             
            builder.Namespace = typeof(Account).Namespace;             
            return builder.GetEdmModel();         
        }

    The `ODataConventionModelBuilder` will handle building the EDM model if the `Contained` attribute is added to the corresponding navigation property. If the property is a collection type, a `GetCount(string NameContains)` function will also be created.

    The generated metadata will look like the following:

    [!code[Main](odata-containment-in-web-api-22/samples/sample1.xml?highlight=10)]

    The `ContainsTarget` attribute indicates that the navigation property is a containment.

## Define the containing entity set controller

Contained entities don't have their own controller; the action is defined in the containing entity set controller. In this sample, there is an AccountsController, but no PaymentInstrumentsController.

    public class AccountsController : ODataController     
    {         
        private static IList<Account> _accounts = null;         
        public AccountsController()         
        {             
            if (_accounts == null)             
            {                 
                _accounts = InitAccounts();             
            }         
        }         
        // PUT ~/Accounts(100)/PayinPIs         
        [EnableQuery] 
        public IHttpActionResult GetPayinPIs(int key)         
        {             
            var payinPIs = _accounts.Single(a => a.AccountID == key).PayinPIs;             
            return Ok(payinPIs);         
        }         
        [EnableQuery]         
        [ODataRoute("Accounts({accountId})/PayinPIs({paymentInstrumentId})")]         
        public IHttpActionResult GetSinglePayinPI(int accountId, int paymentInstrumentId)         
        {             
            var payinPIs = _accounts.Single(a => a.AccountID == accountId).PayinPIs;             
            var payinPI = payinPIs.Single(pi => pi.PaymentInstrumentID == paymentInstrumentId);             
            return Ok(payinPI);         
        }         
        // PUT ~/Accounts(100)/PayinPIs(101)         
        [ODataRoute("Accounts({accountId})/PayinPIs({paymentInstrumentId})")]         
        public IHttpActionResult PutToPayinPI(int accountId, int paymentInstrumentId, [FromBody]PaymentInstrument paymentInstrument)         
        {             
            var account = _accounts.Single(a => a.AccountID == accountId);             
            var originalPi = account.PayinPIs.Single(p => p.PaymentInstrumentID == paymentInstrumentId);             
            originalPi.FriendlyName = paymentInstrument.FriendlyName;             
            return Ok(paymentInstrument);         
        }         
        // DELETE ~/Accounts(100)/PayinPIs(101)         
        [ODataRoute("Accounts({accountId})/PayinPIs({paymentInstrumentId})")]         
        public IHttpActionResult DeletePayinPIFromAccount(int accountId, int paymentInstrumentId)         
        {             
            var account = _accounts.Single(a => a.AccountID == accountId);             
            var originalPi = account.PayinPIs.Single(p => p.PaymentInstrumentID == paymentInstrumentId);             
            if (account.PayinPIs.Remove(originalPi))             
            {                 
                return StatusCode(HttpStatusCode.NoContent);             
            }             
            else             
            {                 
                return StatusCode(HttpStatusCode.InternalServerError);             
            }         
        }         
        // GET ~/Accounts(100)/PayinPIs/Namespace.GetCount() 
        [ODataRoute("Accounts({accountId})/PayinPIs/ODataContrainmentSample.GetCount(NameContains={name})")]         
        public IHttpActionResult GetPayinPIsCountWhoseNameContainsGivenValue(int accountId, [FromODataUri]string name)         
        {             
            var account = _accounts.Single(a => a.AccountID == accountId);             
            var count = account.PayinPIs.Where(pi => pi.FriendlyName.Contains(name)).Count();             
            return Ok(count);         
        }         
        private static IList<Account> InitAccounts()         
        {             
            var accounts = new List<Account>() 
            { 
                new Account()                 
                {                    
                    AccountID = 100,                    
                    Name="Name100",                    
                    PayinPIs = new List<PaymentInstrument>()                     
                    {                         
                        new PaymentInstrument()                         
                        {                             
                            PaymentInstrumentID = 101,                             
                            FriendlyName = "101 first PI",                         
                        },                         
                        new PaymentInstrument()                         
                        {                             
                            PaymentInstrumentID = 102,                             
                            FriendlyName = "102 second PI",                         
                        },                     
                    },                 
                },             
            };            
            return accounts;         
        }     
    }

If the OData path is 4 or more segments, only attribute routing works, such as `[ODataRoute("Accounts({accountId})/PayinPIs({paymentInstrumentId})")]` in the above controller. Otherwise, both attribute and conventional routing works: for instance, `GetPayInPIs(int key)` matches `GET ~/Accounts(1)/PayinPIs`.

*Thanks to Leo Hu for the original content of this article.*