

ProducesAttribute Class
=======================



.. contents:: 
   :local:



Summary
-------

Specifies the allowed content types and the type of the value returned by the action
which can be used to select a formatter while executing :any:`Microsoft.AspNet.Mvc.ObjectResult`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.ResultFilterAttribute`
* :dn:cls:`Microsoft.AspNet.Mvc.ProducesAttribute`








Syntax
------

.. code-block:: csharp

   public class ProducesAttribute : ResultFilterAttribute, _Attribute, IResultFilter, IAsyncResultFilter, IOrderedFilter, IFilterMetadata, IApiResponseMetadataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ProducesAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ProducesAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ProducesAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ProducesAttribute.ProducesAttribute(System.String, System.String[])
    
        
    
        Initializes an instance of :any:`Microsoft.AspNet.Mvc.ProducesAttribute` with allowed content types.
    
        
        
        
        :param contentType: The allowed content type for a response.
        
        :type contentType: System.String
        
        
        :param additionalContentTypes: Additional allowed content types for a response.
        
        :type additionalContentTypes: System.String[]
    
        
        .. code-block:: csharp
    
           public ProducesAttribute(string contentType, params string[] additionalContentTypes)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ProducesAttribute.ProducesAttribute(System.Type)
    
        
    
        Initializes an instance of :any:`Microsoft.AspNet.Mvc.ProducesAttribute`\.
    
        
        
        
        :param type: The  of object that is going to be written in the response.
        
        :type type: System.Type
    
        
        .. code-block:: csharp
    
           public ProducesAttribute(Type type)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ProducesAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ProducesAttribute.OnResultExecuting(Microsoft.AspNet.Mvc.Filters.ResultExecutingContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Filters.ResultExecutingContext
    
        
        .. code-block:: csharp
    
           public override void OnResultExecuting(ResultExecutingContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ProducesAttribute.SetContentTypes(System.Collections.Generic.IList<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>)
    
        
        
        
        :type contentTypes: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
    
        
        .. code-block:: csharp
    
           public void SetContentTypes(IList<MediaTypeHeaderValue> contentTypes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ProducesAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ProducesAttribute.ContentTypes
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.Net.Http.Headers.MediaTypeHeaderValue}
    
        
        .. code-block:: csharp
    
           public IList<MediaTypeHeaderValue> ContentTypes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ProducesAttribute.Type
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type Type { get; set; }
    

