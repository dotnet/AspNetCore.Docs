---
author: tdykstra
ms.author: tdykstra
$110/18/2024
ms.topic: include
---
Visual Studio provides project templates for creating single-page apps (SPAs) based on JavaScript frameworks such as [Angular](https://angular.dev/), [React](https://react.dev/), and [Vue](https://vuejs.org/) that have an ASP.NET Core backend. These templates:

* Create a Visual Studio solution with a frontend project and a backend project.
* Use the Visual Studio project type for JavaScript and TypeScript (*.esproj*) for the frontend.
* Use an ASP.NET Core project for the backend.

Projects created by using the Visual Studio templates can be run from the command line on Windows, Linux, and macOS. To run the app, use `dotnet run --launch-profile https` to run the server project. Running the server project automatically starts the frontend JavaScript development server. The `https` launch profile is currently required.
