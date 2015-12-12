

ConfigureBuilder Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.Startup.ConfigureBuilder`








Syntax
------

.. code-block:: csharp

   public class ConfigureBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/Startup/ConfigureDelegate.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.Startup.ConfigureBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.Startup.ConfigureBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Startup.ConfigureBuilder.ConfigureBuilder(System.Reflection.MethodInfo)
    
        
        
        
        :type configure: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
           public ConfigureBuilder(MethodInfo configure)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.Startup.ConfigureBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Startup.ConfigureBuilder.Build(System.Object)
    
        
        
        
        :type instance: System.Object
        :rtype: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
    
        
        .. code-block:: csharp
    
           public Action<IApplicationBuilder> Build(object instance)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Hosting.Startup.ConfigureBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.Startup.ConfigureBuilder.MethodInfo
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
           public MethodInfo MethodInfo { get; }
    

