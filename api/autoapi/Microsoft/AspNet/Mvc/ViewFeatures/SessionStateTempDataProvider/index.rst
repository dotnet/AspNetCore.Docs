

SessionStateTempDataProvider Class
==================================



.. contents:: 
   :local:



Summary
-------

Provides session-state data to the current :any:`Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary` object.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.SessionStateTempDataProvider`








Syntax
------

.. code-block:: csharp

   public class SessionStateTempDataProvider : ITempDataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/SessionStateTempDataProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.SessionStateTempDataProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.SessionStateTempDataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.SessionStateTempDataProvider.LoadTempData(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public virtual IDictionary<string, object> LoadTempData(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.SessionStateTempDataProvider.SaveTempData(Microsoft.AspNet.Http.HttpContext, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public virtual void SaveTempData(HttpContext context, IDictionary<string, object> values)
    

