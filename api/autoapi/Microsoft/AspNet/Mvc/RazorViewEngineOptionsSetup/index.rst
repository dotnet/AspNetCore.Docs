

RazorViewEngineOptionsSetup Class
=================================



.. contents:: 
   :local:



Summary
-------

Sets up default options for :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions{Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions}`
* :dn:cls:`Microsoft.AspNet.Mvc.RazorViewEngineOptionsSetup`








Syntax
------

.. code-block:: csharp

   public class RazorViewEngineOptionsSetup : ConfigureOptions<RazorViewEngineOptions>, IConfigureOptions<RazorViewEngineOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/RazorViewEngineOptionsSetup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.RazorViewEngineOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.RazorViewEngineOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.RazorViewEngineOptionsSetup.RazorViewEngineOptionsSetup(Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions`\.
    
        
        
        
        :param applicationEnvironment: for the application.
        
        :type applicationEnvironment: Microsoft.Extensions.PlatformAbstractions.IApplicationEnvironment
    
        
        .. code-block:: csharp
    
           public RazorViewEngineOptionsSetup(IApplicationEnvironment applicationEnvironment)
    

