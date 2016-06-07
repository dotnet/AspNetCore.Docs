

ApiResponseFormat Class
=======================






Possible format for an :any:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseFormat`








Syntax
------

.. code-block:: csharp

    public class ApiResponseFormat








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseFormat
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseFormat

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseFormat
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseFormat.Formatter
    
        
    
        
        Gets or sets the formatter used to output this response.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter
    
        
        .. code-block:: csharp
    
            public IOutputFormatter Formatter
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseFormat.MediaType
    
        
    
        
        Gets or sets the media type of the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string MediaType
            {
                get;
                set;
            }
    

