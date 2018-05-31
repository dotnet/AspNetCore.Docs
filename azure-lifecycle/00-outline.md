# Azure Developer Lifecycle for .NET Developers

The purpose of this book (or set of docs, or whatever else this project becomes) is to set the minimum bar for a complete .NET development lifecycle on Azure. We shall assume that developers are experienced ASP.NET developers (200-300 level understanding) with no cloud/Azure experience. The emphasis will be on onboarding developers to Azure, not a survey of everything available.  

## Working Outline

1. Introduction/Overview
    * Purpose of book
    * Cloud computing/Azure - High level overview
     
2. Required Tools and Downloads
    * Azure subscription 
    * Visual Studio (and appropriate workload for VS2017)

3. Deploying an app to App Service
    * Downloading the sample
    * Right-click > publish scenario.
    * Git Push method
    * FTP method
    * Deployment slots

4. DevOps and CI/CD toolchain 
    * Putting the app in a local Git or GitHub repo and tying it to Azure for CI
    * Use of staging environments in Web Apps 
    * Make a change to the app, commit it, watch it show up magically in staging, then promote staging to prod
    * VSTS build server

5. Monitoring, Logging, and Debugging
    * Monitoring in the Portal 
    * Logging
    * Debugging
    * Application Insights

6.	Next Steps – Learning paths for additional topics
    * Azure storage
    * Databases
    * Azure functions
    * Containers
    * Cognitive services
