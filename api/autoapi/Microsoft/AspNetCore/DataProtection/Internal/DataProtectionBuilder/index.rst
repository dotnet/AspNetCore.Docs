

DataProtectionBuilder Class
===========================






Default implementation of :any:`Microsoft.AspNetCore.DataProtection.IDataProtectionBuilder`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.DataProtection.Internal`
Assemblies
    * Microsoft.AspNetCore.DataProtection

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.DataProtection.Internal.DataProtectionBuilder`








Syntax
------

.. code-block:: csharp

    public class DataProtectionBuilder : IDataProtectionBuilder








.. dn:class:: Microsoft.AspNetCore.DataProtection.Internal.DataProtectionBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.DataProtection.Internal.DataProtectionBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Internal.DataProtectionBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.DataProtection.Internal.DataProtectionBuilder.Services
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public IServiceCollection Services
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.DataProtection.Internal.DataProtectionBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.DataProtection.Internal.DataProtectionBuilder.DataProtectionBuilder(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Creates a new configuration object linked to a :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public DataProtectionBuilder(IServiceCollection services)
    

