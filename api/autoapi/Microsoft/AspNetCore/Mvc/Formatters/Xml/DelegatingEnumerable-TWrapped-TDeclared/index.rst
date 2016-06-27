

DelegatingEnumerable<TWrapped, TDeclared> Class
===============================================






Serializes :any:`System.Collections.Generic.IEnumerable\`1` types by delegating them through a concrete implementation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Xml`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Xml

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable\<TWrapped, TDeclared>`








Syntax
------

.. code-block:: csharp

    public class DelegatingEnumerable<TWrapped, TDeclared> : IEnumerable<TWrapped>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable`2
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>.DelegatingEnumerable()
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable\`2`\. 
    
        
    
        
        .. code-block:: csharp
    
            public DelegatingEnumerable()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>.DelegatingEnumerable(System.Collections.Generic.IEnumerable<TDeclared>, Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable\`2` with the original 
        :any:`System.Collections.Generic.IEnumerable\`1` and the wrapper provider for wrapping individual elements.
    
        
    
        
        :param source: The :any:`System.Collections.Generic.IEnumerable\`1` instance to get the enumerator from.
        
        :type source: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{TDeclared}
    
        
        :param elementWrapperProvider: The wrapper provider for wrapping individual elements.
        
        :type elementWrapperProvider: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider
    
        
        .. code-block:: csharp
    
            public DelegatingEnumerable(IEnumerable<TDeclared> source, IWrapperProvider elementWrapperProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>.Add(System.Object)
    
        
    
        
        The serializer requires every type it encounters can be serialized and deserialized.
        This type will never be used for deserialization, but we are required to implement the add
        method so that the type can be serialized. This will never be called.
    
        
    
        
        :param item: The item to add. Unused.
        
        :type item: System.Object
    
        
        .. code-block:: csharp
    
            public void Add(object item)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>.GetEnumerator()
    
        
    
        
        Gets a delegating enumerator of the original :any:`System.Collections.Generic.IEnumerable\`1` source which is being
        wrapped.
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{TWrapped}
        :return: The delegating enumerator of the original :any:`System.Collections.Generic.IEnumerable\`1` source.
    
        
        .. code-block:: csharp
    
            public IEnumerator<TWrapped> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable<TWrapped, TDeclared>.System.Collections.IEnumerable.GetEnumerator()
    
        
    
        
        Gets a delegating enumerator of the original :any:`System.Collections.Generic.IEnumerable\`1` source which is being
        wrapped.
    
        
        :rtype: System.Collections.IEnumerator
        :return: The delegating enumerator of the original :any:`System.Collections.Generic.IEnumerable\`1` source.
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

