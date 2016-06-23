.. _security-authorization-views:

View Based Authorization
========================

Often a developer will want to show, hide or otherwise modify a UI based on the current user identity. You can access the authorization service within MVC views by injecting it. To inject the authorization service into a view you use the ``@inject IAuthorizationService AuthorizationService``. If you want the authorization service in every view then place the ``@inject`` keyword into the ``_ViewImports.cshtml`` file in the ``Views`` directory.

Once you have injected the authorization service you use it by calling the ``AuthorizeAsync`` method in exactly the same way as you would check during :ref:`resource based authorization <security-authorization-resource-based-imperative>`. 

.. code-block:: c#

 @if (await AuthorizationService.AuthorizeAsync(User, "PolicyName"))
 {
     <p>This paragraph is displayed because you fulfilled PolicyName.</p>        
 }    

In some cases the resource will be your view model, and you can call ``AuthorizeAsync`` in exactly the same way as you would check during :ref:`resource based authorization <security-authorization-resource-based-imperative>`;

.. code-block:: c#

 @if (await AuthorizationService.AuthorizeAsync(User, Model, Operations.Edit))
 {
     <p><a class="btn btn-default" role="button" 
         href="@Url.Action("Edit", "Document", new {id= Model.Id})">Edit</a></p>        
 }    

Here you can see the model is passed as the resource authorization should take into consideration.

 .. WARNING::
  Do not rely on showing or hiding parts of your UI as your only authorization method. Hiding a UI element does not mean a user cannot access it. You must also authorize the user within your controller code.
