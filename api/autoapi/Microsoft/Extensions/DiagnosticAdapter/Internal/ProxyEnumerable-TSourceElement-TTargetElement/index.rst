

ProxyEnumerable<TSourceElement, TTargetElement> Class
=====================================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/eventnotification/blob/master/src/Microsoft.Extensions.DiagnosticAdapter/Internal/ProxyEnumerable.cs>`_





.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>

Constructors
------------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>.ProxyEnumerable(System.Collections.Generic.IEnumerable<TSourceElement>, System.Type)
    
        
        
        
        :type source: System.Collections.Generic.IEnumerable{{TSourceElement}}
        
        
        :type proxyType: System.Type
    
        
        .. code-block:: csharp
    
           public ProxyEnumerable(IEnumerable<TSourceElement> source, Type proxyType)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{{TTargetElement}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<TTargetElement> GetEnumerator()
    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyEnumerable<TSourceElement, TTargetElement>.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

