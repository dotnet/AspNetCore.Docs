

DelegatingEnumerator<TWrapped, TDeclared> Class
===============================================






Delegates enumeration of elements to the original enumerator and wraps the items
with the supplied :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator\<TWrapped, TDeclared>`








Syntax
------

.. code-block:: csharp

    public class DelegatingEnumerator<TWrapped, TDeclared> : IEnumerator<TWrapped>, IDisposable, IEnumerator








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator`2
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.Current
    
        
        :rtype: TWrapped
    
        
        .. code-block:: csharp
    
            public TWrapped Current
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.DelegatingEnumerator(System.Collections.Generic.IEnumerator<TDeclared>, Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerable\`2` which enumerates 
        over the elements of the original enumerator and wraps them using the supplied
        :any:`Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider`\.
    
        
    
        
        :param inner: The original enumerator.
        
        :type inner: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{TDeclared}
    
        
        :param wrapperProvider: The wrapper provider to wrap individual elements.
        
        :type wrapperProvider: Microsoft.AspNetCore.Mvc.Formatters.Xml.IWrapperProvider
    
        
        .. code-block:: csharp
    
            public DelegatingEnumerator(IEnumerator<TDeclared> inner, IWrapperProvider wrapperProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Xml.DelegatingEnumerator<TWrapped, TDeclared>.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

