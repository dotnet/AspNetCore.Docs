.. _security-app-secrets:

Safe storage of app secrets with the Secret Manager tool
=========================================================

By `Rick Anderson`_, `Daniel Roth`_

This document shows how you can use the Secret Manager tool to keep secrets out of your code. The most important point is you should never store passwords or other sensitive data in source code, and you shouldn't use production secrets in development and test mode. You can instead use the :doc:`configuration </fundamentals/configuration>` system to read these values from environment variables or from values stored using the Secret Manager tool. The Secret Manager tool helps prevent sensitive data from being checked into source control. The :doc:`configuration </fundamentals/configuration>` system can read secrets stored with the Secret Manager tool described in this article.

.. contents:: Sections:
  :local:
  :depth: 1

Environment variables
^^^^^^^^^^^^^^^^^^^^^

To avoid storing app secrets in code or in local configuration files you store secrets in environment variables. You can setup the :doc:`configuration </fundamentals/configuration>` framework to read values from environment variables by calling ``AddEnvironmentVariables``. You can then use environment variables to override configuration values for all previously specified configuration sources.

For example, if you create a new ASP.NET Core web app with individual user accounts, it will add a default connection string to the *appsettings.json* file in the project with the key ``DefaultConnection``. The default connection string is setup to use LocalDB, which runs in user mode and doesn't require a password. When you deploy your application to a test or production server you can override the ``DefaultConnection`` key value with an environment variable setting that contains the connection string (potentially with sensitive credentials) for a test or production database server.

.. warning:: Environment variables are generally stored in plain text and are not encrypted. If the machine or process is compromised then environment variables can be accessed by untrusted parties. Additional measures to prevent disclosure of user secrets may still be required.

Secret Manager
^^^^^^^^^^^^^^

The Secret Manager tool provides a more general mechanism to store sensitive data for development work outside of your project tree. The Secret Manager tool is a project tool that can be used to store secrets for a `.NET Core`_ project during development. With the Secret Manager tool you can associate app secrets with a specific project and share them across multiple projects.

.. warning:: The Secret Manager tool does not encrypt the stored secrets and should not be treated as a trusted store. It is for development purposes only. The keys and values are stored in a JSON configuration file in the user profile directory.

Installing the Secret Manager tool
-----------------------------------

- Add ``SecretManager.Tools`` to the ``tools`` section of the *project.json* file and run ``dotnet restore``.

.. code-block:: JSON
  :emphasize-lines: 6-9

  "tools": {
    "Microsoft.AspNetCore.Razor.Tools": {
      "version": "1.0.0-preview1-final",
      "imports": "portable-net45+win8+dnxcore50"
    },
    "Microsoft.Extensions.SecretManager.Tools": {
      "version": "1.0.0-preview1-final",
      "imports": "portable-net45+win8+dnxcore50"
    }
  },

- Test the Secret Manager tool by running the following command::

    dotnet user-secrets -h

The Secret Manager tool will display usage, options and command help.

The Secret Manager tool operates on project specific configuration settings that are stored in your user profile. To use user secrets the project must specify a ``userSecretsId`` value in its *project.json* file. The value of ``userSecretsId`` is arbitrary, but is generally unique to the project.

- Add a ``userSecretsId`` for your project in its *project.json* file:

.. code-block:: json
  :emphasize-lines: 2

  {
  "userSecretsId": "aspnet-WebApp1-c23d27a4-eb88-4b18-9b77-2a93f3b15119",

  "dependencies": {

- Use the Secret Manager tool to set a secret. For example, in a command window from the project directory enter the following::

    dotnet user-secrets set MySecret ValueOfMySecret

You can run the secret manager tool from other directories, but you must use the ``--project`` option to pass in the path to the *project.json* file::

    dotnet user-secrets set MySecret ValueOfMySecret --project c:\work\WebApp1

You can also use the Secret Manager tool to list, remove and clear app secrets.

Accessing user secrets via configuration
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

You access Secret Manager secrets through the configuration system. Add the ``Microsoft.Extensions.Configuration.UserSecrets`` as a dependency in your *project.json* file and run ``dotnet restore``.

.. code-block:: json
  :emphasize-lines: 2

    "Microsoft.Extensions.Configuration.UserSecrets": "1.0.0-rc2-final",

Add the user secrets configuration source to the ``Startup`` method:

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
  :language: c#
  :lines: 20-35
  :emphasize-lines: 11
  :dedent: 8

You can now access user secrets via the configuration API:

.. code-block:: c#

  string testConfig = Configuration["MySecret"];

How the Secret Manager tool works
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The secret manager tool abstracts away the implementation details, such as where and how the values are stored. You can use the tool without knowing these implementation details. In the current version, the values are stored in a `JSON <http://json.org/>`_ configuration file in the user profile directory:

- Windows: ``%APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json``
- Linux: ``~/.microsoft/usersecrets/<userSecretsId>/secrets.json``
- Mac: ``~/.microsoft/usersecrets/<userSecretsId>/secrets.json``

The value of ``userSecretsId`` comes from the value specified in *project.json*.

You should not write code that depends on the location or format of the data saved with the secret manager tool, as these implementation details might change. For example, the secret values are currently *not* encrypted today, but could be someday.

Additional Resources
^^^^^^^^^^^^^^^^^^^^^^^^^

- :doc:`/fundamentals/configuration`.
