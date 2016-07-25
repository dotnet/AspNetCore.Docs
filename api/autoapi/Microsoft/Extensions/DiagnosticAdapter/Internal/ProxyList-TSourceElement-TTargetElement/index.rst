

ProxyList<TSourceElement, TTargetElement> Class
===============================================





Namespace
    :dn:ns:`Microsoft.Extensions.DiagnosticAdapter.Internal`
Assemblies
    * Microsoft.Extensions.DiagnosticAdapter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList\<TSourceElement, TTargetElement>`








Syntax
------

.. code-block:: csharp

    public class ProxyList<TSourceElement, TTargetElement> : IReadOnlyList<TTargetElement>, IReadOnlyCollection<TTargetElement>, IEnumerable<TTargetElement>, IEnumerable








.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList`2
    :hidden:

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>

Constructors
------------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>.ProxyList(System.Collections.Generic.IList<TSourceElement>)
    
        
    
        
        :type source: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TSourceElement}
    
        
        .. code-block:: csharp
    
            public ProxyList(IList<TSourceElement> source)
    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>.ProxyList(System.Collections.Generic.IList<TSourceElement>, System.Type)
    
        
    
        
        :type source: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TSourceElement}
    
        
        :type proxyType: System.Type
    
        
        .. code-block:: csharp
    
            protected ProxyList(IList<TSourceElement> source, Type proxyType)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>.Item[System.Int32]
    
        
    
        
        :type index: System.Int32
        :rtype: TTargetElement
    
        
        .. code-block:: csharp
    
            public TTargetElement this[int index] { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{TTargetElement}
    
        
        .. code-block:: csharp
    
            public IEnumerator<TTargetElement> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

