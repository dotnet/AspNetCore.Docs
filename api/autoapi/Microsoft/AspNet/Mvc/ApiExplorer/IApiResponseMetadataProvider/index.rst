

IApiResponseMetadataProvider Interface
======================================



.. contents:: 
   :local:



Summary
-------

Provides a return type and a set of possible content types returned by a successful execution of the action.











Syntax
------

.. code-block:: csharp

   public interface IApiResponseMetadataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApiExplorer/IApiResponseMetadataProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiResponseMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiResponseMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApiExplorer.IApiResponseMetadataProvider.SetContentTypes(System.Collections.Generic.IList<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>)
    
        
    
        Configures a collection of allowed content types which can be produced by the action.
    
        
        
        
        :type contentTypes: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
    
        
        .. code-block:: csharp
    
           void SetContentTypes(IList<MediaTypeHeaderValue> contentTypes)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiResponseMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.IApiResponseMetadataProvider.Type
    
        
    
        Optimistic return type of the action.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           Type Type { get; }
    

