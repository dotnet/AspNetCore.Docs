

DateHeaderValueManager Class
============================






Manages the generation of the date header value.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager`








Syntax
------

.. code-block:: csharp

    public class DateHeaderValueManager : IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager.DateHeaderValueManager()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager` class.
    
        
    
        
        .. code-block:: csharp
    
            public DateHeaderValueManager()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager.Dispose()
    
        
    
        
        Releases all resources used by the current instance of :any:`Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager`\.
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager.GetDateHeaderValue()
    
        
    
        
        Returns a value representing the current server date/time for use in the HTTP "Date" response header
        in accordance with http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.18
    
        
        :rtype: System.String
        :return: The value.
    
        
        .. code-block:: csharp
    
            public virtual string GetDateHeaderValue()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.DateHeaderValueManager.GetDateHeaderValueBytes()
    
        
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public byte[] GetDateHeaderValueBytes()
    

