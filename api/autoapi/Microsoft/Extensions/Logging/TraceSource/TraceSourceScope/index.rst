

TraceSourceScope Class
======================






Provides an IDisposable that represents a logical operation scope based on System.Diagnostics LogicalOperationStack


Namespace
    :dn:ns:`Microsoft.Extensions.Logging.TraceSource`
Assemblies
    * Microsoft.Extensions.Logging.TraceSource

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.TraceSource.TraceSourceScope`








Syntax
------

.. code-block:: csharp

    public class TraceSourceScope : IDisposable








.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceScope
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceScope

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceScope
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.TraceSource.TraceSourceScope.TraceSourceScope(System.Object)
    
        
    
        
        Pushes state onto the LogicalOperationStack by calling 
        :dn:meth:`System.Diagnostics.CorrelationManager.StartLogicalOperation(System.Object)`
    
        
    
        
        :param state: The state.
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public TraceSourceScope(object state)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceScope
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSource.TraceSourceScope.Dispose()
    
        
    
        
        Pops a state off the LogicalOperationStack by calling 
        :dn:meth:`System.Diagnostics.CorrelationManager.StopLogicalOperation`
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

