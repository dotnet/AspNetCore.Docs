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

Hosting
-------

The ``UseServer`` is not longer available for :dn:iface:`~Microsoft.AspNetCore.Hosting.IWebHostBuilder`. You must now use :dn:method:`~Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel` or :dn:method:`~Microsoft.AspNetCore.Hosting.WebHostBuilderWebListenerExtensions.UseWebListener`.

MVC
---

The :dn:class:`~Microsoft.AspNetCore.Html.HtmlString` class has been removed from MVC. You should now use the :dn:class:`~Microsoft.AspNetCore.Html.HtmlString` class provided in the ``Microsoft.AspNetCore.Html.Abstractions`` package, which was formerly named ``HtmlEncodedString``. If you were using :dn:class:`~Microsoft.AspNetCore.Html.HtmlString` directly in your Razor views, you must add a ``@using`` statement for :dn:namespace:`Microsoft.AspNetCore.Html`.

Security
--------

The :dn:class:`~Microsoft.AspNetCore.Authorization.AuthorizationHandler` class now only offers an asynchronous interface. You must now use the ``Async`` versions of its methods.