

MvcDataAnnotationsMvcOptionsSetup Class
=======================================



.. contents:: 
   :local:



Summary
-------

Sets up default options for :any:`Microsoft.AspNet.Mvc.MvcOptions`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.OptionsModel.ConfigureOptions{Microsoft.AspNet.Mvc.MvcOptions}`
* :dn:cls:`Microsoft.AspNet.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup`








Syntax
------

.. code-block:: csharp

   public class MvcDataAnnotationsMvcOptionsSetup : ConfigureOptions<MvcOptions>, IConfigureOptions<MvcOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.DataAnnotations/Internal/MvcDataAnnotationsMvcOptionsSetup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup.MvcDataAnnotationsMvcOptionsSetup(System.IServiceProvider)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public MvcDataAnnotationsMvcOptionsSetup(IServiceProvider serviceProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup.ConfigureMvc(Microsoft.AspNet.Mvc.MvcOptions, System.IServiceProvider)
    
        
        
        
        :type options: Microsoft.AspNet.Mvc.MvcOptions
        
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public static void ConfigureMvc(MvcOptions options, IServiceProvider serviceProvider)
    

