# Scott's knowledge transfer doc for ASP.NET Core docs

## API ref pages

To publish API ref pages for a new ASP.NET Core product version:

1. Submit a request at [aka.ms/publish-on-docs/reference](https://aka.ms/publish-on-docs/reference).
1. Notify [Alma Jenks](mailto:v-alje@microsoft.com) that you've submitted the request.
1. Once Alma has created a pull request with the API changes, review the staging environment. Work with James Newton-King to ensure the staging environment looks correct.

## Moniker / version selector changes

Each time a new ASP.NET Core product version is released, a new moniker is needed to support versioned content for that release. These monikers are managed in the [Docs Portal Monikers page](https://ops.microsoft.com/#/monikers). Filter that page's table using a **Platform** value of *dotnet* and a **Family** value of *ASP.NET*. The resulting monikers are shared by the conceptual docs and the API ref pages.

Speaking of versioning, [this section of *docfx.json*](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/docfx.json#L100-L105) supports the version selector in the ASP.NET Core conceptual docs.

## Automatic labeling of GitHub issues

Andy De George's issue labeling tool is used to automatically label incoming GitHub issues based on their associated metadata. To modify the behavior of this tool in the *dotnet/AspNetCore.Docs* repo, see [*.ghal.rules.json*](https://github.com/dotnet/AspNetCore.Docs/blob/main/.ghal.rules.json).

## Code sample builds on pull requests

The Snippets 5000 tool is used to build modified code samples that are part of pull requests. In the *dotnet/AspNetCore.Docs* repo, the [*build-validation.yaml*](https://github.com/dotnet/AspNetCore.Docs/blob/main/.github/workflows/build-validation.yml) file is used to configure how that build behaves.

**IMPORTANT:** When a .NET SDK version newer than 5.x is needed to build code samples, update [this environment variable](https://github.com/dotnet/AspNetCore.Docs/blob/main/.github/workflows/build-validation.yml#L25) with the appropriate SDK version number. I recommend making this change once you want to have ASP.NET Core 6.0 code samples building in pull requests.

David Pine is a great resource for any questions.

## Microsoft Learn modules

Here are some useful resources for the ASP.NET Core Learn modules work:

- [Azure DevOps .NET content issues query](https://ceapex.visualstudio.com/Microsoft%20Learn/_queries?tempQueryId=a9350c42-2123-4058-9f72-51b064c3a117)
- [MicrosoftDocs/learn-pr](https://github.com/MicrosoftDocs/learn-pr) - The repo in which you’ll open PRs for the actual module content
- Sample code / setup script repos:
    - [MicrosoftDocs/mslearn-aspnet-core](https://github.com/MicrosoftDocs/mslearn-aspnet-core) - Repo containing most starter apps and all setup scripts for modules
    - [MicrosoftDocs/mslearn-microservices-devops-aspnet-core](https://github.com/MicrosoftDocs/mslearn-microservices-devops-aspnet-core) - Repo containing starter app for microservices w/ GitHub Actions module
- [GitHub project for ASP.NET Core microservices learning path](https://github.com/dotnet/AspNetCore.Docs/projects/68) - This is where Cam and I were tracking progress for the microservices learning path
- [Gold standard module checker](http://mslearnmetricportal.azurewebsites.net/) - Use this tool to see how well a module scores against the Instructional Design team’s “gold standards”
- [Contributor guide](https://review.docs.microsoft.com/en-us/help/learn/?branch=master)
- [PowerBI dashboard](https://msit.powerbi.com/groups/me/reports/3ad7a43c-5334-4086-b762-8b4bdb2741ff/ReportSection) - Metrics such as completion rates for modules can be found here

## What's New in Docs

I'll still be involved in the project. If I'm not around, Bill Wagner is a great resource for any questions.

### Overview

The page generation tool is a .NET global tool that's distributed via an internal Azure Artifacts feed. The tool uses settings from the *.whatsnew.json* file in the root of the GitHub repo.

The table below includes some helpful links.

|Resource  |Description  |
|---------|---------|
|[README file](https://aka.ms/whats-new-tool) |A *README* file with installation & onboarding instructions.|
|[Contributors guide](https://dev.azure.com/mseng/TechnicalContent/_git/dotnet-docs-tools?path=%2Fwhatsnew%2Fsrc%2FWhatsNew.Cli%2FCONTRIBUTING.md) |A guide for those who want to contribute to the tool's code. Explains how to get the tool running locally on your development machine.|
|[Source code](https://dev.azure.com/mseng/TechnicalContent/_git/dotnet-docs-tools?path=%2Fwhatsnew)|Source code location for the tool. Open the solution in Visual Studio 2019.|
|[Azure Pipelines CI/CD pipeline](https://dev.azure.com/mseng/TechnicalContent/_build?definitionId=10534)|The build and release pipeline. Builds when PRs are opened against specific branches. Also responsible for publishing the tool's NuGet package to Azure Artifacts.|
|[Azure Artifacts package feed](https://dev.azure.com/mseng/TechnicalContent/_packaging?_a=feed&feed=DotnetDocsTools%40Local)|An internal-only packages feed that's accessible to all of DevRel.|
|[Power BI dashboard](https://aka.ms/whatsnewindocs)|A dashboard showing traffic to/from the what's new pages.|
|[whatsnewindocs@microsoft.com](mailto:whatsnewindocs@microsoft.com)|A distribution list (DL) for the project's V-team. If anyone has questions about the tool, this is the best DL to use.|

### ASP.NET Core "what's new" page generation

Complete the following steps on the first of each month:

1. Run a variation of the following command:

    ```bash
    dotnet whatsnew --owner dotnet --repo AspNetCore.Docs --startdate 3/1/2021 --enddate 3/31/2021
    ```

    In the preceding example, all pull requests merged into *main* between March 1st and March 31st will be processed. The *[.whatsnew.json](https://github.com/dotnet/AspNetCore.Docs/blob/main/.whatsnew.json)* file in the *dotnet/AspNetCore.Docs* repo will be used by the tool to determine which pull requests are considered significant and how the Markdown file is generated.

1. Locate the generated Markdown file in the user profile directory of your machine. On my machine, the preceding command would have created *C:\Users\scaddie\AppData\Roaming\whatsnew\dotnet-AspNetCore.Docs-2021-03-01.md*.
1. Copy the generated Markdown file into the [*whats-new* folder](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/whats-new), and rename the file to match the naming convention that's been established. For example, rename *dotnet-AspNetCore.Docs-2021-03-01.md* to *2021-03.md*.
1. Modify the pull request titles so that they're meaningful to the reader. For example, avoid pull request titles like "Edit pass on index.md". After doing this cleanup exercise a few times, you'll understand the importance of descriptive pull request titles. :-)
1. In that same *whats-new* folder, update both *index.yml* and *toc.yml* with a link to the latest "what's new" page. Also, remove the oldest "what's new" page. We've been maintaining ONLY the last 6 months worth of pages.
