

UrlPathDecoder Class
====================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.UrlPathDecoder`








Syntax
------

.. code-block:: csharp

    public class UrlPathDecoder








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.UrlPathDecoder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.UrlPathDecoder

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.UrlPathDecoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.UrlPathDecoder.Unescape(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator, Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator)
    
        
    
        
        Unescapes the string between given memory iterators in place.
    
        
    
        
        :param start: The iterator points to the beginning of the sequence.
        
        :type start: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
    
        
        :param end: The iterator points to the byte behind the end of the sequence.
        
        :type end: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.MemoryPoolIterator
        :return: The iterator points to the byte behind the end of the processed sequence.
    
        
        .. code-block:: csharp
    
            public static MemoryPoolIterator Unescape(MemoryPoolIterator start, MemoryPoolIterator end)
    

