Migrating from ASP.NET Core RC2 to ASP.NET Core 1.0
===================================================

By `Cesar Blum Silveira`_

.. contents:: Sections:
  :local:
  :depth: 1

Overview
--------

This migration guide covers migrating an ASP.NET Core RC2 application to ASP.NET Core 1.0.

There weren't many significant changes to ASP.NET Core between the RC2 and 1.0 releases. For a complete list of changes, see the `ASP.NET Core 1.0 announcements <https://github.com/aspnet/announcements/issues?q=is%3Aopen+is%3Aissue+milestone%3A1.0.0>`_.

Install the new tools from http://www.dot.net and follow the instructions.

Update the global.json to 

.. code-block:: javascript

  {
    "projects": [ "src", "test" ],
    "sdk": {
	"version": "1.0.0-preview2-003121"
    }
  }

Tools
-----

For the tools we ship, you no longer need to use ``imports`` in *project.json*. For example:

.. code-block:: json

  {
    "tools": {
      "Microsoft.AspNetCore.Server.IISIntegration.Tools": {
        "version": "1.0.0-preview1-final",
        "imports": "portable-net45+win8+dnxcore50"
      }
    }
  }

Becomes:

.. code-block:: json

  {
    "tools": {
      "Microsoft.AspNetCore.Server.IISIntegration.Tools": "1.0.0-preview2-final"
    }
  }

Hosting
-------

The ``UseServer`` is no longer available for :dn:iface:`~Microsoft.AspNetCore.Hosting.IWebHostBuilder`. You must now use :dn:method:`~Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel` or :dn:method:`~Microsoft.AspNetCore.Hosting.WebHostBuilderWebListenerExtensions.UseWebListener`.

ASP.NET MVC Core
----------------

The ``HtmlEncodedString`` class has been replaced by :dn:class:`~Microsoft.AspNetCore.Html.HtmlString` (contained in the  ``Microsoft.AspNetCore.Html.Abstractions`` package).

Security
--------

The :dn:class:`~Microsoft.AspNetCore.Authorization.AuthorizationHandler\<TRequirement>` class now only contains an asynchronous interface.
