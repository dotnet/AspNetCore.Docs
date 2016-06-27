

ApiResponseType Class
=====================






Possible type of the response body which is formatted by :dn:prop:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType.ApiResponseFormats`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType`








Syntax
------

.. code-block:: csharp

    public class ApiResponseType








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType.ApiResponseFormats
    
        
    
        
        Gets or sets the response formats supported by this type.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseFormat<Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseFormat>}
    
        
        .. code-block:: csharp
    
            public IList<ApiResponseFormat> ApiResponseFormats { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType.ModelMetadata
    
        
    
        
        Gets or sets :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for the :dn:prop:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType.Type` or null.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata ModelMetadata { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType.StatusCode
    
        
    
        
        Gets or sets the HTTP response status code.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StatusCode { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType.Type
    
        
    
        
        Gets or sets the CLR data type of the response or null.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type Type { get; set; }
    

