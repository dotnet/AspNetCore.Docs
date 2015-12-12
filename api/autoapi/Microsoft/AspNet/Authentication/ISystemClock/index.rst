

ISystemClock Interface
======================



.. contents:: 
   :local:



Summary
-------

Abstracts the system clock to facilitate testing.











Syntax
------

.. code-block:: csharp

   public interface ISystemClock





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/ISystemClock.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.ISystemClock

Properties
----------

.. dn:interface:: Microsoft.AspNet.Authentication.ISystemClock
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.ISystemClock.UtcNow
    
        
    
        Retrieves the current system time in UTC.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           DateTimeOffset UtcNow { get; }
    

