

IRazorViewEngine Interface
==========================






An :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine` used to render pages that use the Razor syntax.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRazorViewEngine : IViewEngine








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine.FindPage(Microsoft.AspNetCore.Mvc.ActionContext, System.String)
    
        
    
        
        Finds the page with the given <em>pageName</em> using view locations and information from the
        <em>context</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param pageName: The name of the page.
        
        :type pageName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult
        :return: The :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPageResult` of locating the page.
    
        
        .. code-block:: csharp
    
            RazorPageResult FindPage(ActionContext context, string pageName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine.GetAbsolutePath(System.String, System.String)
    
        
    
        
        Converts the given <em>pagePath</em> to be absolute, relative to
        <em>executingFilePath</em> unless <em>pagePath</em> is already absolute.
    
        
    
        
        :param executingFilePath: The absolute path to the currently-executing page, if any.
        
        :type executingFilePath: System.String
    
        
        :param pagePath: The path to the page.
        
        :type pagePath: System.String
        :rtype: System.String
        :return: 
            The combination of <em>executingFilePath</em> and <em>pagePath</em> if
            <em>pagePath</em> is a relative path. The <em>pagePath</em> value (unchanged)
            otherwise.
    
        
        .. code-block:: csharp
    
            string GetAbsolutePath(string executingFilePath, string pagePath)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine.GetPage(System.String, System.String)
    
        
    
        
        Gets the page with the given <em>pagePath</em>, relative to <em>executingFilePath</em>
        unless <em>pagePath</em> is already absolute.
    
        
    
        
        :param executingFilePath: The absolute path to the currently-executing page, if any.
        
        :type executingFilePath: System.String
    
        
        :param pagePath: The path to the page.
        
        :type pagePath: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Razor.RazorPageResult
        :return: The :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPageResult` of locating the page.
    
        
        .. code-block:: csharp
    
            RazorPageResult GetPage(string executingFilePath, string pagePath)
    

