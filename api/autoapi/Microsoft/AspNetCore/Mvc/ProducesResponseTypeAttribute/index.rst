

ProducesResponseTypeAttribute Class
===================================






A filter that specifies the type of the value and status code returned by the action.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ProducesResponseTypeAttribute : Attribute, _Attribute, IApiResponseMetadataProvider, IFilterMetadata








.. dn:class:: Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute.StatusCode
    
        
    
        
        Gets or sets the HTTP status code of the response.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StatusCode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute.Type
    
        
    
        
        Gets or sets the type of the value returned by an action.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type Type
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute.ProducesResponseTypeAttribute(System.Type, System.Int32)
    
        
    
        
        Initializes an instance of :any:`Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute`\.
    
        
    
        
        :param type: The :dn:prop:`Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute.Type` of object that is going to be written in the response.
        
        :type type: System.Type
    
        
        :param statusCode: The HTTP response status code.
        
        :type statusCode: System.Int32
    
        
        .. code-block:: csharp
    
            public ProducesResponseTypeAttribute(Type type, int statusCode)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute.Microsoft.AspNetCore.Mvc.ApiExplorer.IApiResponseMetadataProvider.SetContentTypes(Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection)
    
        
    
        
        :type contentTypes: Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
    
        
        .. code-block:: csharp
    
            void IApiResponseMetadataProvider.SetContentTypes(MediaTypeCollection contentTypes)
    

