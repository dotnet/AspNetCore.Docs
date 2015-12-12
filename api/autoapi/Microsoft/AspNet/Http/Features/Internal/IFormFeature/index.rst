

IFormFeature Interface
======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IFormFeature





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/Features/IFormFeature.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.Internal.IFormFeature

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.Features.Internal.IFormFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.Internal.IFormFeature.ReadForm()
    
        
    
        Parses the request body as a form.
    
        
        :rtype: Microsoft.AspNet.Http.IFormCollection
    
        
        .. code-block:: csharp
    
           IFormCollection ReadForm()
    
    .. dn:method:: Microsoft.AspNet.Http.Features.Internal.IFormFeature.ReadFormAsync(System.Threading.CancellationToken)
    
        
    
        Parses the request body as a form.
    
        
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Http.IFormCollection}
    
        
        .. code-block:: csharp
    
           Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.Internal.IFormFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.IFormFeature.Form
    
        
    
        The parsed form, if any.
    
        
        :rtype: Microsoft.AspNet.Http.IFormCollection
    
        
        .. code-block:: csharp
    
           IFormCollection Form { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Features.Internal.IFormFeature.HasFormContentType
    
        
    
        Indicates if the request has a supported form content-type.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool HasFormContentType { get; }
    

