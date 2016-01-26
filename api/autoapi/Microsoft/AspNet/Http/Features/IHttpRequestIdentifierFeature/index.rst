

IHttpRequestIdentifierFeature Interface
=======================================



.. contents:: 
   :local:



Summary
-------

Feature to identify a request.











Syntax
------

.. code-block:: csharp

   public interface IHttpRequestIdentifierFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http.Features/IHttpRequestIdentifierFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpRequestIdentifierFeature

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.IHttpRequestIdentifierFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.IHttpRequestIdentifierFeature.TraceIdentifier
    
        
    
        Identifier to trace a request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string TraceIdentifier { get; set; }
    

