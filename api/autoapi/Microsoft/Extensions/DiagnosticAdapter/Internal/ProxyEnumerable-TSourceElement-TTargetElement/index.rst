

ProxyEnumerable<TSourceElement, TTargetElement> Class
=====================================================





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
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable\<TSourceElement, TTargetElement>`








Syntax
------

.. code-block:: csharp

    public class ProxyEnumerable<TSourceElement, TTargetElement> : IEnumerable<TTargetElement>, IEnumerable








.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable`2
    :hidden:

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>

Constructors
------------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>.ProxyEnumerable(System.Collections.Generic.IEnumerable<TSourceElement>, System.Type)
    
        
    
        
        :type source: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{TSourceElement}
    
        
        :type proxyType: System.Type
    
        
        .. code-block:: csharp
    
            public ProxyEnumerable(IEnumerable<TSourceElement> source, Type proxyType)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{TTargetElement}
    
        
        .. code-block:: csharp
    
            public IEnumerator<TTargetElement> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

