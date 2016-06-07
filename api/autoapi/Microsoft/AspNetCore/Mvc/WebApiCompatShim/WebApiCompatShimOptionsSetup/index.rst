

WebApiCompatShimOptionsSetup Class
==================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.WebApiCompatShim`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class WebApiCompatShimOptionsSetup : IConfigureOptions<MvcOptions>, IConfigureOptions<WebApiCompatShimOptions>








.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup.Configure(Microsoft.AspNetCore.Mvc.MvcOptions)
    
        
    
        
        :type options: Microsoft.AspNetCore.Mvc.MvcOptions
    
        
        .. code-block:: csharp
    
            public void Configure(MvcOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup.Configure(Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptions)
    
        
    
        
        :type options: Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptions
    
        
        .. code-block:: csharp
    
            public void Configure(WebApiCompatShimOptions options)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiCompatShimOptionsSetup.DefaultAreaName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static readonly string DefaultAreaName
    

