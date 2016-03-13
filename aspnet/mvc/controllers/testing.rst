Testing Controller Logic
========================
By `Steve Smith`_

Controllers in ASP.NET MVC apps should be small and focused on user-interface concerns. Provided this recommendation is followed, testing your app's controller logic should be fairly straightforward.

.. contents:: Sections
	:local:
	:depth: 1
	
`View sample files <https://github.com/aspnet/Docs/tree/1.0.0-rc1/aspnet/mvc/controllers/testing/sample>`_

What is Controller Logic
------------------------
*Controllers* define groups of *actions*. The framework could have been designed around isolated actions, but grouping them using controllers often useful for :doc:`routing </fundamentals/routing>`, applying :doc:`filters <filters>`, and :doc:`injecting common dependencies <dependency-injection>`. 

:doc:`Learn more about controllers and actions <actions>`.

Controller logic should be minimal and should not be focused on business logic or infrastructure concerns like data access. When testing controller logic, avoid testing the framework as much as possible. You should test how the controller *behaves* based on valid or invalid inputs, and what kind of response it provides based on the result of some business operation it performs.

Typical controller responsibilities:
	- Verify ``ModelState.IsValid``
	- Return an error response if ``ModelState`` is invalid
	- Retrieve a business entity from persistence
	- Perform an action on the business entity
	- Save the business entity to persistence
	- Return an appropriate ``IActionResult``

Unit Testing
------------
:doc:`Unit testing </testing/unit-testing>` involves testing a part of an app in isolation from its infrastructure and dependencies. When unit testing controller logic, only the contents of a single action should be tested, not the behavior of its dependencies.