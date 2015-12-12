

IConfigureOptions<TOptions> Interface
=====================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IConfigureOptions<in TOptions> where TOptions : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/options/src/Microsoft.Extensions.OptionsModel/IConfigureOptions.cs>`_





.. dn:interface:: Microsoft.Extensions.OptionsModel.IConfigureOptions<TOptions>

Methods
-------

.. dn:interface:: Microsoft.Extensions.OptionsModel.IConfigureOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.OptionsModel.IConfigureOptions<TOptions>.Configure(TOptions)
    
        
        
        
        :type options: {TOptions}
    
        
        .. code-block:: csharp
    
           void Configure(TOptions options)
    

