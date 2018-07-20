# Azure Developer Lifecycle for .NET Developers

The purpose of this book is to set the minimum bar to create a complete .NET development and devops environment on Azure. We assume that developers are experienced .NET developers with working knowledge of ASP.NET, SQL Server, and running these technologies on Windows Server. We don't assume that the reader has cloud/Azure experience. The emphasis is on onboarding developers to Azure using the most productive and high-velocity devops infrastructure available. This book only covers the most common subset of Azure functionality required for implementing popular .NET architectures.  

## Working Outline

1. Introduction/Overview
    * Purpose
    * Cloud computing/Azure - High level overview
    * DevOps - High level overview
1. Required Tools and Downloads
    * Azure subscription
    * Visual Studio (and appropriate workload for VS2017)
    * VSTS
1. Deploying an app to Azure
    * Downloading the sample/Architecture overview. (Should include ASP.NET app and simple SQL Database.)
    * Azure web sites and Azure SQL overview (These are used in almost every app, even if deployed to VMs.)
    * Right-click > Publish scenario and DACPAC/alternative manual deployment
    * Survey of prototyping deploy methods
      - Git push
      - FTP
1. Architecture of a DevOps/Development Environment and toolchain
    * VSTS setup for small teams (fewer than 5 developers)
    * Proper Git repo structure
    * Process step in a devops environment
      - VCS
      - Private build
      - CI
      - Package management
      - Release to automated development environment
      - Deployment to staging/production
      - Monitoring
    * Implement the basic workflow
      - Change to the app
      - Commit
      - View updates in development/staging
      - Promote staging to production
    * Configuring VSTS for branching workflow 
1. Baking in quality to the devops pipeline with Azure
    * Static code analysis
      - NDepend
      - VS Code Analysis
      - ReSharper CLI
      - Sonarqube
    * Inspections via pair programming and pull requests
    * Integrating 3 levels of automated testing
    * Integrating specialized test suites
      - Security penetration
      - ADA Section 508 scanning
    * Integrating VSTS Load testing
1. Monitoring, Logging, Debugging, and Incident management
    * Monitoring in the Azure portal
    * Logging and log centralization with OMS
    * Debugging
    * Application Insights
    * Designing a DevOps dashboard with OMS and PowerBI
    * Integrating an incident management workflow (Pick a partner, perhaps PagerDuty, who has VSTS integration.)
1. Large system devops environment configurations
    * Large system scenarios
      - Multi-product
      - Single-product microservices
    * VCS structure for multiple deployed applications
      - Microservice
      - Others
    * Designing package management for inter-application dependencies
    * Release management configuration for multi-application/microservice systems
1. Environment management
    * Infrastructure as Code and immutable infrastructure 
    * Azure ARM
    * Terraform basics
    * Controlling environment configuration management and environment changes into VCS and Release definitions
1. Next Steps – Survey of devops pipelines for varying architectures
    * Azure Storage (scalable storage)
    * Databases configurations, relational, and others
    * Azure Functions/Web job, others
    * Containers
    * Azure Service Fabric
    * Queues
