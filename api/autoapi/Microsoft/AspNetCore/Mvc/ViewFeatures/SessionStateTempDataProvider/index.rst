

SessionStateTempDataProvider Class
==================================






Provides session-state data to the current :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary` object.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.SessionStateTempDataProvider`








Syntax
------

.. code-block:: csharp

    public class SessionStateTempDataProvider : ITempDataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.SessionStateTempDataProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.SessionStateTempDataProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.SessionStateTempDataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.SessionStateTempDataProvider.LoadTempData(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public virtual IDictionary<string, object> LoadTempData(HttpContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.SessionStateTempDataProvider.SaveTempData(Microsoft.AspNetCore.Http.HttpContext, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type values: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public virtual void SaveTempData(HttpContext context, IDictionary<string, object> values)
    

