.. _security-authorization-limiting-by-scheme:

Limiting identity by scheme
===========================

In some scenarios, such as Single Page Applications it is possible to end up with multiple authentication methods, cookie authentication to log in and bearer authentication for javascript request. In some cases you may have multiple instances of an authentication middleware, for example, two cookie middlewares where one contains a basic identity and one is created when a multi-factor authentication has triggered because the user requested an operation that requires extra security.

Authentication schemes are named when authentication middleware is configured during authentication, for example 

.. code-block:: c#

 app.UseCookieAuthentication(options =>
 {
     options.AuthenticationScheme = "Cookie";
     options.LoginPath = new PathString("/Account/Unauthorized/");
     options.AccessDeniedPath = new PathString("/Account/Forbidden/");
     options.AutomaticAuthenticate = false;
 });

 app.UseBearerAuthentication(options =>
 {
     options.AuthenticationScheme = "Bearer";
     options.AutomaticAuthenticate = false;
 });

In this configuration two authentication middlewares have been added, one for cookies and one for bearer.

 .. NOTE::
  When adding multiple authentication middleware you should ensure that no middleware is configured to run automatically. You do this by setting the ``AutomaticAuthentication`` options property to false. If you fail to do this filtering by scheme will not work.

Selecting the scheme with the Authorize attribute
-------------------------------------------------

As no authentication middleware is configured to automatically run and create an identity you must, at the point of authorization choose which middleware will be used. The simplest way to select the middleware you wish to authorize wish is to use the ``AuthenticationSchemes`` parameter. This parameter accepts a comma delimited list of Authentication Schemes to use. For example;

.. code-block:: c#

 [Authorize(AuthenticationSchemes = "Cookie,Bearer")]
 public class MixedController : Controller

In the example above both the cookie and bearer middlewares will run and have a chance to create and append an identity for the current user. By specifying a single scheme only the specified middleware will run;

.. code-block:: c#

    [Authorize(AuthenticationSchemes = "Bearer")]

In this case only the middleware with the Bearer scheme would run, and any cookie based identities would be ignored.

Selecting the scheme with policies
----------------------------------

If you prefer to specify the desired schemes in :ref:`policy <security-authorization-policies-based>` you can set the ``AuthenticationSchemes`` collection when adding your policy. 


.. code-block:: c#

 options.AddPolicy("Over18", policy =>
 {
     policy.AuthenticationSchemes.Add("Bearer");
     policy.RequireAuthenticatedUser();
     policy => policy.Requirements.Add(new Over18Requirement());
 });

In this example the Over18 policy will only run against the identity created by the Bearer middleware.
