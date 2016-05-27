

IApiResponseTypeMetadataProvider Interface
==========================================






Provides metadata information about the response format to an <code>IApiDescriptionProvider</code>.


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

    public interface IApiResponseTypeMetadataProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseTypeMetadataProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseTypeMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseTypeMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseTypeMetadataProvider.GetSupportedContentTypes(System.String, System.Type)
    
        
    
        
        Gets a filtered list of content types which are supported by the :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter`
        for the <em>objectType</em> and <em>contentType</em>.
    
        
    
        
        :param contentType: 
            The content type for which the supported content types are desired, or <code>null</code> if any content
            type can be used.
        
        :type contentType: System.String
    
        
        :param objectType: 
            The :any:`System.Type` for which the supported content types are desired.
        
        :type objectType: System.Type
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.String<System.String>}
        :return: Content types which are supported by the :any:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter`\.
    
        
        .. code-block:: csharp
    
            IReadOnlyList<string> GetSupportedContentTypes(string contentType, Type objectType)
    

