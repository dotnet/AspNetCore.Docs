

IRazorPageFactoryProvider Interface
===================================






Defines methods that are used for creating :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` instances at a given path.


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

    public interface IRazorPageFactoryProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.IRazorPageFactoryProvider.CreateFactory(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorPage` factory for the specified path.
    
        
    
        
        :param relativePath: The path to locate the page.
        
        :type relativePath: System.String
        :rtype: Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult
        :return: The :any:`Microsoft.AspNetCore.Mvc.Razor.RazorPageFactoryResult` instance.
    
        
        .. code-block:: csharp
    
            RazorPageFactoryResult CreateFactory(string relativePath)
    

