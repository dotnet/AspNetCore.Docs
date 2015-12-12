

DateHeaderValueManager Class
============================



.. contents:: 
   :local:



Summary
-------

Manages the generation of the date header value.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager`








Syntax
------

.. code-block:: csharp

   public class DateHeaderValueManager : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Http/DateHeaderValueManager.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager.DateHeaderValueManager()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager` class.
    
        
    
        
        .. code-block:: csharp
    
           public DateHeaderValueManager()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager.Dispose()
    
        
    
        Releases all resources used by the current instance of :any:`Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager`\.
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.DateHeaderValueManager.GetDateHeaderValue()
    
        
    
        Returns a value representing the current server date/time for use in the HTTP "Date" response header
        in accordance with http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.18
    
        
        :rtype: System.String
        :return: The value.
    
        
        .. code-block:: csharp
    
           public virtual string GetDateHeaderValue()
    

