

ProxyList<TSourceElement, TTargetElement> Class
===============================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/eventnotification/blob/master/src/Microsoft.Extensions.DiagnosticAdapter/Internal/ProxyList.cs>`_





.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>

Constructors
------------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>.ProxyList(System.Collections.Generic.IList<TSourceElement>)
    
        
        
        
        :type source: System.Collections.Generic.IList{{TSourceElement}}
    
        
        .. code-block:: csharp
    
           public ProxyList(IList<TSourceElement> source)
    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>.ProxyList(System.Collections.Generic.IList<TSourceElement>, System.Type)
    
        
        
        
        :type source: System.Collections.Generic.IList{{TSourceElement}}
        
        
        :type proxyType: System.Type
    
        
        .. code-block:: csharp
    
           protected ProxyList(IList<TSourceElement> source, Type proxyType)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{{TTargetElement}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<TTargetElement> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyList<TSourceElement, TTargetElement>.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

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
        :rtype: {TTargetElement}
    
        
        .. code-block:: csharp
    
           public TTargetElement this[int index] { get; }
    

