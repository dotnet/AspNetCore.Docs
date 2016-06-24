

IOptionsMonitor<TOptions> Interface
===================================






Used for notifications when TOptions instances change.


Namespace
    :dn:ns:`Microsoft.Extensions.Options`
Assemblies
    * Microsoft.Extensions.Options

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IOptionsMonitor<out TOptions>








.. dn:interface:: Microsoft.Extensions.Options.IOptionsMonitor`1
    :hidden:

.. dn:interface:: Microsoft.Extensions.Options.IOptionsMonitor<TOptions>

Properties
----------

.. dn:interface:: Microsoft.Extensions.Options.IOptionsMonitor<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Options.IOptionsMonitor<TOptions>.CurrentValue
    
        
    
        
        Returns the current TOptions instance.
    
        
        :rtype: TOptions
    
        
        .. code-block:: csharp
    
            TOptions CurrentValue { get; }
    

Methods
-------

.. dn:interface:: Microsoft.Extensions.Options.IOptionsMonitor<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Options.IOptionsMonitor<TOptions>.OnChange(System.Action<TOptions>)
    
        
    
        
        Registers the listener to be called whenever TOptions changes.
    
        
    
        
        :param listener: The action to be invoked when TOptions has changed.
        
        :type listener: System.Action<System.Action`1>{TOptions}
        :rtype: System.IDisposable
        :return: An IDisposable which should be disposed to stop listening for changes.
    
        
        .. code-block:: csharp
    
            IDisposable OnChange(Action<TOptions> listener)
    

