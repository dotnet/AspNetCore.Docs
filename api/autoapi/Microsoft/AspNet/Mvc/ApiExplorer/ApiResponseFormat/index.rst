

ApiResponseFormat Class
=======================



.. contents:: 
   :local:



Summary
-------

Represents a possible format for the body of a response.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorer.ApiResponseFormat`








Syntax
------

.. code-block:: csharp

   public class ApiResponseFormat





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ApiExplorer/ApiResponseFormat.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiResponseFormat

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorer.ApiResponseFormat
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiResponseFormat.Formatter
    
        
    
        The formatter used to output this response.
    
        
        :rtype: Microsoft.AspNet.Mvc.Formatters.IOutputFormatter
    
        
        .. code-block:: csharp
    
           public IOutputFormatter Formatter { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.ApiResponseFormat.MediaType
    
        
    
        The media type of the response.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public MediaTypeHeaderValue MediaType { get; set; }
    

