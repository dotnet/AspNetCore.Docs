

IStartupFilter Interface
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IStartupFilter








.. dn:interface:: Microsoft.AspNetCore.Hosting.IStartupFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Hosting.IStartupFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Hosting.IStartupFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IStartupFilter.Configure(System.Action<Microsoft.AspNetCore.Builder.IApplicationBuilder>)
    
        
    
        
        :type next: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IApplicationBuilder<Microsoft.AspNetCore.Builder.IApplicationBuilder>}
    
        
        .. code-block:: csharp
    
            Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    

