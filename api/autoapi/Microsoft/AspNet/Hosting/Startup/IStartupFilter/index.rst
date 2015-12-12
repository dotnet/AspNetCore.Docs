

IStartupFilter Interface
========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IStartupFilter





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/Startup/IStartupFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Hosting.Startup.IStartupFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Hosting.Startup.IStartupFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Startup.IStartupFilter.Configure(System.Action<Microsoft.AspNet.Builder.IApplicationBuilder>)
    
        
        
        
        :type next: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
        :rtype: System.Action{Microsoft.AspNet.Builder.IApplicationBuilder}
    
        
        .. code-block:: csharp
    
           Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    

