---
title: DevOps with ASP.NET Core and Azure | Next steps
author: CamSoper
description: A guide that provides end-to-end guidance on building a DevOps pipeline for an ASP.NET Core app hosted in Azure.
ms.author: casoper
ms.date: 08/07/2018
uid: azure/devops/next-steps
---
# Next steps

In this guide, you created a DevOps pipeline for an ASP.NET Core sample app. Congratulations! We hope you enjoyed learning to publish ASP.NET Core web apps to Azure App Service and automate the continuous integration of changes.

Beyond web hosting and DevOps, Azure has a wide array of Platform-as-a-Service (PaaS) services useful to ASP.NET Core developers. This section gives a brief overview of some of the most commonly used services.

## Storage and databases

[Redis Cache](https://docs.microsoft.com/azure/redis-cache/) is high-throughput, low-latency data caching available as a service. It can be used for caching page output, reducing database requests, and providing ASP.NET session state across multiple instances of an app.

[Azure Storage](https://docs.microsoft.com/azure/storage/) is Azure's massively scalable cloud storage. Developers can take advantage of [Queue Storage](https://docs.microsoft.com/azure/storage/queues/storage-queues-introduction) for reliable message queuing, and [Table Storage](https://docs.microsoft.com/azure/storage/tables/table-storage-overview) is a NoSQL key-value store designed for rapid development using massive, semi-structured data sets.

[Azure SQL Database](https://docs.microsoft.com/azure/sql-database/) provides familiar relational database functionality as a service using the Microsoft SQL Server Engine.

[Cosmos DB](https://docs.microsoft.com/azure/cosmos-db/) globally distributed, multi-model NoSQL database service. Multiple APIs are available, including SQL API (formerly called DocumentDB), Cassandra, and MongoDB.

## Identity

[Azure Active Directory](https://docs.microsoft.com/azure/active-directory/) and [Azure Active Directory B2C](https://docs.microsoft.com/azure/active-directory-b2c/) are both identity services. Azure Active Directory is designed for enterprise scenarios and enables Azure AD B2B (business-to-business) collaboration, while Azure Active Directory B2C is intended business-to-customer scenarios, including social network sign-in.

## Mobile

[Notification Hubs](https://docs.microsoft.com/azure/notification-hubs/) is a multi-platform, scalable push-notification engine to quickly send millions of messages to apps running on various types of devices.

## Web infrastructure

[Azure Container Service](https://docs.microsoft.com/azure/aks/) manages your hosted Kubernetes environment, making it quick and easy to deploy and manage containerized apps without container orchestration expertise.

[Azure Search](https://docs.microsoft.com/azure/search/) is used to create an enterprise search solution over private, heterogenous content.

[Service Fabric](https://docs.microsoft.com/azure/service-fabric/) is a distributed systems platform that makes it easy to package, deploy, and manage scalable and reliable microservices and containers.
