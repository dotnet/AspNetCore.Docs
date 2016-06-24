

ConfigureBuilder Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Internal`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Internal.ConfigureBuilder`








Syntax
------

.. code-block:: csharp

    public class ConfigureBuilder








.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.ConfigureBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.ConfigureBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.ConfigureBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.Internal.ConfigureBuilder.ConfigureBuilder(System.Reflection.MethodInfo)
    
        
    
        
        :type configure: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
            public ConfigureBuilder(MethodInfo configure)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.ConfigureBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.ConfigureBuilder.Build(System.Object)
    
        
    
        
        :type instance: System.Object
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
    
        
        .. code-block:: csharp
    
            public Action<IApplicationBuilder> Build(object instance)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.ConfigureBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.ConfigureBuilder.MethodInfo
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
            public MethodInfo MethodInfo { get; }
    

