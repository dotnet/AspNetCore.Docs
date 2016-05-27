

IViewEngine Interface
=====================






Defines the contract for a view engine.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewEngines`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IViewEngine








.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine.FindView(Microsoft.AspNetCore.Mvc.ActionContext, System.String, System.Boolean)
    
        
    
        
        Finds the view with the given <em>viewName</em> using view locations and information from the
        <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param viewName: The name of the view.
        
        :type viewName: System.String
    
        
        :param isMainPage: Determines if the page being found is the main page for an action.
        
        :type isMainPage: System.Boolean
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
        :return: The :any:`Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult` of locating the view.
    
        
        .. code-block:: csharp
    
            ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine.GetView(System.String, System.String, System.Boolean)
    
        
    
        
        Gets the view with the given <em>viewPath</em>, relative to <em>executingFilePath</em>
        unless <em>viewPath</em> is already absolute.
    
        
    
        
        :param executingFilePath: The absolute path to the currently-executing view, if any.
        
        :type executingFilePath: System.String
    
        
        :param viewPath: The path to the view.
        
        :type viewPath: System.String
    
        
        :param isMainPage: Determines if the page being found is the main page for an action.
        
        :type isMainPage: System.Boolean
        :rtype: Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult
        :return: The :any:`Microsoft.AspNetCore.Mvc.ViewEngines.ViewEngineResult` of locating the view.
    
        
        .. code-block:: csharp
    
            ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
    

