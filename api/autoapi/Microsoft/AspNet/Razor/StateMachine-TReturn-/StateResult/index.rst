

StateResult Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.StateMachine\<TReturn>.StateResult`








Syntax
------

.. code-block:: csharp

   protected class StateResult





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/StateMachine.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.StateMachine<TReturn>.StateResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.StateMachine<TReturn>.StateResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.StateMachine<TReturn>.StateResult.StateResult(Microsoft.AspNet.Razor.StateMachine<TReturn>.State)
    
        
        
        
        :type next: Microsoft.AspNet.Razor.StateMachine`1.State
    
        
        .. code-block:: csharp
    
           public StateResult(StateMachine<TReturn>.State next)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.StateMachine<TReturn>.StateResult.StateResult(TReturn, Microsoft.AspNet.Razor.StateMachine<TReturn>.State)
    
        
        
        
        :type output: {TReturn}
        
        
        :type next: Microsoft.AspNet.Razor.StateMachine`1.State
    
        
        .. code-block:: csharp
    
           public StateResult(TReturn output, StateMachine<TReturn>.State next)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.StateMachine<TReturn>.StateResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.StateMachine<TReturn>.StateResult.HasOutput
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasOutput { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.StateMachine<TReturn>.StateResult.Next
    
        
        :rtype: Microsoft.AspNet.Razor.StateMachine`1.State
    
        
        .. code-block:: csharp
    
           public StateMachine<TReturn>.State Next { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.StateMachine<TReturn>.StateResult.Output
    
        
        :rtype: {TReturn}
    
        
        .. code-block:: csharp
    
           public TReturn Output { get; set; }
    

