

IApiRequestMetadataProvider Interface
=====================================






Provides a a set of possible content types than can be consumed by the action.


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

    public interface IApiRequestMetadataProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiRequestMetadataProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiRequestMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiRequestMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiRequestMetadataProvider.SetContentTypes(Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection)
    
        
    
        
        Configures a collection of allowed content types which can be consumed by the action.
    
        
    
        
        :param contentTypes: The :any:`Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection`
        
        :type contentTypes: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        .. code-block:: csharp
    
            void SetContentTypes(MediaTypeCollection contentTypes)
    

