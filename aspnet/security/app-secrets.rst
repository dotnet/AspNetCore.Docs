Safe Storage of Application Secrets
===================================

By `Rick Anderson`_

This tutorial shows how your application can securely store and access secrets in the local development environment. The most important point is you should never store passwords or other sensitive data in source code, and you shouldn't use production secrets in development and test mode. The secret manager tool was written to help prevent sensitive data from being checked into source control. The :doc:`/fundamentals/configuration` system that is used by default in DNX based apps can read secrets stored with the secret manager tool described in this article.

In this article:
  - `Environment variables`_
  - `Installing the secret manager tool`_
  - `How the secret manager tool works`_
  - `Additional Resources`_

Environment variables
^^^^^^^^^^^^^^^^^^^^^

Your ``Startup`` class should call `AddEnvironmentVariables` as the last configuration method so when 
:doc:`DNX </dnx/overview>` reads environment variables, and a key is found in a configuration file and the environment, the environment value takes precedence over the configuration file. (See :doc:`/fundamentals/configuration`.) For example, if you create a new ASP.NET web site app with individual user accounts, it will add a default connection string to the *config.json* file. The ``Data:DefaultConnection:ConnectionString`` key value in the *config.json* file uses LocalDB, which runs in user mode and doesn't require a password. When you deploy your application to a test or production server, you can override the ``Data:DefaultConnection:ConnectionString`` key value with an environment variable setting that connects to a test or production SQL Server. That key value would also contain a password to connect to the SQL Server.

Apps frequently require secrets, such as a client ID for OAuth. These passwords and other sensitive data should never be added to *config* files inside your project's source tree, as configuration files can be accidentally checked into source control. The secret manager tool provides a mechanism to store sensitive data for development work outside your project tree. The secret manager tool is a DNX console application that is used to store secrets used by DNX and ASP.NET applications in the development environment.

Installing the secret manager tool
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

- Create a new ASP.NET web app. We will use this to test secrets stored with the secret manager tool.
- Open a command prompt and navigate to the project folder (the folder with *config.json*).
- Set the runtime version using the .Net Version Manager (DNVM). DNVM is a tool that lets you list, install and switch :doc:`DNX </dnx/overview>` versions on your machine. Run the following command:

.. code-block:: none

  dnvm use 1.0.0-beta5

The **dnvm** tool is the .NET Version Manager used to update and configure the .NET Execution Environment (DNX). The command ``dnvm use 1.0.0-beta5`` instructs the .NET Version Manager to add the DNX to the ``PATH`` environment variable for the current shell. After running this command the following is displayed::

  Adding C:\Users\<user>\.dnx\runtimes\dnx-clr-win-x86.1.0.0-beta5\bin to process PATH

- Install the secret manager tool using DNU (Microsoft .NET Development Utility). DNU is used to build, package and publish DNX projects.
 
.. code-block:: none
 
  dnu commands install SecretManager

- Test the secret manager tool by running the following command::

    user-secret -h

The secret manager tool will display usage, options and command help.

- Use the secret manager tool to set a secret. For example, in the command window enter the following::

    user-secret set MySecret ValueOfMySecret

- Add the following code to the end of the ``Startup`` method:

  .. code-block:: c#

    string testConfig = configuration.Get("MySecret");
    Trace.WriteLine(testConfig);

The output window of Visual Studio will display "ValueOfMySecret".

How the secret manager tool works
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The tool operates on project specific configuration settings that are stored in your user account. In the example above, the command window was opened in the project folder (containing the file *project.json*). You can run the secret manager tool from other directories, but you must use the ``-project`` switch and pass in the path to the *project.json* file.

The secret manager tool abstracts away the implementation details, such as where and how the values are stored. You can use the tool without knowing these implementation details. In the current version, the values are stored in a `JSON <http://json.org/>`_ configuration file in the user profile directory:

- Windows: ``%APPDATA%\microsoft\UserSecrets\<applicationId>\secrets.json``
- Linux: ``~/.microsoft/usersecrets/<applicationId>/secrets.json``
- Mac: ``~/.microsoft/usersecrets/<applicationId>/secrets.json``

The ``applicationId`` comes from the the *project.json* file and is arbitrary, but should be unique unless you have a reason for it not to be. The following markup shows a portion of the *project.json* file with the ``applicationId`` highlighted:

.. code-block:: json
  :emphasize-lines: 3

  {
    "webroot": "wwwroot",
    "userSecretsId": "aspnet5-WebApplication1-f7fd3f56-2899-4eea-a88e-673d24bd7090",
    "version": "1.0.0-*"
  }

The ``userSecretsId`` key for the ``applicationId`` highlighted above was generated by Visual Studio.

You should not write code that depends on the location or format of the data saved with the secret manager tool, as these implementation details might change. For example, the secret values are currently not encrypted today, but could be someday.

Additional Resources
^^^^^^^^^^^^^^^^^^^^^^^^^

- :doc:`/fundamentals/configuration`.
- :doc:`/dnx/overview`.
