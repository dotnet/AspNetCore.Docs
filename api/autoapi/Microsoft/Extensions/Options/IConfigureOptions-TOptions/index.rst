

IConfigureOptions<TOptions> Interface
=====================================





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

    public interface IConfigureOptions<in TOptions>
        where TOptions : class








.. dn:interface:: Microsoft.Extensions.Options.IConfigureOptions`1
    :hidden:

.. dn:interface:: Microsoft.Extensions.Options.IConfigureOptions<TOptions>

Methods
-------

.. dn:interface:: Microsoft.Extensions.Options.IConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Options.IConfigureOptions<TOptions>.Configure(TOptions)
    
        
    
        
        :type options: TOptions
    
        
        .. code-block:: csharp
    
            void Configure(TOptions options)
    

