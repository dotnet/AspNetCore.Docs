

MvcRazorMvcViewOptionsSetup Class
=================================



.. contents:: 
   :local:



Summary
-------

Configures :any:`Microsoft.AspNet.Mvc.MvcViewOptions` to use :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions{Microsoft.AspNet.Mvc.MvcViewOptions}`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup`








Syntax
------

.. code-block:: csharp

   public class MvcRazorMvcViewOptionsSetup : ConfigureOptions<MvcViewOptions>, IConfigureOptions<MvcViewOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/Internal/MvcRazorMvcViewOptionsSetup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup.MvcRazorMvcViewOptionsSetup(System.IServiceProvider)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup`\.
    
        
        
        
        :param serviceProvider: The application's .
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public MvcRazorMvcViewOptionsSetup(IServiceProvider serviceProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.Internal.MvcRazorMvcViewOptionsSetup.ConfigureMvc(System.IServiceProvider, Microsoft.AspNet.Mvc.MvcViewOptions)
    
        
    
        Configures ``options`` to use :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine`\.
    
        
        
        
        :param serviceProvider: The application's .
        
        :type serviceProvider: System.IServiceProvider
        
        
        :param options: The  to configure.
        
        :type options: Microsoft.AspNet.Mvc.MvcViewOptions
    
        
        .. code-block:: csharp
    
           public static void ConfigureMvc(IServiceProvider serviceProvider, MvcViewOptions options)
    

