Create an app with secure user data
======================================

By `Rick Anderson`_ and `Barry Dorrans`_

.. contents:: Sections:
  :local:
  :depth: 1
  
This tutorial shows how to create a web app with secure user data. Authenticated users can read all the contacts but can only edit their contacts.  A user in the administrator role can can delete any contact. 

In the image below, user *rick@example.com* can edit and delete his contacts, and read other contacts.

.. image:: secure-data/_static/conRick.png

In the image below, *test@example.com* is in the ``canDelete`` role, so she can edit her contacts and delete any contact.

.. image:: secure-data/_static/conTest.png

The app was created by scaffolding the following ``Contact`` model:

.. literalinclude::  secure-data/samples/starter/Models/Contact.cs
  :language: c#
  :lines: 5-16
  :dedent: 4
  :emphasize-lines: 3
  
The contact information properties (Address, name, etc) are displayed in the images above. ``ContactId`` is the primary key for the table. 

A user authorization filter ensures only the logged in user can edit their data. A ``canDelete`` authorization filter allows users in the "canDelete" role to delete any data. 

The starter app
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

`Download <https://github.com/aspnet/Docs/tree/master/aspnet/security/authorization/secure-data/samples/starter>`__ and test the starter app. See :ref:`Create-Secure_data-starter-app-label` if you'd like to create the starter app.

Update the database:

.. code-block:: none
 
  dotnet ef database update
  
Run the app, tap the **ContactManager** link and verify you can create, edit and delete a contact.

Tie the contact data to the user
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

We'll use the ASP.NET :doc:`Identity </security/authentication/identity>` user ID to ensure users can edit their data, but not other users data. Update the ``Contact`` model:

.. literalinclude::  secure-data/samples/final/Models/Contact.cs
  :language: c#
  :lines: 5-19
  :dedent: 4
  :emphasize-lines: 5-6

``OwnerID`` is the user's ID from the ``AspNetUser`` table in the :doc:`Identity </security/authentication/identity>` database.

Scaffold a new migration and update the database:

.. code-block:: none
 
  dotnet ef migrations add userID
  dotnet ef database update

.. _create-secure_data-require-ssl-label:

Require SSL and authenticated users
------------------------------------

In the ``ConfigureServices`` method of the *Startup.cs* file, add the :dn:cls:`~Microsoft.AspNetCore.Mvc.RequireHttpsAttribute` authorization filter that confirms requests are received over HTTPS:

.. literalinclude::  secure-data/samples/final/Startup.cs
  :language: c#
  :start-after:  // Require SSL.
  :end-before:  // Default authentication policy 
  :dedent: 12

If you are using Visual Studio, see :ref:`Enable-ssl-visual-studio-label`.

Set the default authentication policy to require users to be authenticated. You can opt out of authentication at the controller or action method with the ``[AllowAnonymous]`` attribute. With this approach, any new controllers added will automatically require authentication, which is more fail safe than relying on new controllers to include the ``[Authorize]`` attribute. Add the following to  the ``ConfigureServices`` method of the *Startup.cs* file:

.. literalinclude::  secure-data/samples/final/Startup.cs
  :language: c#
  :start-after: // Default authentication policy will require authenticated user.
  :end-before:  // Authorization handlers.
  :dedent: 12
  
Add ``[AllowAnonymous]`` to the home controller so anonymous users can get information about the site before they register.

Configure the test account 
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The ``SeedData`` class creates a test user account. Use the  :doc:`Secret Manager tool </security/app-secrets>` to set a password for the account. Do this from the project directory (the directory containing *Program.cs*).

.. code-block:: none

  dotnet user-secrets set SeedUserPW <PW>
  
Update ``Configure`` to use the test password:

.. literalinclude::  secure-data/samples/final/Startup.cs
  :language: c#
  :start-after: // Set password with  the Secret Manager tool.
  :end-before: // End
  :dedent: 12
 
Add the test accounts user ID to the seed data:

.. literalinclude::  secure-data/samples/final/Data/SeedData.cs
  :language: c#
  :start-after: context.Contact.AddRange(
  :end-before: // End
  :dedent: 12
  :emphasize-lines: 9

Delete all the records in the ``Contact`` table and seed the database. If you're using Visual Studio you might need to stop IIS Express to force the seed initializer to run.

Resource based authorization
-----------------------------

- Create an *Authorization* folder for the filters and classes we will create to implement authorization.
- Create a *ContactIsOwnerAuthorizationHandler* class we can invoke to verify the user acting on the resource owns the resource. Create this in the *Authorization* folder.

.. literalinclude:: secure-data/samples/final/Authorization/ContactIsOwnerAuthorizationHandler.cs
  :language: c#

The ``ContactIsOwner`` authorization handler uses ASP.NET Core Identity, which is built on Entity Framework Core, which requires we add this handler as scoped. Register the ``ContactIsOwner`` handler with the service collection so it will be available to the ``ContactsController`` through :ref:`dependency injection <fundamentals-dependency-injection>`. Add the following code to ``ConfigureServices``: 

.. literalinclude::  secure-data/samples/final/Startup.cs
  :language: c#
  :start-after: // Authorization handlers.
  :end-before: // Add
  :dedent: 12

Update the ``ContactsController`` constructor to resolve the *ContactIsOwnerAuthorizationHandler* service. While we're at it we'll also get the ``Identity`` ``UserManager`` service:

.. literalinclude:: secure-data/samples/final/Controllers/ContactsController.cs                    
  :language: c#
  :start-after: //
  :end-before: // GET:
  :dedent: 4
  :emphasize-lines: 4,5,9,10,13,14

Add a ``ContactOperationsRequirements`` class to the *Authorization* folder to contain the requirements our app supports:

.. literalinclude:: secure-data/samples/final/Authorization/ContactOperationsRequirements.cs
  :language: c#
  
Update the ``HTTP POST Create`` method to add the user ID to the ``Contact`` model:

.. literalinclude:: secure-data/samples/final/Controllers/ContactsController.cs
  :language: c#
  :start-after: // POST: Contacts/Create
  :end-before: // GET:
  :dedent: 8
  :emphasize-lines: 7

Update both ``Edit`` methods to use the authorization filter to verify the user owns the contact. Add ``OwnerID`` to the ``Bind`` list:

.. literalinclude:: secure-data/samples/final/Controllers/ContactsController.cs
  :language: c#
  :start-after: // GET: Contacts/Edit/5
  :end-before: // GET: Contacts/Delete/5
  :dedent: 8
  :emphasize-lines: 14-19,35-40,28

Add the ``OwnerID`` as a hidden field so it will be available to the ``HTTP POST Edit`` method:

.. literalinclude:: secure-data/samples/final/Views/Contacts/Edit.cshtml
  :language: none
  :start-after: <h2>Edit</h2>
  :end-before: <label asp-for="Address" 
  :emphasize-lines: 8

Update both ``Delete`` methods to use the authorization filter to verify the user owns the contact. Add ``OwnerID`` to the ``Bind`` list:

.. literalinclude:: secure-data/samples/final/Controllers/ContactsController.cs
  :language: c#
  :start-after: // GET: Contacts/Edit/5
  :end-before: // GET: Contacts/Delete/5
  :dedent: 8
  :emphasize-lines: 14-19,35-40,28
 
 .. _update-access-denied--label:

Update the ``AccountController`` to display friendly access denied errors
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Add the ``AccessDenied`` method to the ``AccountController``. This method will be invoked when we call ``ChallengeResult``.

.. literalinclude:: secure-data/samples/final/Controllers/AccountController.cs
  :language: c#
  :start-after: // GET /Account/AccessDenied
  :end-before: // 
  :dedent: 8

Add the *Views/Account/AccessDenied.cshtml* Razor view:

.. literalinclude:: secure-data/samples/final/Views/Account/AccessDenied.cshtml
  :language: html

Test the ``Edit``, ``Delete``, and ``Create`` methods
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

An easy way to test the changes we made is to launch two different browsers (for example Edge and Internet Explorer). Log into one browser as user ``test@example.com``. In the other browser register a new user (for example ``rick@example.com``) and create a new contact.

Verify ``test@example.com`` can edit and delete the seed data and any contacts created with that account. Verify ``test@example.com`` cannot edit or delete a contact created by the second account.

Currently the UI shows 

Inject the authorization service into the views:















.. _create-secure_data-starter-app-label:

Create the starter app
^^^^^^^^^^^^^^^^^^^^^^^