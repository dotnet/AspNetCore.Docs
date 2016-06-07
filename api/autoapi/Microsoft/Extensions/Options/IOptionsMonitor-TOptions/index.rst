

IOptionsMonitor<TOptions> Interface
===================================





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
    
        
        :rtype: TOptions
    
        
        .. code-block:: csharp
    
            TOptions CurrentValue
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.Extensions.Options.IOptionsMonitor<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Options.IOptionsMonitor<TOptions>.OnChange(System.Action<TOptions>)
    
        
    
        
        :type listener: System.Action<System.Action`1>{TOptions}
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            IDisposable OnChange(Action<TOptions> listener)
    

