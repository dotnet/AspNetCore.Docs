

SystemClock Class
=================






Provides access to the normal system clock.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.SystemClock`








Syntax
------

.. code-block:: csharp

    public class SystemClock : ISystemClock








.. dn:class:: Microsoft.AspNetCore.Authentication.SystemClock
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.SystemClock

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.SystemClock
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.SystemClock.UtcNow
    
        
    
        
        Retrieves the current system time in UTC.
    
        
        :rtype: System.DateTimeOffset
    
        
        .. code-block:: csharp
    
            public DateTimeOffset UtcNow { get; }
    

