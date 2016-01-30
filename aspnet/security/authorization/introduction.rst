.. _security-authorization-introduction:

Introduction
^^^^^^^^^^^^

Authorization refers to the process that determines what a user is able to do. For example user Adam may be able to create a document library, add documents, edit documents and delete them. User Bob may only be authorized to read documents in a single library.

Authorization is orthogonal and independent from authentication, which is the process of ascertaining who a user is. Authentication may create one or more identities for the current user.

Authorization Types
-------------------

In ASP.NET v5 authorization now provides simple declarative :ref:`role <security-authorization-role-based>` and a :ref:`richer policy based<security-authorization-policies-based>` model where authorization is expressed in requirements and handlers evaluate a users claims against requirements. Imperative checks can be based on simple policies or polices which evaluate both the user identity and properties of the resource that the user is attempting to access.

Namespaces
----------

The authorization attribute is part of the MVC namespace, specifically you must add  ``using Microsoft.AspNet.Authorization;``