

MediaTypeCollection Class
=========================






A collection of media types.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Collections.ObjectModel.Collection{System.String}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection`








Syntax
------

.. code-block:: csharp

    public class MediaTypeCollection : Collection<string>, IList<string>, ICollection<string>, IList, ICollection, IReadOnlyList<string>, IReadOnlyCollection<string>, IEnumerable<string>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection.MediaTypeCollection()
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection`\.
    
        
    
        
        .. code-block:: csharp
    
            public MediaTypeCollection()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection.Add(Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Adds an object to the end of the :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection`\. 
    
        
    
        
        :param item: The media type to be added to the end of the :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection`\.
        
        :type item: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
            public void Add(MediaTypeHeaderValue item)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection.Insert(System.Int32, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Inserts an element into the :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection` at the specified index.
    
        
    
        
        :param index: The zero-based index at which <em>item</em> should be inserted.
        
        :type index: System.Int32
    
        
        :param item: The media type to insert.
        
        :type item: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
            public void Insert(int index, MediaTypeHeaderValue item)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection.Remove(Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Removes the first occurrence of a specific media type from the :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection`\.
    
        
    
        
        :type item: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        :rtype: System.Boolean
        :return:
            ``true`` if *item* is successfully removed; otherwise, false.
            This method also returns ``false`` if *item* was not found in the original 
            :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection`\.
    
        
        .. code-block:: csharp
    
            public bool Remove(MediaTypeHeaderValue item)
    

