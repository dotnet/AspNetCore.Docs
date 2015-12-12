

IOptions<TOptions> Interface
============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IOptions<out TOptions> where TOptions : class, new ()





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/options/src/Microsoft.Extensions.OptionsModel/IOptions.cs>`_





.. dn:interface:: Microsoft.Extensions.OptionsModel.IOptions<TOptions>

Properties
----------

.. dn:interface:: Microsoft.Extensions.OptionsModel.IOptions<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.OptionsModel.IOptions<TOptions>.Value
    
        
        :rtype: {TOptions}
    
        
        .. code-block:: csharp
    
           TOptions Value { get; }
    

