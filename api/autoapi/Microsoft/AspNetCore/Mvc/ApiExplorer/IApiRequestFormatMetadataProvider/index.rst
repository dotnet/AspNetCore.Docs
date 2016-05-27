

IApiRequestFormatMetadataProvider Interface
===========================================






Provides metadata information about the request format to an <code>IApiDescriptionProvider</code>.


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

    public interface IApiRequestFormatMetadataProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiRequestFormatMetadataProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiRequestFormatMetadataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiRequestFormatMetadataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiRequestFormatMetadataProvider.GetSupportedContentTypes(System.String, System.Type)
    
        
    
        
        Gets a filtered list of content types which are supported by the :any:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter`
        for the <em>objectType</em> and <em>contentType</em>.
    
        
    
        
        :param contentType: 
            The content type for which the supported content types are desired, or <code>null</code> if any content
            type can be used.
        
        :type contentType: System.String
    
        
        :param objectType: 
            The :any:`System.Type` for which the supported content types are desired.
        
        :type objectType: System.Type
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.String<System.String>}
        :return: Content types which are supported by the :any:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter`\.
    
        
        .. code-block:: csharp
    
            IReadOnlyList<string> GetSupportedContentTypes(string contentType, Type objectType)
    

