

ITempDataProvider Interface
===========================






Defines the contract for temporary-data providers that store data that is viewed on the next request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITempDataProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider.LoadTempData(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Loads the temporary data.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext`\.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
        :return: The temporary data.
    
        
        .. code-block:: csharp
    
            IDictionary<string, object> LoadTempData(HttpContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider.SaveTempData(Microsoft.AspNetCore.Http.HttpContext, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        Saves the temporary data.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext`\.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param values: The values to save.
        
        :type values: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            void SaveTempData(HttpContext context, IDictionary<string, object> values)
    

