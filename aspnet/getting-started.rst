Getting Started
===============

1. Install `.NET Core`_

2. Create a new .NET Core project:

  .. code-block:: console
    
    mkdir aspnetcoreapp
    cd aspnetcoreapp
    dotnet new

3. Update the *project.json* file to add the Kestrel HTTP server package as a dependency:

  .. literalinclude:: getting-started/sample/aspnetcoreapp/project.json
    :language: c#
    :emphasize-lines: 15

4. Restore the packages:

  .. code-block:: console
    
    dotnet restore

5. Add a *Startup.cs* file that defines the request handling logic:

  .. literalinclude:: getting-started/sample/aspnetcoreapp/Startup.cs
    :language: c#

6. Update the code in *Program.cs* to setup and start the Web host:

  .. literalinclude:: getting-started/sample/aspnetcoreapp/Program.cs
    :language: c#
    :emphasize-lines: 2,4,10-15

7. Run the app  (the ``dotnet run`` command will build the app when it's out of date):

  .. code-block:: console
  
    dotnet run

8. Browse to \http://localhost:5000:

  .. image:: getting-started/_static/running-output.png

Next steps
----------

- :doc:`/tutorials/first-mvc-app/index`
- :doc:`/tutorials/your-first-mac-aspnet`
- :doc:`/tutorials/first-web-api`
- :doc:`/fundamentals/index`
