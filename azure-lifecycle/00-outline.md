# Azure Developer Lifecycle for .NET Developers

The purpose of this book (or set of docs, or whatever else this project becomes) is to set the minimum bar for a complete .NET development and devops environment on Azure. We shall assume that developers are experienced .Net developers with working knowledge of ASP.NET, SQL Server, and running these technologies on Windows servers. We will not assume cloud/Azure experience. The emphasis is onboarding developers to Azure along with the most productive and high-velocity devops infrastructure. This book will only cover the most common subset of Azure functionality needed for operating popular .Net architectures.  

## Working Outline

1. Introduction/Overview
    * Purpose of book
    * Cloud computing/Azure - High level overview
    * DevOps - High level overview
1. Required Tools and Downloads
    * Azure subscription
    * Visual Studio (and appropriate workload for VS2017)
    * VSTS
1. Deploying an app to Azure
    * Downloading the sample/Architecture overview (should include ASP.NET app & simple SQL Database)
    * Azure web sites & Azure SQL overview (these are used in almost every application being lifted & shifted, even if deployed to VMs)
    * Right-click > Publish scenario & DACPAC/alternative manual deployment
    * Survey of prototyping deploy methods (Git push, FTP)
1. Architecture of a DevOps/Development Environment & toolchain
    * VSTS setup for small teams (<5 devs)
    * Proper git repo structure
    * Process step in a devops environment (vcs, private build, CI, package mgmt, release to automated dev env, deploy to staging, prod, monitoring)
    * Implementing the basic workflow (Make a change to the app, commit it, view updates in dev, staging, then promote staging to production)
    * Configuring VSTS for branching workflow 
1. Baking in quality to the devops pipeline with Azure
    * Static code analysis (NDepend, VS Code Analysis, ReSharper CLI, Sonarqube, etc)
    * Inspections via pair programming & pull requests
    * Integrating 3 levels of automated testing
    * Integrating specialized test suites (security penetration, ADA Section 508 scanning)
    * Integrating VSTS Load testing
1. Monitoring, Logging, Debugging, & Incident mgmt
    * Monitoring in the Azure portal
    * Logging & Log centralization w/ OMS
    * Debugging
    * Application Insights
    * Designing a DevOps dashboard w/ OMS & PowerBI
    * Integrating an incident mgmt workflow (pick a partner, perhaps PagerDuty, who has VSTS integration)
1. Large system devops environment configurations
    * Large system scenarios (Multi-product, single-product microservices)
    * VCS structure for multiple deployed applications (microservice or otherwise)
    * Designing package management for inter-application dependencies
    * Release management configuration for multi-application/microservice systems
1. Environment management
    * Infrastructure as Code & Immutable infrastructure 
    * Azure ARM
    * Terraform basics
    * Controlling environment configuration mgmt & environment changes into your VCS & Release definitions
1. Next Steps – Survey of devops pipelines for varying architectures
    * Azure Storage (scalable storage)
    * Databases configurations, relational & otherwise
    * Azure Functions/Web job, etc.
    * Containers
    * Azure Service Fabrac
    * Queues
    
