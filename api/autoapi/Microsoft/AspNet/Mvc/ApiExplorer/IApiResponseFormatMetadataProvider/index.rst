

IApiResponseFormatMetadataProvider Interface
============================================



.. contents:: 
   :local:



Summary
-------

Provides metadata information about the response format to an <c>IApiDescriptionProvider</c>.











Syntax
------

.. code-block:: csharp

   public interface IApiResponseFormatMetadataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ApiExplorer/IApiResponseFormatMetadataProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiResponseFormatMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiResponseFormatMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApiExplorer.IApiResponseFormatMetadataProvider.GetSupportedContentTypes(Microsoft.Net.Http.Headers.MediaTypeHeaderValue, System.Type)
    
        
    
        Gets a filtered list of content types which are supported by the :any:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter`
        for the ``declaredType`` and ``contentType``.
    
        
        
        
        :param contentType: The content type for which the supported content types are desired, or null if any content
            type can be used.
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        
        
        :param objectType: The  for which the supported content types are desired.
        
        :type objectType: System.Type
        :rtype: System.Collections.Generic.IReadOnlyList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
        :return: Content types which are supported by the <see cref="T:Microsoft.AspNet.Mvc.Formatters.IOutputFormatter" />.
    
        
        .. code-block:: csharp
    
           IReadOnlyList<MediaTypeHeaderValue> GetSupportedContentTypes(MediaTypeHeaderValue contentType, Type objectType)
    

