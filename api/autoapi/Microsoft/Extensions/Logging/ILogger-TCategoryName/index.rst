

ILogger<TCategoryName> Interface
================================



.. contents:: 
   :local:



Summary
-------

A generic interface for logging where the category name is derived from the specified
``TCategoryName`` type name.
Generally used to enable activation of a named :any:`Microsoft.Extensions.Logging.ILogger` from dependency injection.











Syntax
------

.. code-block:: csharp

   public interface ILogger<out TCategoryName> : ILogger





GitHub
------

`View on GitHub <https://github.com/aspnet/logging/blob/master/src/Microsoft.Extensions.Logging.Abstractions/ILoggerOfT.cs>`_





.. dn:interface:: Microsoft.Extensions.Logging.ILogger<TCategoryName>

