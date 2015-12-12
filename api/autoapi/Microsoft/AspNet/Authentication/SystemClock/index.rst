

SystemClock Class
=================



.. contents:: 
   :local:



Summary
-------

Provides access to the normal system clock.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.SystemClock`








Syntax
------

.. code-block:: csharp

   public class SystemClock : ISystemClock





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/SystemClock.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.SystemClock

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.SystemClock
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.SystemClock.UtcNow
    
        
    
        Retrieves the current system time in UTC.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
           public DateTimeOffset UtcNow { get; }
    

