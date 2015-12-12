

ViewEngineResult Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult`








Syntax
------

.. code-block:: csharp

   public class ViewEngineResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewEngines/ViewEngineResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult.EnsureSuccessful()
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
           public ViewEngineResult EnsureSuccessful()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult.Found(System.String, Microsoft.AspNet.Mvc.ViewEngines.IView)
    
        
        
        
        :type viewName: System.String
        
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
           public static ViewEngineResult Found(string viewName, IView view)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult.NotFound(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
        
        
        :type viewName: System.String
        
        
        :type searchedLocations: System.Collections.Generic.IEnumerable{System.String}
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
    
        
        .. code-block:: csharp
    
           public static ViewEngineResult NotFound(string viewName, IEnumerable<string> searchedLocations)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult.SearchedLocations
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> SearchedLocations { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult.Success
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Success { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult.View
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.IView
    
        
        .. code-block:: csharp
    
           public IView View { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult.ViewName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ViewName { get; }
    

