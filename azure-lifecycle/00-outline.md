1. Introduction/Overview
    * Purpose of book
    * Cloud computing/Azure - High level overview
     
2. Required Tools and Downloads
    * Azure subscription 
    * Visual Studio (and appropriate workload for VS2017)
    * SDK tools/emulators (if VS2015 – VS2017 should include everything in a workload)

3. Build a Web App that consumes an Azure service 
    * Walkthrough creation of a canonical example, e.g. "To-Do List" app
        * Relies on an Azure-based service for data.
        * Emphasize a repository pattern to facilitate later changes to data layer
        * Emphasize config transforms for dev/production configs.
        * Emphasize stateless design choices for scaling purposes
        * Authentication
    
4. Deploying the app to App Service and monitoring 
    * Right-click > publish scenario.
    * After publishing and verifying, walk through the monitoring options
        * Azure portal
        * Application Insights - Point out that it's built-in!
    * Make a change to the app, publish updates same way

5. Setting up a CI/CD toolchain 
    * Putting the app in a local Git or GitHub repo and tying it to Azure for CI
    * Use of staging environments in Web Apps 
    * Make a change to the app, commit it, watch it show up magically in staging, then promote staging to prod

6. Best practices we didn’t cover (learning paths, not content)
    * Keeping secrets in Key Vault
    * Using Redis for caching and session state
    * Using Azure CDN for content distribution

7.	Next Steps – Learning paths for additional topics
    * Azure storage
    * Databases
    * Azure functions
    * Containers
    * Cognitive services
