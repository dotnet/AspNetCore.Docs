

MediaTypeHeaderValueComparer Class
==================================






Implementation of :any:`System.Collections.Generic.IComparer\`1` that can compare accept media type header fields
based on their quality values (a.k.a q-values).


Namespace
    :dn:ns:`Microsoft.Net.Http.Headers`
Assemblies
    * Microsoft.Net.Http.Headers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Headers.MediaTypeHeaderValueComparer`








Syntax
------

.. code-block:: csharp

    public class MediaTypeHeaderValueComparer : IComparer<MediaTypeHeaderValue>








.. dn:class:: Microsoft.Net.Http.Headers.MediaTypeHeaderValueComparer
    :hidden:

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
    

