

ILogger<TCategoryName> Interface
================================






A generic interface for logging where the category name is derived from the specified
<em>TCategoryName</em> type name.
Generally used to enable activation of a named :any:`Microsoft.Extensions.Logging.ILogger` from dependency injection.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ILogger<out TCategoryName> : ILogger








.. dn:interface:: Microsoft.Extensions.Logging.ILogger`1
    :hidden:

.. dn:interface:: Microsoft.Extensions.Logging.ILogger<TCategoryName>

