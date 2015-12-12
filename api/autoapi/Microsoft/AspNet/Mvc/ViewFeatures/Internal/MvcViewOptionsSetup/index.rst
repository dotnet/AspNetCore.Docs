

MvcViewOptionsSetup Class
=========================



.. contents:: 
   :local:



Summary
-------

Sets up default options for :any:`Microsoft.AspNet.Mvc.MvcViewOptions`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions{Microsoft.AspNet.Mvc.MvcViewOptions}`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup`








Syntax
------

.. code-block:: csharp

   public class MvcViewOptionsSetup : ConfigureOptions<MvcViewOptions>, IConfigureOptions<MvcViewOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Internal/MvcViewOptionsSetup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup.MvcViewOptionsSetup(System.IServiceProvider)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup`\.
    
        
        
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public MvcViewOptionsSetup(IServiceProvider serviceProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup.ConfigureMvc(Microsoft.AspNet.Mvc.MvcViewOptions, System.IServiceProvider)
    
        
        
        
        :type options: Microsoft.AspNet.Mvc.MvcViewOptions
        
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public static void ConfigureMvc(MvcViewOptions options, IServiceProvider serviceProvider)
    

