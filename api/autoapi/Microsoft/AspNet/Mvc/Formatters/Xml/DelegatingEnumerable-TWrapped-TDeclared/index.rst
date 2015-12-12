

DelegatingEnumerable<TWrapped, TDeclared> Class
===============================================



.. contents:: 
   :local:



Summary
-------

Serializes :any:`System.Collections.Generic.IEnumerable\`1` types by delegating them through a concrete implementation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable\<TWrapped, TDeclared>`








Syntax
------

.. code-block:: csharp

   public class DelegatingEnumerable<TWrapped, TDeclared> : IEnumerable<TWrapped>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Xml/DelegatingEnumerable.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>.DelegatingEnumerable()
    
        
    
        Initializes a :any:`Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable\`2`\.
    
        
    
        
        .. code-block:: csharp
    
           public DelegatingEnumerable()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>.DelegatingEnumerable(System.Collections.Generic.IEnumerable<TDeclared>, Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider)
    
        
    
        Initializes a :any:`Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable\`2` with the original 
        :any:`System.Collections.Generic.IEnumerable\`1` and the wrapper provider for wrapping individual elements.
    
        
        
        
        :param source: The  instance to get the enumerator from.
        
        :type source: System.Collections.Generic.IEnumerable{{TDeclared}}
        
        
        :param elementWrapperProvider: The wrapper provider for wrapping individual elements.
        
        :type elementWrapperProvider: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider
    
        
        .. code-block:: csharp
    
           public DelegatingEnumerable(IEnumerable<TDeclared> source, IWrapperProvider elementWrapperProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>.Add(System.Object)
    
        
    
        The serializer requires every type it encounters can be serialized and deserialized.
        This type will never be used for deserialization, but we are required to implement the add
        method so that the type can be serialized. This will never be called.
    
        
        
        
        :param item: The item to add. Unused.
        
        :type item: System.Object
    
        
        .. code-block:: csharp
    
           public void Add(object item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>.GetEnumerator()
    
        
    
        Gets a delegating enumerator of the original :any:`System.Collections.Generic.IEnumerable\`1` source which is being
        wrapped.
    
        
        :rtype: System.Collections.Generic.IEnumerator{{TWrapped}}
        :return: The delegating enumerator of the original <see cref="T:System.Collections.Generic.IEnumerable`1" /> source.
    
        
        .. code-block:: csharp
    
           public IEnumerator<TWrapped> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>.System.Collections.IEnumerable.GetEnumerator()
    
        
    
        Gets a delegating enumerator of the original :any:`System.Collections.Generic.IEnumerable\`1` source which is being
        wrapped.
    
        
        :rtype: System.Collections.IEnumerator
        :return: The delegating enumerator of the original <see cref="T:System.Collections.Generic.IEnumerable`1" /> source.
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

