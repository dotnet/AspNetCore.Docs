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

A user authorization filter ensures only users can edit their data. A ``canDelete`` authorization filter ensures only users in the "canDelete" role are permitted to delete any data.

The starter app
^^^^^^^^^^^^^^^^^

If you're not using Visual Studio or you don't want to create your own starter app, download the starter application and skip to the next section.

- Create a new **ASP.NET Core Web Application** using `Visual Studio 2015 <https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx>`__ named "ContactManager"  

  - Create the app with **Individual User Accounts**
  - Name it "ContactManager" so your namespace will match the namespace use in the sample
  
- Add the following ``Contact`` model:

.. literalinclude::  secure-data/samples/starter/Models/Contact.cs
  :language: c#
  :lines: 5-16
  :dedent: 4

- Scaffold the ``Contact`` model using Entity Framework Core and the ``ApplicationDbContext`` data context. Accept all the scaffolding defaults. Using ``ApplicationDbContext``  puts the contact table in the :doc:`Identity </security/authentication/identity>` database.
- Update the **ContactManager** anchor in the *Views/Shared/_Layout.cshtml* file from ``Home`` to ``Contacts`` so tapping the **ContactManager** link will invoke the ``ContactsController``. The original markup:

   ``<a asp-controller="Home" asp-action="Index" class="navbar-brand">ContactManager</a>``
   
   The new markup:
   
   ``<a asp-controller="Contacts" asp-action="Index" class="navbar-brand">ContactManager</a>``
- Test the app by creating, editing and deleting a contact
- Scaffold the initial migration and update the database

.. code-block:: none
 
  dotnet ef migrations add initial
  dotnet ef database update

Require SSL and authenticated users
------------------------------------

In the ``ConfigureServices`` method of the *Startup.cs* file, add the following code which will require SSL:

.. literalinclude::  secure-data/samples/final/Startup.cs
  :language: c#
  :lines: 63-66
  :dedent: 12

If you are using Visual Studio, see `Enable SSL <https://docs.asp.net/en/latest/security/authentication/accconfirm.html#require-ssl>`__.

Set the default authentication policy to require users to be authenticated. You can opt out of authentication at the controller or action method with the ``[AllowAnonymous]`` attribute. With this approach, any new controllers added will automatically require authentication, which is more fail safe than relying on new controllers to include the ``[Authorize]`` attribute. Add the following to  the ``ConfigureServices`` method of the *Startup.cs* file:

.. literalinclude::  secure-data/samples/final/Startup.cs
  :language: c#
  :lines: 68-75
  :dedent: 12
  
Add ``[AllowAnonymous]`` to the home controller so anonymous users can get information about the site before they register.
  
Tie the contact data to the user
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

We'll use the ASP.NET :doc:`Identity </security/authentication/identity>` user ID to ensure users can edit their data, but not other users data. Update the ``Contact`` model:

.. literalinclude::  secure-data/samples/final/Models/Contact.cs
  :language: c#
  :lines: 5-19
  :dedent: 4

``OwnerID`` is the user's ID from the ``AspNetUser`` table in the :doc:`Identity </security/authentication/identity>` database.

Scaffold a new migration and update the database:

.. code-block:: none
 
  dotnet ef migrations add userID
  dotnet ef database update

Seed the database
^^^^^^^^^^^^^^^^^^

Add the ``SeedData`` class to the *Data* folder. If you've downloaded the completed application, you can copy the *SeedData.cs* file to the *Data* folder.

.. literalinclude::  secure-data/samples/final/Data/SeedData.cs
  :language: c#

Add the highlighted code to the end of the ``Configure`` method in the *Startup.cs* file:

.. literalinclude::  secure-data/samples/final/Startup.cs
  :language: c#
  :start-after: // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715
  :dedent: 12
  :emphasize-lines: 8-
  
Test that the app seeded the database.



