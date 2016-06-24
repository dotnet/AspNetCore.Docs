

ApiDescription Class
====================






Represents an API exposed by this application.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApiExplorer`
Assemblies
    * Microsoft.AspNetCore.Mvc.ApiExplorer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription`








Syntax
------

.. code-block:: csharp

    public class ApiDescription








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.ActionDescriptor
    
        
    
        
        Gets or sets :dn:prop:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.ActionDescriptor` for this api.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
            public ActionDescriptor ActionDescriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.GroupName
    
        
    
        
        Gets or sets group name for this api.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GroupName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.HttpMethod
    
        
    
        
        Gets or sets the supported HTTP method for this api, or null if all HTTP methods are supported.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string HttpMethod { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.ParameterDescriptions
    
        
    
        
        Gets a list of :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription` for this api.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription>}
    
        
        .. code-block:: csharp
    
            public IList<ApiParameterDescription> ParameterDescriptions { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.Properties
    
        
    
        
        Gets arbitrary metadata properties associated with the :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription`\.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public IDictionary<object, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.RelativePath
    
        
    
        
        Gets or sets relative url path template (relative to application root) for this api.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RelativePath { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.SupportedRequestFormats
    
        
    
        
        Gets the list of possible formats for a response.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApiExplorer.ApiRequestFormat<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiRequestFormat>}
    
        
        .. code-block:: csharp
    
            public IList<ApiRequestFormat> SupportedRequestFormats { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription.SupportedResponseTypes
    
        
    
        
        Gets the list of possible formats for a response.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType>}
    
        
        .. code-block:: csharp
    
            public IList<ApiResponseType> SupportedResponseTypes { get; }
    

