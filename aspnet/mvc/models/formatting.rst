Formatting Response Data
========================

By `Steve Smith`_

ASP.NET MVC has built-in support for formatting response data, using fixed formats or in response to client specifications.

.. contents:: Sections
    :local:
    :depth: 1

`View or download sample from GitHub <https://github.com/aspnet/Docs/tree/master/mvc/models/formatting/sample>`_.

Format-Specific Action Results
------------------------------

Some ActionResult options are specific to a particular format, such as JsonResult and ContentResult (note strings are simply returned as text).

Content Negotiation
-------------------

Content negotiation (conneg for short) occurs when client specifies an Accept header. The default format used by ASP.NET Core MVC is JSON. Negotiation occurs automatically for IActionResult types, including Ok, BadRequest, Created, etc. You can also return a model type and the framework will automatically wrap it in an ObjectResult for you.

Configuring Formatters
----------------------

You can add the XmlFormatters package to add XML support. Configure formatters using config.OutputFormatters (InputFormatters also exist, for Model Binding).

Response Format URL Mappings
----------------------------

You can specify format details within the URL itself, such as via a querystring or part of the path.

Recommendations
---------------

Prefer IActionResult as your return type for data since it allows you to handle error states and different HTTP status codes.
