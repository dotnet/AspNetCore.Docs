

ChangeToken Class
=================






Propagates notifications that a change has occured.


Namespace
    :dn:ns:`Microsoft.Extensions.Primitives`
Assemblies
    * Microsoft.Extensions.Primitives

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Primitives.ChangeToken`








Syntax
------

.. code-block:: csharp

    public class ChangeToken








.. dn:class:: Microsoft.Extensions.Primitives.ChangeToken
    :hidden:

.. dn:class:: Microsoft.Extensions.Primitives.ChangeToken

Methods
-------

.. dn:class:: Microsoft.Extensions.Primitives.ChangeToken
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Primitives.ChangeToken.OnChange(System.Func<Microsoft.Extensions.Primitives.IChangeToken>, System.Action)
    
        
    
        
        Registers the <em>changeTokenConsumer</em> action to be called whenever the token produced changes.
    
        
    
        
        :param changeTokenProducer: Produces the change token.
        
        :type changeTokenProducer: System.Func<System.Func`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        :param changeTokenConsumer: Action called when the token changes.
        
        :type changeTokenConsumer: System.Action
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public static IDisposable OnChange(Func<IChangeToken> changeTokenProducer, Action changeTokenConsumer)
    
    .. dn:method:: Microsoft.Extensions.Primitives.ChangeToken.OnChange<TState>(System.Func<Microsoft.Extensions.Primitives.IChangeToken>, System.Action<TState>, TState)
    
        
    
        
        Registers the <em>changeTokenConsumer</em> action to be called whenever the token produced changes.
    
        
    
        
        :param changeTokenProducer: Produces the change token.
        
        :type changeTokenProducer: System.Func<System.Func`1>{Microsoft.Extensions.Primitives.IChangeToken<Microsoft.Extensions.Primitives.IChangeToken>}
    
        
        :param changeTokenConsumer: Action called when the token changes.
        
        :type changeTokenConsumer: System.Action<System.Action`1>{TState}
    
        
        :param state: state for the consumer.
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public static IDisposable OnChange<TState>(Func<IChangeToken> changeTokenProducer, Action<TState> changeTokenConsumer, TState state)
    

