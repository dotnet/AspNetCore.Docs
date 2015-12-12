

ITempDataProvider Interface
===========================



.. contents:: 
   :local:



Summary
-------

Defines the contract for temporary-data providers that store data that is viewed on the next request.











Syntax
------

.. code-block:: csharp

   public interface ITempDataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ITempDataProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataProvider.LoadTempData(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Loads the temporary data.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
        :return: The temporary data.
    
        
        .. code-block:: csharp
    
           IDictionary<string, object> LoadTempData(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataProvider.SaveTempData(Microsoft.AspNet.Http.HttpContext, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        Saves the temporary data.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param values: The values to save.
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           void SaveTempData(HttpContext context, IDictionary<string, object> values)
    

