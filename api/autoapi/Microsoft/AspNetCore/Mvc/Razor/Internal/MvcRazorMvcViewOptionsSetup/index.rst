

MvcRazorMvcViewOptionsSetup Class
=================================






Configures :any:`Microsoft.AspNetCore.Mvc.MvcViewOptions` to use :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.ConfigureOptions{Microsoft.AspNetCore.Mvc.MvcViewOptions}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class MvcRazorMvcViewOptionsSetup : ConfigureOptions<MvcViewOptions>, IConfigureOptions<MvcViewOptions>








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup.MvcRazorMvcViewOptionsSetup(Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup`\.
    
        
    
        
        :param razorViewEngine: The :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine`\.
        
        :type razorViewEngine: Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine
    
        
        .. code-block:: csharp
    
            public MvcRazorMvcViewOptionsSetup(IRazorViewEngine razorViewEngine)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup.ConfigureMvc(Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine, Microsoft.AspNetCore.Mvc.MvcViewOptions)
    
        
    
        
        Configures <em>options</em> to use :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine`\.
    
        
    
        
        :param razorViewEngine: The :any:`Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine`\.
        
        :type razorViewEngine: Microsoft.AspNetCore.Mvc.Razor.IRazorViewEngine
    
        
        :param options: The :any:`Microsoft.AspNetCore.Mvc.MvcViewOptions` to configure.
        
        :type options: Microsoft.AspNetCore.Mvc.MvcViewOptions
    
        
        .. code-block:: csharp
    
            public static void ConfigureMvc(IRazorViewEngine razorViewEngine, MvcViewOptions options)
    

