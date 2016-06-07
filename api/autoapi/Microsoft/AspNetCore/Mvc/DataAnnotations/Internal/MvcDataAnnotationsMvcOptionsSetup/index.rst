

MvcDataAnnotationsMvcOptionsSetup Class
=======================================






Sets up default options for :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.DataAnnotations

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.ConfigureOptions{Microsoft.AspNetCore.Mvc.MvcOptions}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class MvcDataAnnotationsMvcOptionsSetup : ConfigureOptions<MvcOptions>, IConfigureOptions<MvcOptions>








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup.MvcDataAnnotationsMvcOptionsSetup(System.IServiceProvider)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public MvcDataAnnotationsMvcOptionsSetup(IServiceProvider serviceProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.DataAnnotations.Internal.MvcDataAnnotationsMvcOptionsSetup.ConfigureMvc(Microsoft.AspNetCore.Mvc.MvcOptions, System.IServiceProvider)
    
        
    
        
        :type options: Microsoft.AspNetCore.Mvc.MvcOptions
    
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public static void ConfigureMvc(MvcOptions options, IServiceProvider serviceProvider)
    

