

DateHeaderValueManager Class
============================






Manages the generation of the date header value.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager`








Syntax
------

.. code-block:: csharp

    public class DateHeaderValueManager : IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager.DateHeaderValueManager()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager` class.
    
        
    
        
        .. code-block:: csharp
    
            public DateHeaderValueManager()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager.Dispose()
    
        
    
        
        Releases all resources used by the current instance of :any:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager`\.
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager.GetDateHeaderValues()
    
        
    
        
        Returns a value representing the current server date/time for use in the HTTP "Date" response header
        in accordance with http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.18
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.DateHeaderValueManager.DateHeaderValues
        :return: The value in string and byte[] format.
    
        
        .. code-block:: csharp
    
            public DateHeaderValueManager.DateHeaderValues GetDateHeaderValues()
    

