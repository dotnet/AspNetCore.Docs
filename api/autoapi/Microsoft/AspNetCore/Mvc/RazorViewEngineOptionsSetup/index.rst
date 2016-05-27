

RazorViewEngineOptionsSetup Class
=================================






Sets up default options for :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.ConfigureOptions{Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.RazorViewEngineOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class RazorViewEngineOptionsSetup : ConfigureOptions<RazorViewEngineOptions>, IConfigureOptions<RazorViewEngineOptions>








.. dn:class:: Microsoft.AspNetCore.Mvc.RazorViewEngineOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.RazorViewEngineOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.RazorViewEngineOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.RazorViewEngineOptionsSetup.RazorViewEngineOptionsSetup(Microsoft.AspNetCore.Hosting.IHostingEnvironment)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions`\.
    
        
    
        
        :param hostingEnvironment: :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment` for the application.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
            public RazorViewEngineOptionsSetup(IHostingEnvironment hostingEnvironment)
    

