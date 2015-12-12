

WebApiCompatShimOptionsSetup Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup`








Syntax
------

.. code-block:: csharp

   public class WebApiCompatShimOptionsSetup : IConfigureOptions<MvcOptions>, IConfigureOptions<WebApiCompatShimOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.WebApiCompatShim/WebApiCompatShimOptionsSetup.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup.Configure(Microsoft.AspNet.Mvc.MvcOptions)
    
        
        
        
        :type options: Microsoft.AspNet.Mvc.MvcOptions
    
        
        .. code-block:: csharp
    
           public void Configure(MvcOptions options)
    
    .. dn:method:: Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup.Configure(Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptions)
    
        
        
        
        :type options: Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptions
    
        
        .. code-block:: csharp
    
           public void Configure(WebApiCompatShimOptions options)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup.DefaultAreaName
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string DefaultAreaName
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Name { get; set; }
    

