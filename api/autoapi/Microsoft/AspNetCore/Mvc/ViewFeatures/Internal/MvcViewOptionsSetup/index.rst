

MvcViewOptionsSetup Class
=========================






Sets up default options for :any:`Microsoft.AspNetCore.Mvc.MvcViewOptions`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.ConfigureOptions{Microsoft.AspNetCore.Mvc.MvcViewOptions}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class MvcViewOptionsSetup : ConfigureOptions<MvcViewOptions>, IConfigureOptions<MvcViewOptions>








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup.MvcViewOptionsSetup(System.IServiceProvider)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup`\.
    
        
    
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public MvcViewOptionsSetup(IServiceProvider serviceProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MvcViewOptionsSetup.ConfigureMvc(Microsoft.AspNetCore.Mvc.MvcViewOptions, System.IServiceProvider)
    
        
    
        
        :type options: Microsoft.AspNetCore.Mvc.MvcViewOptions
    
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public static void ConfigureMvc(MvcViewOptions options, IServiceProvider serviceProvider)
    

