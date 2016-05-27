

IConnectionFilter Interface
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Filter`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IConnectionFilter








.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter.OnConnectionAsync(Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Filter.ConnectionFilterContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task OnConnectionAsync(ConnectionFilterContext context)
    

