

DelegatingEnumerator<TWrapped, TDeclared> Class
===============================================



.. contents:: 
   :local:



Summary
-------

Delegates enumeration of elements to the original enumerator and wraps the items
with the supplied :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator\<TWrapped, TDeclared>`








Syntax
------

.. code-block:: csharp

   public class DelegatingEnumerator<TWrapped, TDeclared> : IEnumerator<TWrapped>, IDisposable, IEnumerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Xml/DelegatingEnumerator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.DelegatingEnumerator(System.Collections.Generic.IEnumerator<TDeclared>, Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider)
    
        
    
        Initializes a :any:`Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerable\`2` which enumerates
        over the elements of the original enumerator and wraps them using the supplied 
        :any:`Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider`\.
    
        
        
        
        :param inner: The original enumerator.
        
        :type inner: System.Collections.Generic.IEnumerator{{TDeclared}}
        
        
        :param wrapperProvider: The wrapper provider to wrap individual elements.
        
        :type wrapperProvider: Microsoft.AspNet.Mvc.Formatters.Xml.IWrapperProvider
    
        
        .. code-block:: csharp
    
           public DelegatingEnumerator(IEnumerator<TDeclared> inner, IWrapperProvider wrapperProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.Reset()
    
        
    
        
        .. code-block:: csharp
    
           public void Reset()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.Current
    
        
        :rtype: {TWrapped}
    
        
        .. code-block:: csharp
    
           public TWrapped Current { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object IEnumerator.Current { get; }
    

