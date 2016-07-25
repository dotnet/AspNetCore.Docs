

ProducesAttribute Class
=======================






A filter that specifies the expected :any:`System.Type` the action will return and the supported
response content types. The :dn:prop:`Microsoft.AspNetCore.Mvc.ProducesAttribute.ContentTypes` value is used to set 
:dn:prop:`Microsoft.AspNetCore.Mvc.ObjectResult.ContentTypes`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ProducesAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ProducesAttribute : ResultFilterAttribute, _Attribute, IResultFilter, IAsyncResultFilter, IOrderedFilter, IFilterMetadata, IApiResponseMetadataProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ProducesAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ProducesAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ProducesAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ProducesAttribute.ProducesAttribute(System.String, System.String[])
    
        
    
        
        Initializes an instance of :any:`Microsoft.AspNetCore.Mvc.ProducesAttribute` with allowed content types.
    
        
    
        
        :param contentType: The allowed content type for a response.
        
        :type contentType: System.String
    
        
        :param additionalContentTypes: Additional allowed content types for a response.
        
        :type additionalContentTypes: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public ProducesAttribute(string contentType, params string[] additionalContentTypes)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ProducesAttribute.ProducesAttribute(System.Type)
    
        
    
        
        Initializes an instance of :any:`Microsoft.AspNetCore.Mvc.ProducesAttribute`\.
    
        
    
        
        :param type: The :dn:prop:`Microsoft.AspNetCore.Mvc.ProducesAttribute.Type` of object that is going to be written in the response.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
            public ProducesAttribute(Type type)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ProducesAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ProducesAttribute.ContentTypes
    
        
    
        
        Gets or sets the supported response content types. Used to set :dn:prop:`Microsoft.AspNetCore.Mvc.ObjectResult.ContentTypes`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        .. code-block:: csharp
    
            public MediaTypeCollection ContentTypes { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ProducesAttribute.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StatusCode { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ProducesAttribute.Type
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type Type { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ProducesAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ProducesAttribute.OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
            public override void OnResultExecuting(ResultExecutingContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ProducesAttribute.SetContentTypes(Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection)
    
        
    
        
        :type contentTypes: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        .. code-block:: csharp
    
            public void SetContentTypes(MediaTypeCollection contentTypes)
    

