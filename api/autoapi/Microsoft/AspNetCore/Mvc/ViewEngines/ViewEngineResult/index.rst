

ViewEngineResult Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewEngines`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult`








Syntax
------

.. code-block:: csharp

    public class ViewEngineResult








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult.SearchedLocations
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> SearchedLocations
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult.Success
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Success
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult.View
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.IView
    
        
        .. code-block:: csharp
    
            public IView View
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult.ViewName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ViewName
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult.EnsureSuccessful(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Ensure this :any:`Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult` was successful.
    
        
    
        
        :param originalLocations: 
            Additional :dn:prop:`Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult.SearchedLocations` to include in the thrown :any:`System.InvalidOperationException`
            if :dn:prop:`Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult.Success` is <code>false</code>.
        
        :type originalLocations: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
        :return: This :any:`Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult` if :dn:prop:`Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult.Success` is <code>true</code>.
    
        
        .. code-block:: csharp
    
            public ViewEngineResult EnsureSuccessful(IEnumerable<string> originalLocations)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult.Found(System.String, Microsoft.AspNetCore.Mvc.ViewEngines.IView)
    
        
    
        
        :type viewName: System.String
    
        
        :type view: Microsoft.AspNetCore.Mvc.ViewEngines.IView
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
            public static ViewEngineResult Found(string viewName, IView view)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult.NotFound(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        :type viewName: System.String
    
        
        :type searchedLocations: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
            public static ViewEngineResult NotFound(string viewName, IEnumerable<string> searchedLocations)
    

