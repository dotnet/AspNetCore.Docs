

UrlPathDecoder Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.UrlPathDecoder`








Syntax
------

.. code-block:: csharp

   public class UrlPathDecoder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/UrlPathDecoder.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.UrlPathDecoder

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.UrlPathDecoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.UrlPathDecoder.Unescape(Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2, Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2)
    
        
    
        Unescapes the string between given memory iterators in place.
    
        
        
        
        :param start: The iterator points to the beginning of the sequence.
        
        :type start: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
        
        
        :param end: The iterator points to the byte behind the end of the sequence.
        
        :type end: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
        :rtype: Microsoft.AspNet.Server.Kestrel.Infrastructure.MemoryPoolIterator2
        :return: The iterator points to the byte behind the end of the processed sequence.
    
        
        .. code-block:: csharp
    
           public static MemoryPoolIterator2 Unescape(MemoryPoolIterator2 start, MemoryPoolIterator2 end)
    

