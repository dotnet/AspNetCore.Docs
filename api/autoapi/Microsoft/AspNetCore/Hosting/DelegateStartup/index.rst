

DelegateStartup Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.StartupBase`
* :dn:cls:`Microsoft.AspNetCore.Hosting.DelegateStartup`








Syntax
------

.. code-block:: csharp

    public class DelegateStartup : StartupBase, IStartup








.. dn:class:: Microsoft.AspNetCore.Hosting.DelegateStartup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.DelegateStartup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.DelegateStartup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.DelegateStartup.DelegateStartup(System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        :type configureApp: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
    
        
        .. code-block:: csharp
    
            public DelegateStartup(Action<IApplicationBuilder> configureApp)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.DelegateStartup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.DelegateStartup.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public override void Configure(IApplicationBuilder app)
    

