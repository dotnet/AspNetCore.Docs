

StateMachine<TReturn> Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.StateMachine\<TReturn>`








Syntax
------

.. code-block:: csharp

   public abstract class StateMachine<TReturn>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/StateMachine.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.StateMachine<TReturn>

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.StateMachine<TReturn>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.StateMachine<TReturn>.Stay()
    
        
    
        Returns a result indicating that this state has no output and the machine should remain in this state
    
        
        :rtype: Microsoft.AspNet.Razor.StateMachine`1.StateResult
    
        
        .. code-block:: csharp
    
           protected StateMachine<TReturn>.StateResult Stay()
    
    .. dn:method:: Microsoft.AspNet.Razor.StateMachine<TReturn>.Stay(TReturn)
    
        
    
        Returns a result containing the specified output and indicating that the next call to 
        :dn:meth:`Microsoft.AspNet.Razor.StateMachine\`1.Turn` should re-invoke the current state.
    
        
        
        
        :type output: {TReturn}
        :rtype: Microsoft.AspNet.Razor.StateMachine`1.StateResult
    
        
        .. code-block:: csharp
    
           protected StateMachine<TReturn>.StateResult Stay(TReturn output)
    
    .. dn:method:: Microsoft.AspNet.Razor.StateMachine<TReturn>.Stop()
    
        
    
        Returns a result indicating that the machine should stop executing and return null output.
    
        
        :rtype: Microsoft.AspNet.Razor.StateMachine`1.StateResult
    
        
        .. code-block:: csharp
    
           protected StateMachine<TReturn>.StateResult Stop()
    
    .. dn:method:: Microsoft.AspNet.Razor.StateMachine<TReturn>.Transition(Microsoft.AspNet.Razor.StateMachine<TReturn>.State)
    
        
    
        Returns a result indicating that this state has no output and the machine should immediately invoke the specified state
    
        
        
        
        :type newState: Microsoft.AspNet.Razor.StateMachine`1.State
        :rtype: Microsoft.AspNet.Razor.StateMachine`1.StateResult
    
        
        .. code-block:: csharp
    
           protected StateMachine<TReturn>.StateResult Transition(StateMachine<TReturn>.State newState)
    
    .. dn:method:: Microsoft.AspNet.Razor.StateMachine<TReturn>.Transition(TReturn, Microsoft.AspNet.Razor.StateMachine<TReturn>.State)
    
        
    
        Returns a result containing the specified output and indicating that the next call to 
        :dn:meth:`Microsoft.AspNet.Razor.StateMachine\`1.Turn` should invoke the provided state.
    
        
        
        
        :type output: {TReturn}
        
        
        :type newState: Microsoft.AspNet.Razor.StateMachine`1.State
        :rtype: Microsoft.AspNet.Razor.StateMachine`1.StateResult
    
        
        .. code-block:: csharp
    
           protected StateMachine<TReturn>.StateResult Transition(TReturn output, StateMachine<TReturn>.State newState)
    
    .. dn:method:: Microsoft.AspNet.Razor.StateMachine<TReturn>.Turn()
    
        
        :rtype: {TReturn}
    
        
        .. code-block:: csharp
    
           protected virtual TReturn Turn()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.StateMachine<TReturn>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.StateMachine<TReturn>.CurrentState
    
        
        :rtype: Microsoft.AspNet.Razor.StateMachine`1.State
    
        
        .. code-block:: csharp
    
           protected StateMachine<TReturn>.State CurrentState { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.StateMachine<TReturn>.StartState
    
        
        :rtype: Microsoft.AspNet.Razor.StateMachine`1.State
    
        
        .. code-block:: csharp
    
           protected abstract StateMachine<TReturn>.State StartState { get; }
    

