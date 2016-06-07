

TagHelperServicesExtensions Class
=================================






Extension methods for configuring Razor cache tag helpers.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.TagHelperServicesExtensions`








Syntax
------

.. code-block:: csharp

    public class TagHelperServicesExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.TagHelperServicesExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.TagHelperServicesExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.TagHelperServicesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.TagHelperServicesExtensions.AddCacheTagHelper(Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder)
    
        
    
        
         Adds MVC cache tag helper services to the application.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
        
        :type builder: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddCacheTagHelper(IMvcCoreBuilder builder)
    

