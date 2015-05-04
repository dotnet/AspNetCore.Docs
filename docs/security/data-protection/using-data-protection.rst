Getting Started with the Data Protection APIs
=============================================

At its simplest protecting data is consists of the following steps:

#. Create a data protector from a data protection provider.
#. Call the Protect method with the data you want to protect.
#. Call the Unprotect method with the data you want to turn back into plain text.

Most frameworks such as ASP.NET or SignalR already configure the data protection system and add it to a service container you access via dependency injection. The following sample demonstrates configuring a service container for dependency injection and registering the data protection stack, receiving the data protection provider via DI, creating a protector and protecting then unprotecting data

.. literalinclude:: using-data-protection/samples/protectunprotect.cs
        :language: c#
        :emphasize-lines: 26,34-40
        :linenos:

When you create a protector you must provide one or more :doc:`consumer-apis/purpose-strings`. A purpose string provides isolation between consumers, for example a protector created with a purpose string of "green" would not be able to unprotect data provided by a protector with a purpose of "purple".

.. include:: thread-safety-included.txt
