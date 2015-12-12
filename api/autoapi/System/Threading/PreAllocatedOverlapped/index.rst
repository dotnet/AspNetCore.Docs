

PreAllocatedOverlapped Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Threading.PreAllocatedOverlapped`








Syntax
------

.. code-block:: csharp

   public sealed class PreAllocatedOverlapped : IDisposable, IDeferredDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/weblistener/src/Microsoft.Net.Http.Server/Overlapped/PreAllocatedOverlapped.cs>`_





.. dn:class:: System.Threading.PreAllocatedOverlapped

Constructors
------------

.. dn:class:: System.Threading.PreAllocatedOverlapped
    :noindex:
    :hidden:

    
    .. dn:constructor:: System.Threading.PreAllocatedOverlapped.PreAllocatedOverlapped(System.Threading.IOCompletionCallback, System.Object, System.Object)
    
        
        
        
        :type callback: System.Threading.IOCompletionCallback
        
        
        :type state: System.Object
        
        
        :type pinData: System.Object
    
        
        .. code-block:: csharp
    
           public PreAllocatedOverlapped(IOCompletionCallback callback, object state, object pinData)
    

Methods
-------

.. dn:class:: System.Threading.PreAllocatedOverlapped
    :noindex:
    :hidden:

    
    .. dn:method:: System.Threading.PreAllocatedOverlapped.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: System.Threading.PreAllocatedOverlapped.Finalize()
    
        
    
        
        .. code-block:: csharp
    
           protected void Finalize()
    

