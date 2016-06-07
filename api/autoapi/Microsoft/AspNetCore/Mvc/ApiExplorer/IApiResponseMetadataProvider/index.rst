

IApiResponseMetadataProvider Interface
======================================






Provides a return type, status code and a set of possible content types returned by a
successful execution of the action.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApiExplorer`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IApiResponseMetadataProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseMetadataProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseMetadataProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseMetadataProvider.StatusCode
    
        
    
        
        Gets the HTTP status code of the response.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int StatusCode
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseMetadataProvider.Type
    
        
    
        
        Gets the optimistic return type of the action.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            Type Type
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseMetadataProvider.SetContentTypes(Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection)
    
        
    
        
        Configures a collection of allowed content types which can be produced by the action.
    
        
    
        
        :type contentTypes: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        .. code-block:: csharp
    
            void SetContentTypes(MediaTypeCollection contentTypes)
    

