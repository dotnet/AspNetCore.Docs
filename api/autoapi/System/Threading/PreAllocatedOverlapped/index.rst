

PreAllocatedOverlapped Class
============================





Namespace
    :dn:ns:`System.Threading`
Assemblies
    * Microsoft.Net.Http.Server

----

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








.. dn:class:: System.Threading.PreAllocatedOverlapped
    :hidden:

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
    

