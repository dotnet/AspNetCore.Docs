

IHttpSendFileFeature Interface
==============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IHttpSendFileFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Features/IHttpSendFileFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpSendFileFeature

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpSendFileFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.IHttpSendFileFeature.SendFileAsync(System.String, System.Int64, System.Nullable<System.Int64>, System.Threading.CancellationToken)
    
        
        
        
        :type path: System.String
        
        
        :type offset: System.Int64
        
        
        :type length: System.Nullable{System.Int64}
        
        
        :type cancellation: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task SendFileAsync(string path, long offset, long ? length, CancellationToken cancellation)
    

