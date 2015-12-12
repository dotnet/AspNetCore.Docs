

ILogValues Interface
====================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ILogValues





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Abstractions/ILogValues.cs>`_





.. dn:interface:: Microsoft.Extensions.Logging.ILogValues

Methods
-------

.. dn:interface:: Microsoft.Extensions.Logging.ILogValues
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.ILogValues.GetValues()
    
        
    
        Returns an enumerable of key value pairs mapping the name of the structured data to the data.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           IEnumerable<KeyValuePair<string, object>> GetValues()
    

