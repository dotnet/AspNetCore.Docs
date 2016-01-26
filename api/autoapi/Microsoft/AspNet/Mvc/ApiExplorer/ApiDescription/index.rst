

ApiDescription Class
====================



.. contents:: 
   :local:



Summary
-------

Represents an API exposed by this application.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription`








Syntax
------

.. code-block:: csharp

   public class ApiDescription





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ApiExplorer/ApiDescription.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.ApiDescription()
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription`\.
    
        
    
        
        .. code-block:: csharp
    
           public ApiDescription()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.ActionDescriptor
    
        
    
        The :dn:prop:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.ActionDescriptor` for this api.
    
        
        :rtype: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
           public ActionDescriptor ActionDescriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.GroupName
    
        
    
        The group name for this api.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string GroupName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.HttpMethod
    
        
    
        The supported HTTP method for this api, or null if all HTTP methods are supported.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string HttpMethod { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.ParameterDescriptions
    
        
    
        The list of :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription` for this api.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApiExplorer.ApiParameterDescription}
    
        
        .. code-block:: csharp
    
           public IList<ApiParameterDescription> ParameterDescriptions { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.Properties
    
        
    
        Stores arbitrary metadata properties associated with the :any:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription`\.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<object, object> Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.RelativePath
    
        
    
        The relative url path template (relative to application root) for this api.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RelativePath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.ResponseModelMetadata
    
        
    
        The :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata` for the :dn:prop:`Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.ResponseType` or null.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata ResponseModelMetadata { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.ResponseType
    
        
    
        The CLR data type of the response or null.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type ResponseType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiDescription.SupportedResponseFormats
    
        
    
        A list of possible formats for a response.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ApiExplorer.ApiResponseFormat}
    
        
        .. code-block:: csharp
    
           public IList<ApiResponseFormat> SupportedResponseFormats { get; }
    

