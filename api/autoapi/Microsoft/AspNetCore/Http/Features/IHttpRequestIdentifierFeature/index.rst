

IHttpRequestIdentifierFeature Interface
=======================================






Feature to identify a request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHttpRequestIdentifierFeature








.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpRequestIdentifierFeature
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpRequestIdentifierFeature

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.Features.IHttpRequestIdentifierFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.IHttpRequestIdentifierFeature.TraceIdentifier
    
        
    
        
        Identifier to trace a request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string TraceIdentifier
            {
                get;
                set;
            }
    

