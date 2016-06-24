

ServiceCollection Class
=======================






Default implementation of :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.DependencyInjection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.ServiceCollection`








Syntax
------

.. code-block:: csharp

    public class ServiceCollection : IServiceCollection, IList<ServiceDescriptor>, ICollection<ServiceDescriptor>, IEnumerable<ServiceDescriptor>, IEnumerable








.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceCollection
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceCollection

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceCollection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollection.Clear()
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollection.Contains(Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        
        :type item: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Contains(ServiceDescriptor item)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollection.CopyTo(Microsoft.Extensions.DependencyInjection.ServiceDescriptor[], System.Int32)
    
        
    
        
        :type array: Microsoft.Extensions.DependencyInjection.ServiceDescriptor<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>[]
    
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
            public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollection.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.Extensions.DependencyInjection.ServiceDescriptor<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>}
    
        
        .. code-block:: csharp
    
            public IEnumerator<ServiceDescriptor> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollection.IndexOf(Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        
        :type item: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int IndexOf(ServiceDescriptor item)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollection.Insert(System.Int32, Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        
        :type index: System.Int32
    
        
        :type item: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public void Insert(int index, ServiceDescriptor item)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollection.Remove(Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        
        :type item: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Remove(ServiceDescriptor item)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollection.RemoveAt(System.Int32)
    
        
    
        
        :type index: System.Int32
    
        
        .. code-block:: csharp
    
            public void RemoveAt(int index)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollection.System.Collections.Generic.ICollection<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>.Add(Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        
        :type item: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            void ICollection<ServiceDescriptor>.Add(ServiceDescriptor item)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollection.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceCollection
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.ServiceCollection.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.ServiceCollection.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.ServiceCollection.Item[System.Int32]
    
        
    
        
        :type index: System.Int32
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public ServiceDescriptor this[int index] { get; set; }
    

