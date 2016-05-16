.. _security-app-secrets:

Safe Storage of Application Secrets
===================================

By `Rick Anderson`_, `Daniel Roth`_

This tutorial shows how your application can securely store and access secrets in the local development environment. The most important point is you should never store passwords or other sensitive data in source code, and you shouldn't use production secrets in development and test mode. You can instead use the :doc:`configuration </fundamentals/configuration>` system to read these values from environment variables or from values stored using the Secret Manager tool. The Secret Manager tool helps prevent sensitive data from being checked into source control. The :doc:`configuration </fundamentals/configuration>` system can read secrets stored with the Secret Manager tool described in this article. 

.. contents:: Sections:
  :local:
  :depth: 1

Environment variables
^^^^^^^^^^^^^^^^^^^^^

To avoid storing app secrets in code or in local configuration files you can instead store secrets in environment variables. You can setup the :doc:`configuration </fundamentals/configuration>` framework to read values from environment variables by calling ``AddEnvironmentVariables`` when you setup your configuration sources. You can then use environment variables to override configuration values for all previously specified configuration sources. 

For example, if you create a new ASP.NET web site app with individual user accounts, it will add a default connection string to the *config.json* file in the project with the key ``Data:DefaultConnection:ConnectionString``. The default connection string is setup to use LocalDB, which runs in user mode and doesn't require a password. When you deploy your application to a test or production server you can override the ``Data:DefaultConnection:ConnectionString`` key value with an environment variable setting that contains the connection string (potentially with sensitive credentials) for a test or production SQL Server. 

.. note:: Environment variables are generally stored in plain text and are not encrypted. If the machine or process is compromised then environment variables can be accessed by untrusted parties. Additional measures to prevent disclosure of user secrets may still be required.

Secret Manager
^^^^^^^^^^^^^^

The Secret Manager tool provides a more general mechanism to store sensitive data for development work outside of your project tree. The Secret Manager tool is a project tool that can be used to store secrets for a `.NET Core`_ project during development. With the Secret Manager tool you can associate app secrets with a specific project and share them across multiple projects.

.. note:: The Secret Manager tool does not encrypt the stored secrets and should not be treated as a trusted store. It is for development purposes only.

Installing the Secret Manager tool
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

- Add ``dotnet-user-secrets`` to the tools section in your *project.json* file and run ``dotnet restore``.

- Test the Secret Manager tool by running the following command::

    user-secret -h

The Secret Manager tool will display usage, options and command help.

The Secret Manager tool operates on project specific configuration settings that are stored in your user profile. To use user secrets the project must specify a ``userSecretsId`` value in its *project.json* file. The value of ``userSecretsId`` is arbitrary, but is generally unique to the project.

- Add a ``userSecretsId`` for your project in its *project.json* file, like this:

.. code-block:: json
  :emphasize-lines: 3

  {
    "webroot": "wwwroot",
    "userSecretsId": "aspnet5-WebApplication1-f7fd3f56-2899-4eea-a88e-673d24bd7090",
    "version": "1.0.0-*"
  }

- Use the Secret Manager tool to set a secret. For example, in a command window from the project directory enter the following::

    user-secret set MySecret ValueOfMySecret

You can run the secret manager tool from other directories, but you must use the ``--project`` option to pass in the path to the *project.json* file, like this::

    user-secret set MySecret ValueOfMySecret --project \users\danroth27\documents\WebApplication1

You can also use the Secret Mananger tool to list, remove and clear app secrets.

Accessing user secrets via configuration
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

You can access user secrets stored using the Secret Manager tool via the configuration system. To do so you first need to add the configuration source for the user secrets.

Add the ``Microsoft.Extensions.Configuration.UserSecrets`` as a dependency in your *project.json* file and run ``dotnet restore``.

Add the user secrets configuration source:

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
  :linenos:
  :language: c#
  :lines: 22-34
  :emphasize-lines: 9
  :dedent: 12

You can now access user secrets via the configuration API:

.. code-block:: c#

  string testConfig = configuration["MySecret"];

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
