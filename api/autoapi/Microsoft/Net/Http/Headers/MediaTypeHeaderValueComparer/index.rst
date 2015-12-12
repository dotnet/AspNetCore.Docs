

MediaTypeHeaderValueComparer Class
==================================



.. contents:: 
   :local:



Summary
-------

Implementation of :any:`System.Collections.Generic.IComparer\`1` that can compare accept media type header fields
based on their quality values (a.k.a q-values).





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.MediaTypeHeaderValueComparer`








Syntax
------

.. code-block:: csharp

   public class MediaTypeHeaderValueComparer : IComparer<MediaTypeHeaderValue>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Net.Http.Headers/MediaTypeHeaderValueComparer.cs>`_





.. dn:class:: Microsoft.Net.Http.Headers.MediaTypeHeaderValueComparer

Methods
-------

.. dn:class:: Microsoft.Net.Http.Headers.MediaTypeHeaderValueComparer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Headers.MediaTypeHeaderValueComparer.Compare(Microsoft.Net.Http.Headers.MediaTypeHeaderValue, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
        
        
        :type mediaType1: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        
        
        :type mediaType2: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Compare(MediaTypeHeaderValue mediaType1, MediaTypeHeaderValue mediaType2)
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Headers.MediaTypeHeaderValueComparer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Headers.MediaTypeHeaderValueComparer.QualityComparer
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValueComparer
    
        
        .. code-block:: csharp
    
           public static MediaTypeHeaderValueComparer QualityComparer { get; }
    

