

IConnectionFilter Interface
===========================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IConnectionFilter





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Filter/IConnectionFilter.cs>`_





.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Filter.IConnectionFilter

Methods
-------

.. dn:interface:: Microsoft.AspNet.Server.Kestrel.Filter.IConnectionFilter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Filter.IConnectionFilter.OnConnection(Microsoft.AspNet.Server.Kestrel.Filter.ConnectionFilterContext)
    
        
        
        
        :type context: Microsoft.AspNet.Server.Kestrel.Filter.ConnectionFilterContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task OnConnection(ConnectionFilterContext context)
    

