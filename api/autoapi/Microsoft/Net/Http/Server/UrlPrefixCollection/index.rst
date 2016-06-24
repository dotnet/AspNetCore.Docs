

UrlPrefixCollection Class
=========================






A collection or URL prefixes


Namespace
    :dn:ns:`Microsoft.Net.Http.Server`
Assemblies
    * Microsoft.Net.Http.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Server.UrlPrefixCollection`








Syntax
------

.. code-block:: csharp

    public class UrlPrefixCollection : ICollection<UrlPrefix>, IEnumerable<UrlPrefix>, IEnumerable








.. dn:class:: Microsoft.Net.Http.Server.UrlPrefixCollection
    :hidden:

.. dn:class:: Microsoft.Net.Http.Server.UrlPrefixCollection

Methods
-------

.. dn:class:: Microsoft.Net.Http.Server.UrlPrefixCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefixCollection.Add(Microsoft.Net.Http.Server.UrlPrefix)
    
        
    
        
        :type item: Microsoft.Net.Http.Server.UrlPrefix
    
        
        .. code-block:: csharp
    
            public void Add(UrlPrefix item)
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefixCollection.Add(System.String)
    
        
    
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
            public void Add(string prefix)
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefixCollection.Clear()
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefixCollection.Contains(Microsoft.Net.Http.Server.UrlPrefix)
    
        
    
        
        :type item: Microsoft.Net.Http.Server.UrlPrefix
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Contains(UrlPrefix item)
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefixCollection.CopyTo(Microsoft.Net.Http.Server.UrlPrefix[], System.Int32)
    
        
    
        
        :type array: Microsoft.Net.Http.Server.UrlPrefix<Microsoft.Net.Http.Server.UrlPrefix>[]
    
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
            public void CopyTo(UrlPrefix[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefixCollection.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.Net.Http.Server.UrlPrefix<Microsoft.Net.Http.Server.UrlPrefix>}
    
        
        .. code-block:: csharp
    
            public IEnumerator<UrlPrefix> GetEnumerator()
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefixCollection.Remove(Microsoft.Net.Http.Server.UrlPrefix)
    
        
    
        
        :type item: Microsoft.Net.Http.Server.UrlPrefix
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Remove(UrlPrefix item)
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefixCollection.Remove(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Remove(string prefix)
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefixCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:class:: Microsoft.Net.Http.Server.UrlPrefixCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Server.UrlPrefixCollection.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.Net.Http.Server.UrlPrefixCollection.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReadOnly { get; }
    

